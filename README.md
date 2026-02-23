# ProyectoDB2 – Database Manager para IBM DB2

## Descripción

Proyecto individual desarrollado para la clase de Teoría de Bases de Datos 2.

La aplicación consiste en un gestor gráfico para IBM DB2 que permite conectarse a una base de datos, explorar sus objetos, ejecutar consultas SQL, visualizar DDL de distintos tipos de objetos y crear tablas y vistas mediante asistentes (wizards).

El proyecto fue desarrollado en C# utilizando WinForms y trabaja directamente contra el motor DB2 sin utilizar datos simulados.

---

## Tecnologías utilizadas

- C#
- .NET (WinForms)
- IBM DB2
- ADO.NET
- Catálogo del sistema DB2 (SYSCAT)

---

## Funcionalidades implementadas

### 1. Conexión a DB2

- Inicio de sesión mediante parámetros de conexión.
- Guardado de conexiones (sin almacenar contraseñas por motivos de seguridad).
- Validación real contra el servidor DB2.

---

### 2. Navegador de objetos (TreeView)

El navegador carga dinámicamente desde el catálogo `SYSCAT` los siguientes objetos:

- Esquemas
- Tablas
- Vistas
- Índices
- Triggers
- Secuencias
- Paquetes
- Tablespaces (globales)
- Usuarios (globales)

Todos los objetos se obtienen directamente desde la base de datos activa.

---

### 3. Visualización de DDL

Se implementó la generación de DDL para los siguientes objetos:

- Tablas
- Vistas
- Índices
- Triggers
- Secuencias

El DDL se reconstruye utilizando información almacenada en las tablas del catálogo del sistema (`SYSCAT`).

El usuario puede:

- Visualizar el DDL en modo solo lectura.
- Exportarlo al editor SQL.
- Ejecutarlo manualmente si lo desea.

---

### 4. Objetos sin DDL implementado

No se implementó la generación de DDL para:

- Procedimientos almacenados
- Funciones
- Usuarios
- Tablespaces

**Motivo:**  
DB2 no expone fácilmente la definición estructurada completa de estos objetos desde el catálogo sin utilizar herramientas externas o mecanismos adicionales no contemplados dentro del alcance del proyecto.

Estas limitaciones están documentadas en el archivo `Documento_Limitaciones.pdf`.

---

### 5. Editor SQL

El sistema permite:

- Ejecutar consultas `SELECT` y mostrar resultados en un `DataGridView`.
- Ejecutar comandos `INSERT`, `UPDATE`, `DELETE`, `CREATE`, entre otros.
- Mostrar mensajes con timestamp.
- Detectar automáticamente si la sentencia es de tipo `SELECT`.

---

### 6. Wizard para Crear Tabla

Se implementó un asistente en múltiples pasos que permite:

- Seleccionar esquema.
- Definir nombre de la tabla.
- Agregar columnas dinámicamente.
- Generar el DDL correspondiente.
- Enviar el DDL al editor SQL para su ejecución manual.

---

### 7. Wizard para Crear Vista

Se implementó un asistente que permite:

- Seleccionar esquema.
- Seleccionar tabla base.
- Elegir columnas mediante una interfaz de selección dual (disponibles / incluidas).
- Generar automáticamente el DDL correspondiente.

---

### Conclusión

El proyecto cumple con los requerimientos solicitados:
- Interfaz gráfica funcional.
- Exploración real de metadatos.
- Generación de DDL para múltiples tipos de objetos.
- Ejecución de consultas SQL.
- Creación asistida de tablas y vistas.
- Validación real de restricciones por parte del motor DB2.

La aplicación trabaja directamente contra una base de datos DB2 real y no utiliza datos simulados.
