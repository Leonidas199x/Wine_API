IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_GetByName]
    @Name NVARCHAR(50)
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
    WHERE VE.[Name] = @Name;

END