IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Producer_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Producer_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Producer_Insert]
    @ProducerNote NVARCHAR(MAX),
    @ProducerName NVARCHAR(50),
    @ProducerId INT OUTPUT
AS
BEGIN

    SET NOCOUNT ON;

    DECLARE @RunDate DATETIME2(3) = (SELECT GETDATE());

    INSERT INTO [dbo].[Producer]
    (
        [Name],
        [Note],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @ProducerName,
        @ProducerNote,
        @RunDate,
        @RunDate
    );

    SELECT @ProducerId = SCOPE_IDENTITY();
END