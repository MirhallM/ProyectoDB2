using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectoDB2.Modelos;

namespace ProyectoDB2.Forms
{
    public partial class CrearTablaPaso2 : Form
    {
        private readonly string esquema;
        private readonly string nombreTabla;

        public List<ColumnaTabla> Columnas { get; private set; } = new List<ColumnaTabla>();

        public string DdlGenerado { get; private set; } = "";

        public CrearTablaPaso2(string esquema, string nombreTabla)
        {
            InitializeComponent();

            this.esquema = (esquema ?? "").Trim();
            this.nombreTabla = (nombreTabla ?? "").Trim();
        }

        private void CrearTablaPaso2_Load(object sender, EventArgs e)
        {
            lblTituloTabla.Text = $"Tabla: {esquema}.{nombreTabla}";
            ConfigurarGrid();
            AgregarFilaInicial();
        }

        private void ConfigurarGrid()
        {
            dgvColumnas.AllowUserToAddRows = false;
            dgvColumnas.AllowUserToDeleteRows = false;
            dgvColumnas.MultiSelect = false;
            dgvColumnas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvColumnas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvColumnas.Columns.Clear();

            dgvColumnas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colNombre",
                HeaderText = "Nombre"
            });

            var colTipo = new DataGridViewComboBoxColumn()
            {
                Name = "colTipo",
                HeaderText = "Tipo",
                DataSource = new List<string>
                {
                    "INTEGER", "BIGINT", "SMALLINT",
                    "VARCHAR", "CHAR",
                    "DECIMAL", "NUMERIC",
                    "DATE", "TIME", "TIMESTAMP",
                    "DOUBLE", "REAL"
                }
            };
            dgvColumnas.Columns.Add(colTipo);

            dgvColumnas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colLongitud",
                HeaderText = "Longitud"
            });

            dgvColumnas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEscala",
                HeaderText = "Escala"
            });

            dgvColumnas.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colNotNull",
                HeaderText = "NOT NULL"
            });

            dgvColumnas.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colPK",
                HeaderText = "PK"
            });

            dgvColumnas.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "colIdentity",
                HeaderText = "IDENTITY"
            });

            dgvColumnas.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDefault",
                HeaderText = "DEFAULT"
            });
        }

        private void AgregarFilaInicial()
        {
            // Algo inicial para que el usuario no vea el grid vacío
            dgvColumnas.Rows.Add("ID", "INTEGER", "", "", true, true, true, "");
        }

        private void btnAgregarColumnas_Click(object sender, EventArgs e)
        {
            dgvColumnas.Rows.Add("", "INTEGER", "", "", false, false, false, "");
        }

        private void btnEliminarColumna_Click(object sender, EventArgs e)
        {
            if (dgvColumnas.SelectedRows.Count == 0) return;

            int idx = dgvColumnas.SelectedRows[0].Index;
            if (idx >= 0 && idx < dgvColumnas.Rows.Count)
                dgvColumnas.Rows.RemoveAt(idx);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry; // señal para que el paso 1 se vuelva a mostrar
            Close();
        }

        private bool LeerColumnasDesdeGrid(out List<ColumnaTabla> columnas, out string error)
        {
            columnas = new List<ColumnaTabla>();
            error = "";

            if (dgvColumnas.Rows.Count == 0)
            {
                error = "Tenés que agregar al menos una columna.";
                return false;
            }

            for (int i = 0; i < dgvColumnas.Rows.Count; i++)
            {
                DataGridViewRow row = dgvColumnas.Rows[i];

                string nombre = Convert.ToString(row.Cells["colNombre"].Value)?.Trim() ?? "";
                string tipo = Convert.ToString(row.Cells["colTipo"].Value)?.Trim().ToUpperInvariant() ?? "INTEGER";

                string sLong = Convert.ToString(row.Cells["colLongitud"].Value)?.Trim() ?? "";
                string sEsc = Convert.ToString(row.Cells["colEscala"].Value)?.Trim() ?? "";

                bool notNull = Convert.ToBoolean(row.Cells["colNotNull"].Value ?? false);
                bool pk = Convert.ToBoolean(row.Cells["colPK"].Value ?? false);
                bool identity = Convert.ToBoolean(row.Cells["colIdentity"].Value ?? false);

                string def = Convert.ToString(row.Cells["colDefault"].Value)?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    error = $"La columna #{i + 1} no tiene nombre.";
                    return false;
                }

                int? longitud = null;
                int? escala = null;

                if (!string.IsNullOrWhiteSpace(sLong))
                {
                    if (!int.TryParse(sLong, out int v) || v <= 0)
                    {
                        error = $"Longitud inválida en la columna '{nombre}'.";
                        return false;
                    }
                    longitud = v;
                }

                if (!string.IsNullOrWhiteSpace(sEsc))
                {
                    if (!int.TryParse(sEsc, out int v) || v < 0)
                    {
                        error = $"Escala inválida en la columna '{nombre}'.";
                        return false;
                    }
                    escala = v;
                }

                // Validaciones básicas por tipo
                if ((tipo == "VARCHAR" || tipo == "CHAR") && longitud == null)
                {
                    error = $"El tipo {tipo} requiere longitud en la columna '{nombre}'.";
                    return false;
                }

                if ((tipo == "DECIMAL" || tipo == "NUMERIC") && (longitud == null || escala == null))
                {
                    error = $"El tipo {tipo} requiere longitud y escala en la columna '{nombre}'.";
                    return false;
                }

                // Si es PK, forzamos NOT NULL (regla típica)
                if (pk) notNull = true;

                columnas.Add(new ColumnaTabla()
                {
                    Nombre = nombre,
                    Tipo = tipo,
                    Longitud = longitud,
                    Escala = escala,
                    NotNull = notNull,
                    EsPrimaryKey = pk,
                    EsIdentity = identity,
                    Default = def
                });
            }

            // Evitar nombres repetidos
            var repetidos = columnas
                .GroupBy(c => c.Nombre, StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (repetidos.Count > 0)
            {
                error = "Hay columnas repetidas: " + string.Join(", ", repetidos);
                return false;
            }

            // Debe existir al menos una PK (si querés obligatorio)
            // Si no querés obligatorio, quitá este bloque.
            if (!columnas.Any(c => c.EsPrimaryKey))
            {
                error = "Marcá al menos una columna como PK.";
                return false;
            }

            return true;
        }

        private string GenerarDdlTabla(string esquema, string tabla, List<ColumnaTabla> columnas)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CREATE TABLE {esquema}.{tabla} (");

            // Columnas
            for (int i = 0; i < columnas.Count; i++)
            {
                var c = columnas[i];
                string tipoSql = FormatearTipo(c);

                string linea = $"    {c.Nombre} {tipoSql}";

                if (c.EsIdentity)
                {
                    linea += " GENERATED ALWAYS AS IDENTITY";
                }

                if (!string.IsNullOrWhiteSpace(c.Default))
                {
                    linea += $" DEFAULT {c.Default}";
                }

                if (c.NotNull)
                {
                    linea += " NOT NULL";
                }

                sb.Append(linea);

                // Si no es la última columna o si habrá PK después, poner coma
                sb.AppendLine(",");
            }

            // PK al final
            var pkCols = columnas.Where(x => x.EsPrimaryKey).Select(x => x.Nombre).ToList();
            sb.AppendLine($"    PRIMARY KEY ({string.Join(", ", pkCols)})");
            sb.AppendLine(");");

            return sb.ToString();
        }

        private string FormatearTipo(ColumnaTabla c)
        {
            string tipo = c.Tipo.ToUpperInvariant();

            if (tipo == "VARCHAR" || tipo == "CHAR")
            {
                return $"{tipo}({c.Longitud})";
            }

            if (tipo == "DECIMAL" || tipo == "NUMERIC")
            {
                return $"{tipo}({c.Longitud},{c.Escala})";
            }

            return tipo;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (!LeerColumnasDesdeGrid(out List<ColumnaTabla> columnas, out string error))
            {
                MessageBox.Show(error, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Columnas = columnas;
            DdlGenerado = GenerarDdlTabla(esquema, nombreTabla, columnas);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}