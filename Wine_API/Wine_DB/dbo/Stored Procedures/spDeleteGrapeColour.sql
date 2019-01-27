CREATE PROCEDURE [dbo].[spDeleteGrapeColour]
	
	@intGrapeColourID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    DELETE		GC
	FROM		GrapeColour			AS	GC
	WHERE		GC.GrapeColourID	=	@intGrapeColourID;

END