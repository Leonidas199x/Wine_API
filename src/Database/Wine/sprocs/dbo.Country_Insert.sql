IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_Insert] ') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_Insert]  AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_Insert] 
    @CountryName NVARCHAR(50),
    @CountryNote NVARCHAR(500),
    @CountryId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DateTimeNow DATETIME = GETDATE();

    INSERT INTO [dbo].[Country]
    (
        [Name],
        [Note],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @CountryName,
        @CountryNote,
        @DateTimeNow,
        @DateTimeNow
    );

    SELECT @CountryId = SCOPE_IDENTITY();
END