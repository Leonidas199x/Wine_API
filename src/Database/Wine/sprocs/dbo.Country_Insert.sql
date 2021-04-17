IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_Insert]  AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_Insert] 
    @CountryName NVARCHAR(50),
    @CountryNote NVARCHAR(500),
    @IsoCode NVARCHAR(2)
AS
BEGIN

    SET NOCOUNT ON;

    DECLARE @DateTimeNow DATETIME = GETDATE();

    INSERT INTO [dbo].[Country]
    (
        [Name],
        [IsoCode],
        [Note],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @CountryName,
        @IsoCode,
        @CountryNote,
        @DateTimeNow,
        @DateTimeNow
    );

END