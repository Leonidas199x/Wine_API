IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_GetAll]
AS
BEGIN

    SELECT
        C.[ID],
        C.[Name],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[Country] AS C
    ORDER BY C.[Name] ASC;

END