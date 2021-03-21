IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Grape_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Grape_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Grape_Delete]
    @GrapeID	INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE G
    FROM [dbo].[Grape] AS G
    WHERE G.[ID] = @GrapeID;

END