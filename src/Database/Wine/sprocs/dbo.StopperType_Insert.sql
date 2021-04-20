IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[StopperType_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[StopperType_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[StopperType_Insert]
    @Name NVARCHAR(50)
AS
BEGIN

    DECLARE @RunDate DATETIME2(3) = GETDATE();

    INSERT INTO [dbo].[StopperType]
    (
        [Name],
        [DateUpdated],
        [DateCreated]
    )
    VALUES
    (
        @Name,
        @RunDate,
        @RunDate
    )

END