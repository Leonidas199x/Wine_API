IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_GetAll]

AS
BEGIN

    SELECT
        WT.[ID],
        WT.[Name],
        WT.[Note],
        WT.[DateCreated],
        WT.[DateUpdated]
    FROM [dbo].[WineType] AS WT
    ORDER BY WT.[Name] ASC;

END