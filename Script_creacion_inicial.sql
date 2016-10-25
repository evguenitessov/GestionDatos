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
	[Contrase�a]				VARBINARY(8000) NOT NULL,
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
	[Fecha_Nacimiento]			DATE NOT NULL,
	
	PRIMARY KEY ([Nombre_Usuario])	
)
GO

CREATE TABLE [UN_CORTADO].[ROLES] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre]					VARCHAR(50) NOT NULL,
	[Estado]					BIT DEFAULT 1
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
	[Abono]						INT DEFAULT 0,
	[Precio_Bono_Consulta]		INT NOT NULL,
	[Precio_Bono_Farmacia]		INT NOT NULL
	)
GO

CREATE TABLE [UN_CORTADO].[AFILIADOS] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Numero_Afiliado]			INT IDENTITY(1,1),
	[Numero_Familia]			TINYINT NOT NULL DEFAULT 0,
	[Estado_Civil]				VARCHAR(20) NOT NULL DEFAULT 'SOLTERO',
	[Cantidad_Hijos]			TINYINT NOT NULL DEFAULT 0,
	[Id_Plan]					INT NOT NULL REFERENCES [UN_CORTADO].[PLANES],

	PRIMARY KEY ([Nombre_Usuario])	
)
GO

CREATE TABLE [UN_CORTADO].[COMPRABONOS] (
	[Id]						INT IDENTITY(1,1) PRIMARY KEY,
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Cantidad_Bonos]			INT NOT NULL DEFAULT 1,
	[Precio_Total]				INT NOT NULL DEFAULT 0,
	[Fecha_Compra]				DATETIME NOT NULL DEFAULT GETDATE()	
)
GO

CREATE TABLE [UN_CORTADO].[BONOS] (
	[Id]						NUMERIC(18,0) IDENTITY(1,1) PRIMARY KEY,
	[Numero_Consulta_Medica]	INT NOT NULL DEFAULT 0,	
	[Id_Compra_Bono]		    INT NOT NULL REFERENCES [UN_CORTADO].[COMPRABONOS],	
	[Numero_Familiar]			INT NOT NULL,
	[Plan]						VARCHAR(30) NOT NULL,
	[Fecha_Uso]					DATETIME,
	[Nombre_Usuario_Uso]		VARCHAR(30) REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Habilitado]				BIT DEFAULT 1
)
GO

CREATE TABLE [UN_CORTADO].[MODIFICACIONES] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],	
	[Detalle]					VARCHAR(50) NULL,
	[Fecha]						DATETIME NOT NULL DEFAULT GETDATE(),
	[Plan_Anterior]				VARCHAR(50) NOT NULL,	
)
GO

CREATE TABLE [UN_CORTADO].[PROFESIONALES] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Matricula]					INT NOT NULL,	

	PRIMARY KEY ([Nombre_Usuario])	
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
	[Id_Tipo]					INT NOT NULL REFERENCES [UN_CORTADO].[TIPOESPECIALIDAD]
)
GO

CREATE TABLE [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Id_Especialidad]			INT NOT NULL REFERENCES [UN_CORTADO].[ESPECIALIDADES],
	[Id_Medico]					Varchar(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],
)
GO

CREATE TABLE [UN_CORTADO].[AGENDA] (
	[Id]						INT IDENTITY(1,1) PRIMARY KEY,	
	[Dia_Atencion]				INT NOT NULL,
	[Id_Especialidad_Medico]	INT NOT NULL REFERENCES [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL],
	[Fecha_Desde]				DATE NOT NULL,
	[Fecha_Hasta]				DATE NOT NULL,
	[Hora_Inicio]				TIME NOT NULL,
	[Hora_Fin]					TIME NOT NULL
)
GO

CREATE TABLE [UN_CORTADO].[TURNOS] (                        --@NUMERO PARA QUE ES ESTE CAMPO
	[Id]						INT IDENTITY(1,1) PRIMARY KEY,	
	[Id_Agenda]					INT NOT NULL REFERENCES [UN_CORTADO].[AGENDA],
	[Hora_Inicio]				TIME NOT NULL,
	[Hora_Fin]					TIME NOT NULL,
	[Fecha]						DATE NOT NULL,
	[Especialidad]				VARCHAR(30) NOT NULL,
	[Disponible]				BIT DEFAULT 1,
	[Id_Afiliado]				VARCHAR(30) REFERENCES [UN_CORTADO].[AFILIADOS],	
	--[Numero]					INT NOT NULL,
	[Hora_Llegada_Afiliado]		TIME DEFAULT NULL,
	[Bono_Usado]				NUMERIC(18,0) REFERENCES [UN_CORTADO].[BONOS]	
)
GO

CREATE TABLE [UN_CORTADO].[ATENCIONMEDICA] (
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	[Nombre_Profecional]		VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],
	[Enfermedad]				VARCHAR(255) NOT NULL,
	[Sintomas]					VARCHAR(255) NOT NULL,
	[Diagnosticos]				VARCHAR(30) NOT NULL,		
	[Fecha_Hora]				DATETIME NOT NULL,
	[Nombre_Afiliado]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],
	[�d_turno]			        INT NOT NULL REFERENCES [UN_CORTADO].[TURNOS],
)
GO

CREATE TABLE [UN_CORTADO].[CANCELACIONES] (
	[Id]						INT IDENTITY(1,1) PRIMARY KEY,
	[Nombre_Usuario]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[USUARIOS],
	[Id_Turno]					INT NOT NULL REFERENCES [UN_CORTADO].[TURNOS],
	[Detalle]					VARCHAR(30) NOT NULL,
	[Tipo]						VARCHAR(30) NOT NULL,
	[Fecha_Cancelacion]			DATETIME NOT NULL DEFAULT GETDATE()	
)
GO

--/*******************************************    @OBS ANTES DE INSETAR EN AGENDA VALIDAR 40 HS SEM y VALIDAR EL RANGO HORARIO
--***** TRIGGERS CREACION ********************		OSEA SOLO MOSTRAR LO DISPONIBLE
--********************************************/

CREATE TRIGGER CARGAR_TURNOS_TRIGGER ON UN_CORTADO.AGENDA AFTER INSERT AS
	DECLARE @Id_Agenda int;
	DECLARE @Dia_Atencion int;
	DECLARE @Id_Especialidad_Medico Int;
	DECLARE @Fecha_Desde DATE;
	DECLARE @Fecha_Hasta DATE;
	DECLARE @Fecha_Aux DATE;
	DECLARE @Hora_Inicio TIME;
	DECLARE @Hora_Fin TIME;
	DECLARE @Hora_Aux_Inicio TIME;
	DECLARE @Hora_Aux_Fin TIME;
	DECLARE @Especialidad varchar(30);

  --SET @Hora_Sem_Inicio = '07:00.0000000';		--Horario INICIO SEMANAL	07:00
  --SET @Hora_Sem_Fin = '20:00.0000000';		--Horario FIN SEMANAL		20:00
  --SET @Hora_FinSem_Inicio = '10:00.0000000';	--Horario INICIO SABADOS	10:00
  --SET @Hora_FinSem_Fin = '15:00.0000000';		--Horario FIN SABADOS		15:00
  --WHEN DATEPART(dw,getdate()) = 1    then 'Domingo' 
  --WHEN DATEPART(dw,getdate()) = 2    then 'Lunes'
  --when DATEPART(dw,getdate()) = 3    then 'Martes'
  --WHEN DATEPART(dw,getdate()) = 4    then 'Miercoles'
  --WHEN DATEPART(dw,getdate()) = 5    then 'Jueves'
  --WHEN DATEPART(dw,getdate()) = 6    then 'Viernes'
  --WHEN DATEPART(dw,getdate()) =     then 'Sabado'

	SELECT  @Id_Agenda=(Id) FROM INSERTED
	SELECT  @Dia_Atencion=(Dia_atencion) FROM INSERTED
	SELECT  @Id_Especialidad_Medico=(Id_Especialidad_Medico) FROM INSERTED
	SELECT  @Fecha_Desde=(Fecha_Desde) FROM INSERTED
	SELECT  @Fecha_Hasta=(Fecha_Hasta) FROM INSERTED
	SELECT  @Hora_Inicio=(Hora_Inicio) FROM INSERTED
	SELECT  @Hora_Fin=(Hora_Fin) FROM INSERTED

	SET @Especialidad = (SELECT Id_Especialidad FROM [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] 
							WHERE @Id_Especialidad_Medico = Id)
	SET @Fecha_Aux = @Fecha_Desde
	
	
	WHILE (@Fecha_Aux <= @Fecha_Hasta)
	BEGIN
		
		IF @Dia_Atencion = DATEPART(dw,@Fecha_Aux) 		 --Verifico que sea el dia que atiende el Medico
		BEGIN
			SET @Hora_Aux_Inicio = @Hora_Inicio
			WHILE (@Hora_Aux_Inicio <= @Hora_Fin)
			BEGIN  
				SET @Hora_Aux_Fin = DATEADD(minute,30,@Hora_Aux_Inicio) --Suma 30 minutos el turno --
				INSERT INTO [UN_CORTADO].[TURNOS] ([Id_Agenda],[Hora_Inicio],[Hora_Fin],[Fecha],[Especialidad])
				VALUES
				   (@Id_Agenda
				   ,@Hora_Aux_Inicio
				   ,@Hora_Aux_Fin
				   ,@Fecha_Aux
				   ,@Especialidad)
				IF (@Hora_Aux_Fin = @Hora_Fin) 
				BEGIN
					SET @Fecha_Aux = DATEADD(DAY,1,@Fecha_Aux)
					BREAK 
				END   --EN IF
				ELSE 
				BEGIN
					SET @Hora_Aux_Inicio = @Hora_Aux_Fin  
					CONTINUE  
				END --ELSE
			END  -- END WHILE 2
		END   -- IF
		ELSE
		SET @Fecha_Aux = DATEADD(DAY,1,@Fecha_Aux)
	END --END 1 WHILE
GO

--/*******************************************
--***** POBLADO DE TABLAS ******************** 
--********************************************/
CREATE PROCEDURE [UN_CORTADO].[MIGRACION]
AS
BEGIN

--Declaracion de variables
DECLARE @DNI numeric (18,0)

--LOAD TABLA [ROLES]
INSERT INTO [UN_CORTADO].[ROLES] (Nombre)
	VALUES ('Administrativo'), ('Profesional'), ('Afiliado')
--LOAD TABLA [FUNCIONES]
INSERT INTO [UN_CORTADO].[FUNCIONES] (Nombre)
	VALUES ('Registrar agenda del medico'), ('Registro de llegada para atencion medica'), ('ABM Profesional'), ('ABM Rol'),
		('Registrar resultado para atencion medica'), ('ABM Especialidades Medicas'), ('ABM Afiliado'), ('ABM Plan'),
		('Cancelar atencion medica'), ('Registro de Usuario'), ('Compra de bonos'), ('Pedir Turno')
--LOAD TABLA [FUNCIONESPORROL]
INSERT INTO [UN_CORTADO].[FUNCIONESPORROL] (Id_Funcion, Id_Rol)
	VALUES (1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1),
		   (8, 1), (9, 1), (10, 1), (11, 1), (12, 1), (11, 3), (12, 3)
--LOAD DE TABLA [TIPOESPECIALIDAD]
SET IDENTITY_INSERT [UN_CORTADO].[TIPOESPECIALIDAD] ON
INSERT INTO [UN_CORTADO].[TIPOESPECIALIDAD]
           ([Id]
           ,[Nombre])
    SELECT DISTINCT(Tipo_Especialidad_Codigo),(Tipo_Especialidad_Descripcion) FROM gd_esquema.Maestra
	WHERE Tipo_Especialidad_Codigo IS NOT NULL
	ORDER BY 1
SET IDENTITY_INSERT [UN_CORTADO].[TIPOESPECIALIDAD] OFF
--LOAD DE TABLA [ESPECIALIDADES]
SET IDENTITY_INSERT [UN_CORTADO].[ESPECIALIDADES] ON
INSERT INTO [UN_CORTADO].[ESPECIALIDADES]
           ([Id]
           ,[Nombre]
		   ,[Id_Tipo])
	SELECT DISTINCT[Especialidad_Codigo]
      ,[Especialidad_Descripcion]
	  ,[Tipo_Especialidad_Codigo]
    FROM [GD2C2016].[gd_esquema].[Maestra] 
	WHERE Especialidad_Codigo IS NOT NULL
	ORDER BY 1 
SET IDENTITY_INSERT [UN_CORTADO].[ESPECIALIDADES] OFF
-- LOAD TABLA [USUARIOS]  --
INSERT INTO [UN_CORTADO].[USUARIOS] (Nombre_Usuario, Contrase�a)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO [UN_CORTADO].[USUARIOS]
           ([Nombre_Usuario]
           ,[Contrase�a])
	SELECT DISTINCT [Paciente_Dni],HASHBYTES('SHA2_256','123456')
    FROM [GD2C2016].[gd_esquema].[Maestra] 
	UNION
	SELECT DISTINCT [Medico_dni],HASHBYTES('SHA2_256', '123456')
    FROM [GD2C2016].[gd_esquema].[Maestra] 
	WHERE Medico_Dni IS NOT NULL
	ORDER BY 1
--LOAD TABLA [ROLPORUSUARIO]
INSERT INTO [UN_CORTADO].[ROLPORUSUARIO] (Nombre_Usuario, Id_Rol)
	VALUES ('admin', 1), ('admin', 2), ('admin', 3)
--LOAD TABLA [CONTACTO]
INSERT INTO [UN_CORTADO].[CONTACTO]
           ([Nombre_Usuario]
           ,[Nombre]
           ,[Apellido]
           ,[Tipo_Documento]
           ,[Numero_Documento]
           ,[Direccion]
           ,[Telefono]
           ,[Mail]
           ,[Fecha_Nacimiento])
    SELECT DISTINCT [Paciente_Dni],[Paciente_Nombre],[Paciente_Apellido],'DNI',[Paciente_Dni],[Paciente_Direccion],[Paciente_Telefono],[Paciente_Mail],[Paciente_Fecha_Nac]
    FROM [GD2C2016].[gd_esquema].[Maestra] 
	UNION
	SELECT DISTINCT [Medico_Dni],[Medico_Nombre],[Medico_Apellido],'DNI',[Medico_Dni],[Medico_Direccion],[Medico_Telefono],[Medico_Mail],[Medico_Fecha_Nac]
    FROM [GD2C2016].[gd_esquema].[Maestra] 
	WHERE Medico_Dni IS NOT NULL
	ORDER BY 1
--LOAD TABLA [PLANES]
SET IDENTITY_INSERT [UN_CORTADO].[PLANES] ON
INSERT INTO [UN_CORTADO].[PLANES]
           ([Id]
		   ,[Nombre]
           ,[Precio_Bono_Consulta]
           ,[Precio_Bono_Farmacia])
    SELECT DISTINCT [Plan_Med_Codigo]
		,[Plan_Med_Descripcion]
		,[Plan_Med_Precio_Bono_Consulta]
        ,[Plan_Med_Precio_Bono_Farmacia]  
  FROM [GD2C2016].[gd_esquema].[Maestra]
SET IDENTITY_INSERT [UN_CORTADO].[PLANES] OFF
--LOAD TABLA AFILIADOS
INSERT INTO [UN_CORTADO].[AFILIADOS]
           ([Nombre_Usuario]
		   ,[Id_Plan])
	SELECT  DISTINCT [Paciente_Dni],[Plan_Med_Codigo]
    FROM [GD2C2016].[gd_esquema].[Maestra]
	ORDER BY 1
--LOAD TABLA [COMPRABONOS]    @FALTA VER EL TEMA DE CALCULAR EL COSTO TOTAL
INSERT INTO [UN_CORTADO].[COMPRABONOS]
           ([Nombre_Usuario]
           ,[Cantidad_Bonos]
           ,[Fecha_Compra])
SELECT [Paciente_Dni], COUNT ( * ), Compra_Bono_Fecha
  FROM [GD2C2016].[gd_esquema].[Maestra]
  WHERE Compra_Bono_Fecha IS NOT NULL
  GROUP BY Paciente_Dni,Compra_Bono_Fecha
  ORDER BY 1,3
--LOAD TABLA [BONOS]
SET IDENTITY_INSERT [UN_CORTADO].[BONOS] ON
INSERT INTO [UN_CORTADO].[BONOS]
           ([Id]
           ,[Numero_Consulta_Medica]
           ,[Id_Compra_Bono]
           ,[Fecha_Uso]
           ,[Numero_Familiar]
           ,[Plan]
           ,[Nombre_Usuario_Uso]
           ,[Habilitado])
SELECT DISTINCT M.Bono_Consulta_Numero,1, C.id,M.Bono_Consulta_Fecha_Impresion,0,A.Id_Plan,C.Nombre_Usuario,1
  FROM [GD2C2016].[gd_esquema].[Maestra] AS M
  JOIN [UN_CORTADO].[COMPRABONOS] AS C
  ON M.Paciente_Dni = C.Nombre_Usuario AND C.Fecha_Compra = M.Compra_Bono_Fecha 
  JOIN [UN_CORTADO].[AFILIADOS] AS A
  ON A.Nombre_Usuario = M.Paciente_Dni	
  WHERE M.Bono_Consulta_Fecha_Impresion IS NOT NULL
  ORDER BY 1
SET IDENTITY_INSERT [UN_CORTADO].[BONOS] OFF
--LOAD TABLA [PROFESIONALES]    @VERIFICAR EL TEMA DE LA MATRICULA   
INSERT INTO [UN_CORTADO].[PROFESIONALES]
           ([Nombre_Usuario]
           ,[Matricula])
SELECT DISTINCT[Medico_Dni],00000
FROM [GD2C2016].[gd_esquema].[Maestra]
WHERE Medico_Dni  IS NOT NULL
ORDER BY 1
--LOAD TABLA [ESPECIALIDADPORPROFESIONAL]
INSERT INTO [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL]
           ([Id_Especialidad]
           ,[Id_Medico])
SELECT DISTINCT Especialidad_Codigo,Medico_Dni
FROM [GD2C2016].[gd_esquema].[Maestra] 
WHERE Medico_Dni is not null
ORDER BY 2
--LOAD TABLA [AGENDA] Y TURNOS POR MEDIO DE TRIGGER  @VERIFICAR CARGA 145600 REGISTROS PERO TRIGGER EJECUTA UNA VEZ
INSERT INTO [UN_CORTADO].[AGENDA]
           ([Dia_Atencion]
           ,[Id_Especialidad_Medico]
           ,[Fecha_Desde]
           ,[Fecha_Hasta]
           ,[Hora_Inicio]
           ,[Hora_Fin])
SELECT DISTINCT DATEPART(dw,[Turno_Fecha]),EM.Id,[Turno_Fecha],[Turno_Fecha],[Turno_Fecha],DATEADD(minute,30,[Turno_Fecha])
FROM [GD2C2016].[gd_esquema].[Maestra] 
INNER JOIN [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] AS EM
ON EM.Id_Especialidad = [Especialidad_Codigo] AND EM.Id_Medico = [Medico_Dni]
ORDER BY 3
--LOAD TABLA [TURNOS]


--LOAD TABLA [AGENDA] 3 DATOS AL AZAR

--INSERT INTO [UN_CORTADO].[AGENDA]
--           ([Dia_Atencion]
--           ,[Id_Especialidad_Medico]
--           ,[Fecha_Desde]
--           ,[Fecha_Hasta]
--           ,[Hora_Inicio]
--           ,[Hora_Fin])
--     VALUES
--           (1,
--            1,
--            '2016-10-15', 
--			'2016-12-20', 
--			'10:00:00.0000000', 
--			'12:00:00.0000000')  

--INSERT INTO [UN_CORTADO].[AGENDA]
--           ([Dia_Atencion]
--           ,[Id_Especialidad_Medico]
--           ,[Fecha_Desde]
--           ,[Fecha_Hasta]
--           ,[Hora_Inicio]
--           ,[Hora_Fin])
--     VALUES
--           (2,
--            2,
--            '2016-10-15', 
--			'2016-12-20', 
--			'12:00:00.0000000', 
--			'14:00:00.0000000') 

--INSERT INTO [UN_CORTADO].[AGENDA]
--           ([Dia_Atencion]
--           ,[Id_Especialidad_Medico]
--           ,[Fecha_Desde]
--           ,[Fecha_Hasta]
--           ,[Hora_Inicio]
--           ,[Hora_Fin])
--     VALUES
--           (2,
--            30,
--            '2016-10-15', 
--			'2016-12-20', 
--			'15:00:00.0000000', 
--			'17:00:00.0000000') 

END
GO

-- MIGRACION DE DATOS
BEGIN
	EXECUTE [UN_CORTADO].[MIGRACION]
END
GO