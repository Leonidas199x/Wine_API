IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[GrapeColour_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[GrapeColour_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[GrapeColour_Update]
    @GrapeColour NVARCHAR(50),
    @GrapeColourID INT
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE GC
    SET GC.Colour = @GrapeColour
    FROM [dbo].[GrapeColour] AS GC
    WHERE GC.[ID] = @GrapeColourID;

END