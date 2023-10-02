IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_Insert]
    @Name NVARCHAR(50),
    @Note NVARCHAR(MAX),
    @Longitude DECIMAL(9,6),
    @Latitude DECIMAL(8,6)

AS
BEGIN

    DECLARE @RunDate DATETIME2(3) = GETDATE();

    INSERT INTO [dbo].[VineyardEstate]
    (
        [Name],
        [Note],
        [Longitude],
        [Latitude],
        [DateUpdated],
        [DateCreated]
    )
    VALUES
    (
        @Name,
        @Note,
        @Longitude,
        @Latitude,
        @RunDate,
        @RunDate
    )

END