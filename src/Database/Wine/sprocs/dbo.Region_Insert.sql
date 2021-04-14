IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_Insert] 
    @RegionName	NVARCHAR(50),
    @RegionNote	NVARCHAR(500),
    @CountryID INT,
    @Longitude DECIMAL(9,6),
    @Latitude DECIMAL(8,6)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @RunDate DATETIME2(3) = (SELECT GETDATE());

    INSERT INTO [dbo].[Region]
    (
        [Name],
        [Note],
        [CountryID],
        [Longitude],
        [Latitude],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @RegionName,
        @RegionNote,
        @CountryID,
        @Longitude,
        @Latitude,
        @RunDate,
        @RunDate
    );

END