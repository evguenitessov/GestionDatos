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
	[Disponible]				TINYINT DEFAULT 1,
	[Id_Afiliado]				VARCHAR(30) REFERENCES [UN_CORTADO].[AFILIADOS],	
	--[Numero]					INT NOT NULL,
	[Hora_Llegada_Afiliado]		TIME DEFAULT NULL,
	[Bono_Usado]				NUMERIC(18,0),
)
GO

CREATE TABLE [UN_CORTADO].[ATENCIONMEDICA] (   --@DIAGNOSTICO DE DONDE SE SACA
	[Id]						INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	[Nombre_Profecional]		VARCHAR(30) REFERENCES [UN_CORTADO].[PROFESIONALES],
	[Enfermedad]				VARCHAR(255),
	[Sintomas]					VARCHAR(255),
	--[Diagnosticos]				VARCHAR(30) NULL,		
	[Fecha_Hora]				DATETIME DEFAULT GETDATE(), 
	--[Nombre_Afiliado]			VARCHAR(30) NOT NULL REFERENCES [UN_CORTADO].[AFILIADOS],
	[Id_turno]			        INT NOT NULL REFERENCES [UN_CORTADO].[TURNOS],
	[Bono_Usado]				NUMERIC(18,0) REFERENCES [UN_CORTADO].[BONOS],	
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

CREATE PROCEDURE [UN_CORTADO].[TOP5_PROFESIONAL_PLAN]  (@SEMESTRE INT,@YEAR INT,@PLANES INT) AS
BEGIN
	IF @SEMESTRE =1
	BEGIN
		SELECT TOP 5  B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*) AS CANT_CON
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON A.Bono_Usado = B.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.Id_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id
		WHERE B.[Plan]=@PLANES  AND DATEPART(YY,T.[Fecha])=@YEAR  AND
			 DATEPART(MM,T.[Fecha]) IN (1,2,3,4,5,6)
				  GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
				  ORDER BY B.[Plan],COUNT(*) DESC
	END -- IF 1 SEMESTRE
	IF  @SEMESTRE =2
	BEGIN
		SELECT TOP 5  B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*) AS CANT_CON
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON A.Bono_Usado = B.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.Id_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id
		WHERE B.[Plan]=@PLANES  AND DATEPART(YY,T.[Fecha])=@YEAR  AND
		DATEPART(MM,T.[Fecha]) IN (7,8,9,10,11,12)
		GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
		ORDER BY B.[Plan],COUNT(*) DESC
	END  -- IF 2 SEMESTRE	
END --PROCEDURE
GO

-- PROCEDURE TOP5_PROFESIONALES MENOS HORAS TRABAJADAS LISTADO ESTADISTICO 3

CREATE PROCEDURE [UN_CORTADO].[TOP5_PROFESIONAL_MENOSHORAS]  (@SEMESTRE INT,@YEAR INT,@PLAN INT,@ESPECIALIDAD INT) AS
BEGIN
	IF @SEMESTRE = 1 
	BEGIN
		SELECT TOP 5 B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*)/2 AS HORAS_TRABAJADAS
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON A.Bono_Usado = B.Id AND B.[Plan] = @PLAN
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.Id_turno = T.Id 
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id AND E.Id = @ESPECIALIDAD 
		WHERE DATEPART(YY,T.[Fecha])=@YEAR  AND
		      DATEPART(MM,T.[Fecha]) IN (1,2,3,4,5,6)
		GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
		ORDER BY B.[Plan],COUNT(*) ASC
	END --IF
		IF @SEMESTRE = 2 
	BEGIN
		SELECT TOP 5 B.[Plan],E.[Nombre],A.[Nombre_Profecional],COUNT(*)/2 AS HORAS_TRABAJADAS
		FROM [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] A
		INNER JOIN [GD2C2016].[UN_CORTADO].[BONOS] B
		ON A.Bono_Usado = B.Id AND B.[Plan] = @PLAN
		INNER JOIN [GD2C2016].[UN_CORTADO].[TURNOS] T
		ON A.Id_turno = T.Id 
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON T.Especialidad=E.Id AND E.Id = @ESPECIALIDAD 
		WHERE DATEPART(YY,T.[Fecha])=@YEAR  AND
		      DATEPART(MM,T.[Fecha]) IN (7,8,9,10,11,12)
		GROUP BY B.[Plan],E.[Nombre],A.[Nombre_Profecional]
		ORDER BY B.[Plan],COUNT(*) ASC
	END --IF
END -- PROCEDURE
GO

-- PROCEDURE TOP5_AFILIADOS MAS COMPRABONOS  LISTADO ESTADISTICO 4

CREATE PROCEDURE [UN_CORTADO].[TOP5_AFILIADOS_MASBONOSCOMPRADOS]  (@SEMESTRE INT,@YEAR INT) AS
BEGIN
	IF @SEMESTRE = 1 
	BEGIN
		SELECT TOP 5 CB.[Nombre_Usuario]
		,SUM([Cantidad_Bonos]) AS CANT_BON_COMPRADOS
		,PERTENECE_GRUPO_FAMILIAR = CASE AF.Numero_Familia
		 WHEN '0' THEN 'NO'  
         ELSE 'SI' END
		FROM [GD2C2016].[UN_CORTADO].[COMPRABONOS] CB
		INNER JOIN [GD2C2016].[UN_CORTADO].[AFILIADOS] AF
		ON CB.Nombre_Usuario = AF.Nombre_Usuario
		WHERE DATEPART(YY,CB.Fecha_Compra)=@YEAR  AND
		      DATEPART(MM,CB.Fecha_Compra) IN (1,2,3,4,5,6)
		GROUP BY CB.Nombre_Usuario,AF.Numero_Familia 
		ORDER BY CANT_BON_COMPRADOS DESC
	END -- IF
		IF @SEMESTRE = 2 
	BEGIN
		SELECT TOP 5 CB.[Nombre_Usuario]
		,SUM([Cantidad_Bonos]) AS CANT_BON_COMPRADOS
		,PERTENECE_GRUPO_FAMILIAR = CASE AF.Numero_Familia
		 WHEN '0' THEN 'NO'  
         ELSE 'SI' END
		FROM [GD2C2016].[UN_CORTADO].[COMPRABONOS] CB
		INNER JOIN [GD2C2016].[UN_CORTADO].[AFILIADOS] AF
		ON CB.Nombre_Usuario = AF.Nombre_Usuario
		WHERE DATEPART(YY,CB.Fecha_Compra)=@YEAR  AND
		      DATEPART(MM,CB.Fecha_Compra) IN (7,8,9,10,11,12)
		GROUP BY CB.Nombre_Usuario,AF.Numero_Familia 
		ORDER BY CANT_BON_COMPRADOS DESC
	END -- IF
END
GO

-- PROCEDURE TOP5_ESPECIALIDADES CON MAS BONOS USADOS  LISTADO ESTADISTICO 5

CREATE PROCEDURE [UN_CORTADO].[TOP5_ESPECIALIDADES_MASBONOS]  (@SEMESTRE INT,@YEAR INT) AS
BEGIN
	IF @SEMESTRE = 1 
	BEGIN
		SELECT TOP 5 E.Nombre
					 ,COUNT(AT.Bono_Usado) AS CANT_BONOS_USADOS		
		FROM [GD2C2016].[UN_CORTADO].[TURNOS] T
		INNER JOIN [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] AT
		ON AT.Id_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[AGENDA] A
		ON T.Id_Agenda = A.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] EP
		ON A.Id_Especialidad_Medico = EP.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON E.Id = EP.Id_Especialidad 
		WHERE DATEPART(YY,T.Fecha)=@YEAR  AND
		      DATEPART(MM,T.Fecha) IN (1,2,3,4,5,6)
		GROUP BY E.Nombre 
		ORDER BY COUNT(AT.Bono_Usado) DESC
	END -- IF
		IF @SEMESTRE = 2 
	BEGIN
		SELECT TOP 5 E.Nombre
					 ,COUNT(AT.Bono_Usado) AS CANT_BONOS_USADOS		
		FROM [GD2C2016].[UN_CORTADO].[TURNOS] T
		INNER JOIN [GD2C2016].[UN_CORTADO].[ATENCIONMEDICA] AT
		ON AT.Id_turno=T.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[AGENDA] A
		ON T.Id_Agenda = A.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] EP
		ON A.Id_Especialidad_Medico = EP.Id
		INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
		ON E.Id = EP.Id_Especialidad 
		WHERE DATEPART(YY,T.Fecha)=@YEAR  AND
		      DATEPART(MM,T.Fecha) IN (7,8,9,10,11,12)
		GROUP BY E.Nombre 
		ORDER BY COUNT(AT.Bono_Usado) DESC
	END -- IF
END -- PROCEDURE
GO

CREATE PROCEDURE [UN_CORTADO].[TURNOS_DISPONIBLES] (@ESPECIALIDAD INT,@MEDICO varchar(30)) AS
BEGIN
	SELECT T.[Id]
		  ,T.[Fecha]
		  ,T.[Hora_Inicio]
	  FROM [GD2C2016].[UN_CORTADO].[TURNOS] T
	  INNER JOIN [GD2C2016].[UN_CORTADO].[AGENDA] A
	  ON T.Id_Agenda = A.Id
	  INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] ES
	  ON A.Id_Especialidad_Medico=ES.Id AND ES.Id_Especialidad=@ESPECIALIDAD
	  INNER JOIN [GD2C2016].[UN_CORTADO].[ESPECIALIDADES] E
	  ON ES.Id_Especialidad=E.Id
	  INNER JOIN [GD2C2016].[UN_CORTADO].[PROFESIONALES] P
	  ON ES.Id_Medico=P.Nombre_Usuario AND P.Nombre_Usuario=@MEDICO
	  WHERE T.[Disponible] = 1
	  ORDER BY T.[Fecha],T.[Hora_Inicio]

END --PROCEDURE
GO

CREATE PROCEDURE [UN_CORTADO].[REGISTRO_RESULTADO](@MEDICO varchar(30),@ENFERMEDAD varchar(255),@SINTOMAS varchar(255),@ID_TURNO INT,@BONO_USADO numeric(18,0)) AS
BEGIN
	INSERT INTO [UN_CORTADO].[ATENCIONMEDICA]
			   ([Nombre_Profecional]
			   ,[Enfermedad]
			   ,[Sintomas]
			   ,[Id_turno]
			   ,[Bono_Usado])
		 VALUES
			   (@MEDICO
			   ,@ENFERMEDAD
			   ,@SINTOMAS
			   ,@ID_TURNO
			   ,@BONO_USADO)
END
GO

-- PROCEDIMIENTO PARA CANCELACION DE TURNOS POR RANGO DE FECHA POR PROFESIONAL

CREATE PROCEDURE [UN_CORTADO].[CANCELAR_RANGO_FECHA] (@FECHA_SISTEMA DATE,@ESPECIALIDAD_MEDICO varchar(30),@FECHA_DESDE DATE,@FECHA_HASTA DATE) AS
BEGIN
	DECLARE @FECHA_AUX DATE
	DECLARE @FECHA_AUX2 DATE
	SET @FECHA_AUX2= DATEADD(DAY,1,@FECHA_SISTEMA)
	SET @FECHA_AUX=@FECHA_DESDE
	WHILE @FECHA_AUX <= @FECHA_HASTA
		BEGIN
			IF @FECHA_AUX > @FECHA_AUX2
			BEGIN
				UPDATE [UN_CORTADO].[TURNOS] SET Disponible=2  --HAY QUE CAMBIAR EL TIPO DE DATO DE DISPONIBLE
				WHERE Id IN ( 
				SELECT T.Id AS ID_TURNO
				FROM [GD2C2016].[UN_CORTADO].[TURNOS] T
				INNER JOIN [GD2C2016].[UN_CORTADO].[AGENDA] A
				ON T.Id_Agenda= A.Id
				INNER JOIN  [GD2C2016].[UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] ES
				ON ES.Id= A.Id_Especialidad_Medico AND
				ES.Id = @ESPECIALIDAD_MEDICO
				WHERE T.[Fecha]=@FECHA_AUX )
			END --IF
			SET @FECHA_AUX = DATEADD(DAY,1,@FECHA_AUX)
		END -- WHILE
END --PROCEDURE
GO

-- -- PROCEDIMIENTO PARA CANCELAR DE TURNOS UN DIA EN PARTICULAR POR PROFESIONAL

CREATE PROCEDURE [UN_CORTADO].[CANCELAR_UN_DIA] (@FECHA_SISTEMA DATE,@ESPECIALIDAD_MEDICO varchar(30),@FECHA_CAN DATE) AS
BEGIN
	DECLARE @FECHA_AUX2 DATE
	SET @FECHA_AUX2= DATEADD(DAY,1,@FECHA_SISTEMA)
	IF @FECHA_AUX2 < @FECHA_CAN
	BEGIN
		UPDATE [UN_CORTADO].[TURNOS] SET Disponible=2  --HAY QUE CAMBIAR EL TIPO DE DATO DE DISPONIBLE
		WHERE Id IN ( 
			SELECT T.Id AS ID_TURNO
			FROM [GD2C2016].[UN_CORTADO].[TURNOS] T
			INNER JOIN [GD2C2016].[UN_CORTADO].[AGENDA] A
			ON T.Id_Agenda= A.Id
			INNER JOIN  [GD2C2016].[UN_CORTADO].[ESPECIALIDADPORPROFESIONAL] ES
			ON ES.Id= A.Id_Especialidad_Medico AND
			ES.Id = @ESPECIALIDAD_MEDICO
			WHERE T.[Fecha]=@FECHA_CAN )
	END --IF
END --PROCEDURE
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
                         UN_CORTADO.CONTACTO.Telefono, UN_CORTADO.CONTACTO.Mail, UN_CORTADO.USUARIOS.Habilitado, UN_CORTADO.AFILIADOS.Numero_Afiliado, UN_CORTADO.AFILIADOS.Numero_Familia, 
                         UN_CORTADO.CONTACTO.Nombre, UN_CORTADO.CONTACTO.Apellido
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
		('Cancelar atencion medica'), ('Registro de Usuario'), ('Compra de bonos'), ('Pedir Turno'),('Listado Estadistico')
--LOAD TABLA [FUNCIONESPORROL]
INSERT INTO [UN_CORTADO].[FUNCIONESPORROL] (Id_Funcion, Id_Rol)
	VALUES (4, 1),(7, 1),(13,1), (11,1),(2,1),(10,1),(3,1),(6,1),(8,1),
		   (1, 2), (5, 2), (9, 2),
		   (9, 3), (11, 3), (12, 3)
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
INSERT INTO [UN_CORTADO].[USUARIOS] (Nombre_Usuario, Contraseña)
VALUES ('admin', HASHBYTES('SHA2_256', 'w23e'))
INSERT INTO [UN_CORTADO].[USUARIOS]
           ([Nombre_Usuario]
           ,[Contraseña])
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

--LOAD DE AFILIADOS EN ROL POR USUARIO

INSERT INTO [UN_CORTADO].[ROLPORUSUARIO]
           ([Nombre_Usuario]
           ,[Id_Rol])
     SELECT  AF.[Nombre_Usuario],3 FROM  [UN_CORTADO].[AFILIADOS] AS AF
	
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
SELECT DISTINCT M.Bono_Consulta_Numero,1, C.id,M.Bono_Consulta_Fecha_Impresion,0,A.Id_Plan,C.Nombre_Usuario,0
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
--LOAD PROFESIONALES EN ROL POR USUARIO
INSERT INTO [UN_CORTADO].[ROLPORUSUARIO]
           ([Nombre_Usuario]
           ,[Id_Rol])
     SELECT  P.[Nombre_Usuario],2 FROM  [UN_CORTADO].[PROFESIONALES] AS P

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
           ,[Id_turno]
		   ,[Bono_Usado])
SELECT DISTINCT EM.Id_Medico,[Consulta_Enfermedades],[Consulta_Sintomas],[Turno_Fecha],T.Id,[Bono_Consulta_Numero]
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

-- HACER DROP DE LA COLUMNA BONO USADO DE TURNOS

ALTER TABLE [UN_CORTADO].[TURNOS] DROP COLUMN Bono_Usado
Insert into UN_CORTADO.AFILIADOS values('admin',0,0, 'SOLTERO/A',0,555559)
Insert into UN_CORTADO.PROFESIONALES values('admin',0)

--GO

