IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[GrapeColour_GetByColour]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[GrapeColour_GetByColour] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].GrapeColour_GetByColour
    @GrapeColour VARCHAR(20)
AS
BEGIN

    SELECT
        GC.[ID],
        GC.[Colour]
    FROM [dbo].[GrapeColour] AS	GC
    WHERE GC.[Colour] = @GrapeColour;

END