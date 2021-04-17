IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[GrapeColour_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[GrapeColour_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[GrapeColour_GetById]
    @GrapeColourID	INT
AS
BEGIN

    SELECT
        GC.[ID],
        GC.[Colour]
    FROM [dbo].[GrapeColour] AS	GC
    WHERE GC.[ID] = @GrapeColourID;

END