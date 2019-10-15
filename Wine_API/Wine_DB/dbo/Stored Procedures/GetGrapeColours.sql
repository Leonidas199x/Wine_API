CREATE PROCEDURE [dbo].[GetGrapeColours]
AS
BEGIN
	
SET NOCOUNT ON;

SELECT		GC.GrapeColourID	,
			GC.GrapeColour
FROM		dbo.GrapeColour		AS GC
ORDER BY	GC.GrapeColour		ASC;

END