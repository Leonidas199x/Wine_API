IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_GetAll]

AS
BEGIN

    SELECT
        VE.[ID],
        VE.[Name],
        VE.[Note],
        VE.[Longitude],
        VE.[Latitude],
        VE.[DateCreated],
        VE.[DateUpdated]
    FROM [dbo].[VineyardEstate] AS VE
    ORDER BY VE.[Name] ASC;

END