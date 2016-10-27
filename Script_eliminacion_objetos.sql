USE [GD2C2016]
GO

BEGIN TRAN

/*******************************************
***** ELIMINAR TABLAS ***************** 
********************************************/

DROP TABLE [UN_CORTADO].[CANCELACIONES]

DROP TABLE [UN_CORTADO].[MODIFICACIONES]

DROP TABLE [UN_CORTADO].[ATENCIONMEDICA]

DROP TABLE [UN_CORTADO].[CONTACTO]

DROP TABLE [UN_CORTADO].[FUNCIONESPORROL]

DROP TABLE [UN_CORTADO].[FUNCIONES]

DROP TABLE [UN_CORTADO].[ROLPORUSUARIO]

DROP TABLE [UN_CORTADO].[ROLES]

DROP TABLE [UN_CORTADO].[TURNOS]

DROP TABLE [UN_CORTADO].[BONOS]

DROP TABLE [UN_CORTADO].[COMPRABONOS]

DROP TABLE [UN_CORTADO].[AFILIADOS]

DROP TABLE [UN_CORTADO].[PLANES]

DROP TABLE [UN_CORTADO].[AGENDA]

DROP TABLE [UN_CORTADO].[ESPECIALIDADPORPROFESIONAL]

DROP TABLE [UN_CORTADO].[ESPECIALIDADES]

DROP TABLE [UN_CORTADO].[TIPOESPECIALIDAD]

DROP TABLE [UN_CORTADO].[PROFESIONALES]

DROP TABLE [UN_CORTADO].[USUARIOS]

DROP PROCEDURE [UN_CORTADO].[Migracion]

DROP PROCEDURE [UN_CORTADO].[CARGAR_AGENDA]


/*******************************************
***** ELIMINAR ESQUEMA ***************** 
********************************************/

DROP SCHEMA [UN_CORTADO]

COMMIT TRAN