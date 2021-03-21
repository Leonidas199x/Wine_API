IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_GetAll]

AS
BEGIN

    SELECT
        R.[ID],
        R.[CountryID],
        R.[Name],
        R.[Note],
        R.[LocationRegionImage],
        R.[DateCreated],
        R.[DateUpdated]
    FROM [dbo].[Region] AS R
    ORDER BY R.[Name] ASC;

END