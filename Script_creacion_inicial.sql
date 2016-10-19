USE [GD2C2016]
GO

/*******************************************
***** CREACION DEL ESQUEMA ***************** 
********************************************/

CREATE SCHEMA [UN_CORTADO] AUTHORIZATION [gd]
GO

/*******************************************
***** CREACION DE TABLAS MASTROS (ABM) ***** 
********************************************/

CREATE TABLE [UN_CORTADO].[USUARIOS] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL PRIMARY KEY,
	[Contraseña]				VARBINARY(8000) NOT NULL,
	[Habilitado]				BIT NOT NULL DEFAULT 1,
	[Cantidad_Intentos]			TINYINT NOT NULL DEFAULT 0
)
GO

CREATE TABLE [UN_CORTADO].[CONTACTO] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Nombre]					VARCHAR(255) NOT NULL,
	[Apellido]					VARCHAR(255) NOT NULL,
	[Tipo_Documento]			VARCHAR(20) NOT NULL,
	[Numero_Documento]			NUMERIC(18,0) NOT NULL,
	[Direccion]					VARCHAR(255) NOT NULL,
	[Telefono]					NUMERIC(18,0) NULL,
	[Mail]						VARCHAR(255) NULL,
	[Fecha_Nacimiento]			DATETIME NOT NULL,
	
	PRIMARY KEY ([Nombre_Usuario])	
)
GO

CREATE TABLE [UN_CORTADO].[ROLES] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre]					VARCHAR(50) NOT NULL,
	[Estado]					BIT NOT NULL
)
GO

CREATE TABLE [UN_CORTADO].[ROLPORUSUARIO] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Id_Rol]					INT NOT NULL REFERENCES [UN_CORTADO].[ROLES]

)
GO

CREATE TABLE [UN_CORTADO].[FUNCIONES] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre]					VARCHAR(50) NOT NULL	
)
GO

CREATE TABLE [UN_CORTADO].[FUNCIONESPORROL] (
	[Id_Funcion]				INT NOT NULL REFERENCES [UN_CORTADO].[FUNCIONES],
	[Id_Rol]					INT NOT NULL REFERENCES [UN_CORTADO].[ROLES]
)
GO

CREATE TABLE [UN_CORTADO].[PLANES] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre]					VARCHAR(50) NOT NULL,	
	[Abono]						INT NOT NULL
)
GO

CREATE TABLE [UN_CORTADO].[AFILIADOS] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Numero_Afiliado]			INT NOT NULL,
	[Numero_Familia]			TINYINT NOT NULL DEFAULT 0,
	[Estado_Civil]				VARCHAR(20) NOT NULL,
	[Cantidad_Hijos]			TINYINT NOT NULL DEFAULT 0,
	[Id_Plan]					INT NOT NULL REFERENCES [UN_CORTADO].[PLANES],

	PRIMARY KEY ([Nombre_Usuario])	
)
GO

CREATE TABLE [UN_CORTADO].[BONOS] (
	[Id]						NUMERIC(18,0) NOT NULL PRIMARY KEY,
	[Numero_Consulta_Medica]	INT NOT NULL,	
	[Nombre_Usuario_Compra]		VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Fecha_Uso]					DATETIME NOT NULL,
	[Numero_Familiar]			INT NOT NULL,
	[Plan]						VARCHAR(30) NOT NULL,
	[Nombre_Usuario_Uso]		VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Habilitado]				BIT NOT NULL
)
GO

CREATE TABLE [UN_CORTADO].[COMPRABONOS] (
	[Id]						NUMERIC(18,0) NOT NULL PRIMARY KEY,
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Cantidad_Bonos]			INT NOT NULL,
	[Precio_Total]				INT NOT NULL,
	[Fecha_Compra]				DATETIME NOT NULL DEFAULT GETDATE()	
)
GO

CREATE TABLE [UN_CORTADO].[MODIFICACIONES] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Detalle]					VARCHAR(50) NULL,
	[Fecha]						DATETIME NOT NULL DEFAULT GETDATE()
)
GO

CREATE TABLE [UN_CORTADO].[PROFESIONALES] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Matricula]					INT NOT NULL,	

	PRIMARY KEY ([Nombre_Usuario])	
)
GO

CREATE TABLE [UN_CORTADO].[TURNOSASIGNADOS] (
	[Id]						INT NOT NULL PRIMARY KEY,
	[Id_Afiliado]				VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Id_Medico]					VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],		
	[Hora_Inicio]				TIME NOT NULL,
	[Hora_Fin]					TIME NOT NULL,
	[Fecha]						DATE NOT NULL,
	[Numero]					INT NOT NULL,
	[Hora_Llegada]				TIME NOT NULL,
	[Bono_Usado]				NUMERIC(18,0) NOT NULL REFERENCES [UN_CORTADO].[BONOS],		
	[Especialidad]				VARCHAR(30) NOT NULL,
	[Habilitado]				BIT NOT NULL
)
GO



CREATE TABLE [UN_CORTADO].[HISTORIACLINICA] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	[Nombre_Profecional]		VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],
	[Enfermedad]				VARCHAR(255) NOT NULL,
	[Sintomas]					VARCHAR(255) NOT NULL,
	[Diagnosticos]				VARCHAR(30) NOT NULL,		
	[Fecha_Hora]				DATETIME NOT NULL,
	[Nombre_Afiliado]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],
)
GO

CREATE TABLE [UN_CORTADO].[CANCELACIONES] (
	[Id]						INT NOT NULL PRIMARY KEY,
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Id_Turno]					INT NOT NULL REFERENCES [UN_CORTADO].[TURNOSASIGNADOS],
	[Detalle]					VARCHAR(30) NOT NULL,
	[Tipo]						VARCHAR(30) NOT NULL,
	[Especialidad]				VARCHAR(30) NOT NULL,
	[Fecha_Cancelacion]			DATETIME NOT NULL DEFAULT GETDATE()	
)
GO

CREATE TABLE [UN_CORTADO].[AGENDA] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	[Dia_Atencion]				INT NOT NULL,
	[Id_Medico]					VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],
	[Fecha_Desde]				DATETIME NOT NULL,
	[Fecha_Hasta]				DATETIME NOT NULL,
	[Hora_Inicio]				TIME NOT NULL,
	[Hora_Fin]					TIME NOT NULL
)
GO

CREATE TABLE [UN_CORTADO].[TURNOS] (
	[Id]						INT NOT NULL PRIMARY KEY,	
	[Id_Medico]					VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],
	[Hora_Inicio]				TIME NOT NULL,
	[Hora_Fin]					TIME NOT NULL,
	[Fecha]						DATE NOT NULL,
	[Especialidad]				VARCHAR(30) NOT NULL
)
GO

CREATE TABLE [UN_CORTADO].[TIPOESPECIALIDAD] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	[Nombre]					VARCHAR(255) NOT NULL	
)
GO

CREATE TABLE [UN_CORTADO].[ESPECIALIDADES] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	[Nombre]					VARCHAR(255) NOT NULL,
	[Tipo]						INT NOT NULL REFERENCES [UN_CORTADO].[TIPOESPECIALIDAD]
)
GO

CREATE TABLE [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] (
	[Id_Especialidad]			INT NOT NULL REFERENCES [UN_CORTADO].[ESPECIALIDADES],
	[Id_Medico]					Varchar(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],

	PRIMARY KEY ([Id_Especialidad], [Id_Medico])
)
GO

/*******************************************
***** POBLADO DE TABLAS ******************** 
********************************************/

INSERT INTO [UN_CORTADO].[USUARIOS] (Nombre_Usuario, Contraseña, Habilitado, Cantidad_Intentos)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'), 1, 1), ('a', HASHBYTES('SHA2_256', 'a'), 1, 1)

INSERT INTO [UN_CORTADO].[ROLES] (Nombre, Estado)
VALUES ('Administrativo', 1), ('Profesional', 1), ('Afiliado', 1)

INSERT INTO [UN_CORTADO].[ROLPORUSUARIO] (Nombre_Usuario, Id_Rol)
VALUES ('admin', 1), ('admin', 2), ('admin', 3), ('a', 3)

INSERT INTO [UN_CORTADO].[FUNCIONES] (Nombre)
VALUES ('Registrar agenda del medico'), ('Registro de llegada para atencion medica'), ('ABM Profesional'), ('ABM Rol'),
	('Registrar resultado para atencion medica'), ('ABM Especialidades Medicas'), ('ABM Afiliado'), ('ABM Plan'),
	('Cancelar atencion medica'), ('Registro de Usuario'), ('Compra de bonos'), ('Pedir Turno')

--INSERT INTO [UN_CORTADO].[FUNCIONESPORROL] (Id_Funcion, Id_Rol)
--VALUES (1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1),
--	   (8, 1), (9, 1), (10, 1), (11, 1), (12, 1), (11, 3), (12, 3)