IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[GrapeColour_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[GrapeColour_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[GrapeColour_Insert]
    @GrapeColour NVARCHAR(20)
AS
BEGIN

    SET NOCOUNT ON;

    INSERT INTO dbo.GrapeColour
    (
        Colour
    )
    VALUES
    (
        @GrapeColour
    );

END