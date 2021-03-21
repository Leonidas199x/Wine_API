IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[GrapeColour_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[GrapeColour_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[GrapeColour_Delete]
    @GrapeColourID	INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE GC
    FROM [dbo].[GrapeColour] AS	GC
    WHERE GC.[ID] = @GrapeColourID;

END