IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_GetById]
    @VineyardEstateId INT
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
    WHERE VE.[Id] = @VineyardEstateId;

END