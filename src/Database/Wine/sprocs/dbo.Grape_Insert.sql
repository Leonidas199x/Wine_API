IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Grape_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Grape_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Grape_Insert]
    @GrapeName NVARCHAR(25),
    @GrapeNote NVARCHAR(MAX),
    @GrapeColourId INT
AS
BEGIN

    SET NOCOUNT ON;

    DECLARE @RunDate DATETIME2(3) = (SELECT GETDATE());

    INSERT INTO [dbo].[Grape]
    (
        [Name],
        [GrapeColourID],
        [Note],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @GrapeName,
        @GrapeColourID,
        @GrapeNote,
        @RunDate,
        @RunDate
    );
END