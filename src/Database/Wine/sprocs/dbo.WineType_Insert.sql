IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_Insert]
    @Name NVARCHAR(50),
    @Note NVARCHAR(MAX)
AS
BEGIN

    DECLARE @RunDate DATETIME2(3) = GETDATE();

    INSERT INTO [dbo].[WineType]
    (
        [Name],
        [Note],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @Name,
        @Note,
        @RunDate,
        @RunDate
    )

END