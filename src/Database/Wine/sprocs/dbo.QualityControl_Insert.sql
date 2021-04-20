IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_Insert]
    @Name NVARCHAR(50),
    @Note NVARCHAR(MAX),
    @CountryId INT
AS
BEGIN
    
    DECLARE @RunDate DATETIME2(3) = GETDATE();

    INSERT INTO [dbo].[QualityControl]
    (
        [Name],
        [Note],
        [CountryId],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @Name,
        @Note,
        @CountryId,
        @RunDate,
        @RunDate
    )

END