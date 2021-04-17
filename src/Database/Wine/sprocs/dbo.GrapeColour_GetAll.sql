IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[GrapeColour_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[GrapeColour_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[GrapeColour_GetAll]
AS
BEGIN

    SET NOCOUNT ON;

    SELECT
        GC.[ID],
        GC.[Colour]
    FROM [dbo].[GrapeColour] AS GC;

END