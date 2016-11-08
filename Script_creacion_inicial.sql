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
	[Genero]					CHAR(1) NULL,
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
	[Numero_Afiliado]			INT NOT NULL,
	[Numero_Familia]			TINYINT NOT NULL DEFAULT 0,
	[Estado_Civil]				VARCHAR(20) NOT NULL DEFAULT 'SOLTERO/A',
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

CREATE TABLE [UN_CORTADO].[ATENCIONMEDICA] (   --@DIAGNOSTICO DE DONDE SE SACA
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	[Nombre_Profecional]		VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[PROFESIONALES],
	[Enfermedad]				VARCHAR(255) NOT NULL,
	[Sintomas]					VARCHAR(255) NOT NULL,
	[Diagnosticos]				VARCHAR(30) NULL,		
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

CREATE TABLE [UN_CORTADO].[#TMP1] (
	[Nombre_Usuario]			VARCHAR(30) NOT NULL,
	[Numero_Afiliado]			INT IDENTITY (1,1),
	[Numero_Familia]			TINYINT NOT NULL DEFAULT 0,
	[Estado_Civil]				VARCHAR(20) NOT NULL DEFAULT 'SOLTERO/A',
	[Cantidad_Hijos]			TINYINT NOT NULL DEFAULT 0,
	[Id_Plan]					INT NOT NULL ,

	PRIMARY KEY ([Nombre_Usuario])	
)
GO
--/***********************************************    
--***** FUNCION CONTROL 48 HS SEMANALES **********		
--************************************************/
CREATE FUNCTION [UN_CORTADO].[CONTROL_HORAS] (@Id_Especialidad_Medico Int,@Fecha_Desde DATE,@Fecha_Hasta DATE,@CantHoras INT) RETURNS int AS
BEGIN
	DECLARE @Week_Inicial	INT
	DECLARE @Week_Hasta		INT
	DECLARE @Week_Aux		INT
	DECLARE @Horas_Sem		INT
	DECLARE @Return			INT
	
	SET @Week_Inicial= DATEPART(wk,@Fecha_Desde)
	SET @Week_Hasta= DATEPART(wk,@Fecha_Hasta)
	SET @Week_Aux = @Week_Inicial
	SET @Horas_Sem = 0

	WHILE @Week_Aux<=@Week_Hasta	
	BEGIN
		SET @Horas_Sem =  (SELECT COUNT (*) / 2
		FROM [GD2C2016].[UN_CORTADO].[TURNOS]
		INNER JOIN [UN_CORTADO].[AGENDA] AS A
	    ON   [Id_Agenda]=A.[Id] AND @Id_Especialidad_Medico=A.Id_Especialidad_Medico
		WHERE DATEPART(wk,[Fecha])=@Week_Aux AND DATEPART(YY,[Fecha]) = DATEPART(yy,@Fecha_Desde)
		GROUP BY DATEPART(wk,[Fecha]),A.[Id_Especialidad_Medico])+@CantHoras
		SET @Week_Aux = @Week_Aux + 1
		IF 	@Horas_Sem <=48
		BEGIN
		  SET @Week_Aux = @Week_Aux + 1
		  SET @Return = 1
		  CONTINUE
		END  -- IF
		ELSE
		BEGIN
			SET @Return = 0
			BREAK
		END --ELSE
	END --WHILE
	RETURN @Return 
END --FUNCTION
GO

--/***********************************************    
--***** FUNCION CONTROL AGENDA EXISTENTE **********		
--************************************************/
CREATE FUNCTION [UN_CORTADO].[CONTROL_AGENDA_EXISTENTE] (@Id_Especialidad_Medico Int,@Fecha_Desde DATE) 
RETURNS int AS
BEGIN

declare @retorno int

if exists( SELECT 1 
		   FROM [GD2C2016].[UN_CORTADO].[TURNOS] 
		   INNER JOIN [UN_CORTADO].[AGENDA] AS A 
		   ON [Id_Agenda]=A.[Id] AND @Id_Especialidad_Medico = A.Id_Especialidad_Medico 
		   WHERE DATEPART(wk,[Fecha])=DATEPART(wk,@Fecha_Desde) AND DATEPART(YY,[Fecha]) = DATEPART(yy,@Fecha_Desde) 
		   GROUP BY DATEPART(wk,[Fecha]),A.[Id_Especialidad_Medico] ) 
			set @retorno = 1 
else 
	set @retorno = 0

RETURN @retorno

END
GO

--/***********************************************    @OBS ANTES DE INSETAR EN AGENDA VALIDAR 40 HS SEM y VALIDAR EL RANGO HORARIO
--***** PROCEDURE CARGA AGENDA********************		OSEA SOLO MOSTRAR LO DISPONIBLE
--************************************************/
CREATE PROCEDURE [UN_CORTADO].[CARGAR_AGENDA] (@Dia_Atencion int,@Id_Especialidad_Medico Int,@Fecha_Desde DATE,@Fecha_Hasta DATE,@Hora_Inicio TIME,@Hora_Fin TIME) AS 
BEGIN

BEGIN TRAN 

	DECLARE @Id_Agenda int;
	DECLARE @Fecha_Aux DATE;
	DECLARE @Hora_Aux_Inicio TIME;
	DECLARE @Hora_Aux_Fin TIME;
	DECLARE @Especialidad varchar(30);
	
	
	INSERT INTO [UN_CORTADO].[AGENDA]
	       ([Dia_Atencion]
           ,[Id_Especialidad_Medico]
           ,[Fecha_Desde]
           ,[Fecha_Hasta]
           ,[Hora_Inicio]
           ,[Hora_Fin])
     VALUES
           (@Dia_Atencion
           ,@Id_Especialidad_Medico
		   ,@Fecha_Desde
           ,@Fecha_Hasta
           ,@Hora_Inicio
           ,@Hora_Fin)

	SET @Id_Agenda = @@IDENTITY  	       --@ NO SE SI ES LA MEJOR MANERA DE RESOLVERLO
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
				IF (@Hora_Aux_Fin >= @Hora_Fin) 
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
COMMIT TRAN
END --PROCEDURE
GO

-- PROCEDURE TOP5_ESPECIALIDADES MAS CANCELADAS LISTADO ESTADISTICO 1

CREATE PROCEDURE [UN_CORTADO].[TOP5_ESPECIALIDADES_CAN]  (@SEMESTRE INT,@YEAR INT) AS
BEGIN
	IF @SEMESTRE = 1 
	BEGIN
	  SELECT  TOP 5 E.Nombre ESPECIALIDADES,COUNT(*) AS CANT_CANCELACIONES 
		  FROM [GD2C2016].[UN_CORTADO].[CANCELACIONES] C
	  INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
	  ON C.Id_Turno = T.Id
	  INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
	  ON T.Especialidad = E.Id
	  WHERE DATEPART(YY,T.Fecha) = @YEAR AND
			DATEPART(MM,T.Fecha) IN (1,2,3,4,5,6)
	  GROUP BY T.Especialidad,E.Nombre
	  ORDER BY COUNT(*) DESC
	END --IF
	IF @SEMESTRE = 2 
	BEGIN
	  SELECT  TOP 5 E.Nombre ESPECIALIDADES,COUNT(*) AS CANT_CANCELACIONES 
		  FROM [GD2C2016].[UN_CORTADO].[CANCELACIONES] C
	  INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
	  ON C.Id_Turno = T.Id
	  INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
	  ON T.Especialidad = E.Id
	  WHERE DATEPART(YY,T.Fecha) = @YEAR AND
			DATEPART(MM,T.Fecha) IN (7,8,9,10,11,12)
	  GROUP BY T.Especialidad,E.Nombre
	  ORDER BY COUNT(*) DESC
	END --IF
END  --PROCEDURE
GO

-- PROCEDURE TOP5_PROFESIONALES X PLAN LISTADO ESTADISTICO 2

CREATE PROCEDURE [UN_CORTADO].[TOP5_PROFESIONAL_PLAN]  (@SEMESTRE INT,@YEAR INT) AS
BEGIN
	DECLARE plan_cursor CURSOR  
		FOR SELECT * FROM (SELECT DISTINCT P.Id
							  FROM [GD2C2016].[UN_CORTADO].[PLANES] P ) AS P2
	ORDER BY P2.Id DESC
	OPEN plan_cursor
	DECLARE @PLANES INT

	FETCH NEXT FROM plan_cursor INTO @Planes
	WHILE @@FETCH_STATUS = 0 AND @SEMESTRE =1
	BEGIN
		SELECT TOP 5  B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*) AS CANT_CON
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.�d_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON T.Bono_Usado = B.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id
		WHERE B.[Plan]=@PLANES  AND DATEPART(YY,A.[Fecha_hora])=@YEAR  AND
			 DATEPART(MM,A.[Fecha_hora]) IN (1,2,3,4,5,6)
				  GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
				  ORDER BY B.[Plan],COUNT(*) DESC
		FETCH NEXT FROM plan_cursor INTO @Planes; 
	END  -- WHILE
	WHILE @@FETCH_STATUS = 0 AND @SEMESTRE =2
	BEGIN
		SELECT TOP 5  B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*) AS CANT_CON
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.�d_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON T.Bono_Usado = B.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id
		WHERE B.[Plan]=@PLANES  AND DATEPART(YY,A.[Fecha_hora])=@YEAR  AND
			 DATEPART(MM,A.[Fecha_hora]) IN (7,8,9,10,11,12)
				  GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
				  ORDER BY B.[Plan],COUNT(*) DESC
		FETCH NEXT FROM plan_cursor INTO @Planes; 
	END  -- WHILE
	CLOSE plan_cursor  
	DEALLOCATE plan_cursor
END --PROCEDURE
GO

-- PROCEDURE TOP5_PROFESIONALES MENOS HORAS TRABAJADAS LISTADO ESTADISTICO 3

CREATE PROCEDURE [UN_CORTADO].[TOP5_PROFESIONAL_MENOSHORAS]  (@SEMESTRE INT,@YEAR INT) AS
BEGIN
	IF @SEMESTRE = 1 
	BEGIN
		SELECT TOP 5 B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*)/2 AS HORAS_TRABAJADAS
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.�d_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON T.Bono_Usado = B.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id
		WHERE DATEPART(YY,A.[Fecha_hora])=@YEAR  AND
		      DATEPART(MM,A.[Fecha_hora]) IN (1,2,3,4,5,6)
		GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
		ORDER BY B.[Plan],COUNT(*) ASC
	END --IF
		IF @SEMESTRE = 2 
	BEGIN
		SELECT TOP 5  B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*)/2 AS HORAS_TRABAJADAS
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.�d_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON T.Bono_Usado = B.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id
		WHERE DATEPART(YY,A.[Fecha_hora])=@YEAR  AND
		      DATEPART(MM,A.[Fecha_hora]) IN (7,8,9,10,11,12)
		GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
		ORDER BY B.[Plan],COUNT(*) ASC
	END --IF
END -- PROCEDURE
GO

--CREO VISTA PARA REGISTRAR_LLEGADA
CREATE VIEW UN_CORTADO.registro_llegada as
SELECT      UN_CORTADO.PROFESIONALES.Nombre_Usuario, UN_CORTADO.CONTACTO.Nombre, UN_CORTADO.CONTACTO.Apellido, UN_CORTADO.ESPECIALIDADES.Nombre AS Especialidades
FROM        UN_CORTADO.PROFESIONALES INNER JOIN
            UN_CORTADO.ESPECIALIDADPORPROFESIONAL ON UN_CORTADO.PROFESIONALES.Nombre_Usuario = UN_CORTADO.ESPECIALIDADPORPROFESIONAL.Id_Medico INNER JOIN
            UN_CORTADO.ESPECIALIDADES ON UN_CORTADO.ESPECIALIDADPORPROFESIONAL.Id_Especialidad = UN_CORTADO.ESPECIALIDADES.Id INNER JOIN
            UN_CORTADO.CONTACTO ON UN_CORTADO.PROFESIONALES.Nombre_Usuario = UN_CORTADO.CONTACTO.Nombre_Usuario

GO

--CREO VISTA CON SUS PROFESIONALES, ESPECIALIDADES Y AGENDAS
CREATE VIEW UN_CORTADO.ProfesionalesYSusEspecialidades as
SELECT        UN_CORTADO.CONTACTO.Nombre AS NOMBRE_PROFESIONAL , UN_CORTADO.CONTACTO.Apellido AS APELLIDO_PROFESIONAL, UN_CORTADO.AGENDA.Id AS ID_AGENDA, UN_CORTADO.ESPECIALIDADES.Nombre AS NOMBRE_ESPECIALIDAD
FROM          UN_CORTADO.ESPECIALIDADES INNER JOIN
              UN_CORTADO.ESPECIALIDADPORPROFESIONAL ON UN_CORTADO.ESPECIALIDADES.Id = UN_CORTADO.ESPECIALIDADPORPROFESIONAL.Id_Especialidad INNER JOIN
			  UN_CORTADO.AGENDA ON UN_CORTADO.ESPECIALIDADPORPROFESIONAL.Id = UN_CORTADO.AGENDA.Id_Especialidad_Medico INNER JOIN
              UN_CORTADO.CONTACTO ON UN_CORTADO.ESPECIALIDADPORPROFESIONAL.Id_Medico = UN_CORTADO.CONTACTO.Nombre_Usuario
GO

CREATE VIEW UN_CORTADO.listado_afiliados as
SELECT        UN_CORTADO.AFILIADOS.Nombre_Usuario, UN_CORTADO.AFILIADOS.Estado_Civil, UN_CORTADO.AFILIADOS.Cantidad_Hijos, UN_CORTADO.AFILIADOS.Id_Plan, UN_CORTADO.CONTACTO.Direccion,
                         UN_CORTADO.CONTACTO.Telefono, UN_CORTADO.CONTACTO.Mail, UN_CORTADO.USUARIOS.Habilitado, UN_CORTADO.AFILIADOS.Numero_Afiliado, UN_CORTADO.AFILIADOS.Numero_Familia
FROM            UN_CORTADO.AFILIADOS INNER JOIN
                         UN_CORTADO.CONTACTO ON UN_CORTADO.AFILIADOS.Nombre_Usuario = UN_CORTADO.CONTACTO.Nombre_Usuario INNER JOIN
                         UN_CORTADO.USUARIOS ON UN_CORTADO.AFILIADOS.Nombre_Usuario = UN_CORTADO.USUARIOS.Nombre_Usuario AND
                         UN_CORTADO.CONTACTO.Nombre_Usuario = UN_CORTADO.USUARIOS.Nombre_Usuario
GO

--VIEW NOMBER Y APELLIDO POR COMPRA DE BONO
CREATE VIEW UN_CORTADO.compraDeBonos as
SELECT        UN_CORTADO.CONTACTO.Apellido, UN_CORTADO.CONTACTO.Nombre, UN_CORTADO.COMPRABONOS.Id
FROM            UN_CORTADO.CONTACTO INNER JOIN
                         UN_CORTADO.COMPRABONOS ON UN_CORTADO.CONTACTO.Nombre_Usuario = UN_CORTADO.COMPRABONOS.Nombre_Usuario
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
INSERT INTO [UN_CORTADO].[#TMP1]
           ([Nombre_Usuario]
		   ,[Id_Plan])
	SELECT  DISTINCT [Paciente_Dni],[Plan_Med_Codigo]
    FROM [GD2C2016].[gd_esquema].[Maestra]
	ORDER BY 1

INSERT INTO [UN_CORTADO].[AFILIADOS]
               SELECT * FROM  [UN_CORTADO].[#TMP1]

DROP TABLE [UN_CORTADO].[#TMP1]


--LOAD TABLA [COMPRABONOS]    @FALTA VER EL TEMA DE CALCULAR EL COSTO TOTAL
INSERT INTO [UN_CORTADO].[COMPRABONOS]
           ([Nombre_Usuario]
           ,[Cantidad_Bonos]
		   ,[Precio_Total]
           ,[Fecha_Compra])
SELECT [Paciente_Dni], COUNT ( * ), (COUNT(*) * MAX(P.[Precio_Bono_Consulta])) ,Compra_Bono_Fecha
  FROM [GD2C2016].[gd_esquema].[Maestra]
  INNER JOIN [UN_CORTADO].[AFILIADOS] AS A
  ON [Paciente_Dni]=A.Nombre_Usuario
  INNER JOIN [UN_CORTADO].[PLANES] AS P
  ON A.Id_Plan = P.Id
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
  INNER JOIN [UN_CORTADO].[COMPRABONOS] AS C
  ON M.Paciente_Dni = C.Nombre_Usuario AND C.Fecha_Compra = M.Compra_Bono_Fecha 
  INNER JOIN [UN_CORTADO].[AFILIADOS] AS A
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
--LOAD TABLA [AGENDA] 
INSERT INTO [UN_CORTADO].[AGENDA]
           ([Dia_Atencion]
           ,[Id_Especialidad_Medico]
           ,[Fecha_Desde]
           ,[Fecha_Hasta]
           ,[Hora_Inicio]
           ,[Hora_Fin])
SELECT DISTINCT DATEPART(dw,[Turno_Fecha])AS Dia_Atencion,EM.Id,MIN(CONVERT(DATE,[Turno_Fecha])),MAX(CONVERT(DATE,[Turno_Fecha])),MIN(CONVERT(TIME,[Turno_Fecha])),MAX(CONVERT(TIME,DATEADD(minute,30,[Turno_Fecha])))
FROM [GD2C2016].[gd_esquema].[Maestra]
INNER JOIN [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] AS EM
ON EM.Id_Especialidad = [Especialidad_Codigo] AND EM.Id_Medico = [Medico_Dni]
GROUP BY DATEPART(dw,[Turno_Fecha]),EM.Id
ORDER BY 2,1,3

--LOAD TABLA [TURNOS]

INSERT INTO [UN_CORTADO].[TURNOS]
           ([Id_Agenda]
           ,[Hora_Inicio]
           ,[Hora_Fin]
           ,[Fecha]
           ,[Especialidad]
           ,[Disponible]
           ,[Id_Afiliado]
           ,[Hora_Llegada_Afiliado]
           ,[Bono_Usado])
SELECT DISTINCT A.Id,CONVERT(TIME,[Turno_Fecha]) AS HI,CONVERT(TIME,DATEADD(minute,30,[Turno_Fecha])) AS HF,CONVERT(DATE,[Turno_Fecha]) AS F,EM.Id_Especialidad AS ESP,0 AS DISPO,[Paciente_Dni] AS ID_AF,CONVERT(TIME,[Turno_Fecha]) AS HLL,[Bono_Consulta_Numero] AS BONO
FROM [GD2C2016].[gd_esquema].[Maestra]
INNER JOIN [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] AS EM
ON EM.Id_Especialidad = [Especialidad_Codigo] AND EM.Id_Medico = [Medico_Dni]
INNER JOIN [UN_CORTADO].[AGENDA] AS A
ON A.Dia_Atencion = DATEPART(dw,[Turno_Fecha]) AND EM.Id = A.[Id_Especialidad_Medico]
WHERE [Bono_Consulta_Numero] IS NOT NULL
ORDER BY 1

--LOAD TABLA [ATENCIONMEDICA]

INSERT INTO [UN_CORTADO].[ATENCIONMEDICA]
           ([Nombre_Profecional]
           ,[Enfermedad]
           ,[Sintomas]
		   ,[Fecha_Hora]
           ,[Nombre_Afiliado]
           ,[�d_turno])
SELECT DISTINCT EM.Id_Medico,[Consulta_Enfermedades],[Consulta_Sintomas],[Turno_Fecha],[Paciente_Dni] AS ID_AF,T.Id
FROM [GD2C2016].[gd_esquema].[Maestra]
INNER JOIN [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] AS EM
ON EM.Id_Especialidad = [Especialidad_Codigo] AND EM.Id_Medico = [Medico_Dni]
INNER JOIN [UN_CORTADO].[TURNOS] AS T
ON [Bono_Consulta_Numero]=T.[Bono_usado]
WHERE [Bono_Consulta_Numero] IS NOT NULL
ORDER BY 1

END
GO

-- MIGRACION DE DATOS
BEGIN
	EXECUTE [UN_CORTADO].[MIGRACION]
END
GO

