IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[RetailerWine_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[RetailerWine_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[RetailerWine_Delete]
    @RetailerWineId INT
AS
BEGIN

    DELETE RW
    FROM [dbo].[RetailerWine] AS RW
    WHERE RW.[ID] = @RetailerWineId;

END