IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_GetById]
    @WineTypeId INT
AS
BEGIN

    SELECT
        WT.[ID],
        WT.[Name],
        WT.[Note],
        WT.[DateCreated],
        WT.[DateUpdated]
    FROM [dbo].[WineType] AS WT
    WHERE WT.[ID] = @WineTypeId;

END