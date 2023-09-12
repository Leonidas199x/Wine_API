IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_GetByName]
    @Name NVARCHAR(50)
AS
BEGIN

    SELECT
        WT.[ID],
        WT.[Name],
        WT.[Note],
        WT.[DateCreated],
        WT.[DateUpdated]
    FROM [dbo].[WineType] AS WT
    WHERE WT.[Name] = @Name;

END