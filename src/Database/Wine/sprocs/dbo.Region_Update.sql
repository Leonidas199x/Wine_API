IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_Update]
    @RegionId INT,
    @RegionName	NVARCHAR(50),
    @RegionNote	NVARCHAR(500),
    @CountryID INT,
    @Longitude DECIMAL(9,6),
    @Latitude DECIMAL(8,6),
    @IsoCode NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RunDate DATETIME2(3) = (SELECT GETDATE());

    UPDATE R
    SET
        R.[Name] = @RegionName,
        R.[IsoCode] = @IsoCode,
        R.[Note] = @RegionNote,
        R.[CountryId] = @CountryId,
        R.[Longitude] = @Longitude,
        R.[Latitude] = @Latitude
    FROM [dbo].[Region] R
    WHERE R.[Id] = @RegionId;

END