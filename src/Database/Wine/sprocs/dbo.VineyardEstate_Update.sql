IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_Update]
    @VineyardEstateId INT,
    @Name NVARCHAR(50),
    @Note NVARCHAR(MAX),
    @Longitude DECIMAL(9,6),
    @Latitude DECIMAL(8,6)

AS
BEGIN

    UPDATE VE
    SET
        VE.[Name] = @Name,
        VE.[Note] = @Note,
        VE.[Longitude] = @Longitude,
        VE.[Latitude] = @Latitude,
        VE.[DateUpdated] = GETDATE()
    FROM [dbo].[VineyardEstate] VE
    WHERE VE.[ID] = @VineyardEstateId;

END