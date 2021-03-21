CREATE PROCEDURE [dbo].[GetGrapeColour]
	
	@intGrapeColourID	INT
AS

BEGIN
	
	SET NOCOUNT ON;

    SELECT		GC.GrapeColourID	,
				GC.GrapeColour
	FROM		GrapeColour			AS	GC
	WHERE		GC.GrapeColourID	=	@intGrapeColourID;
END