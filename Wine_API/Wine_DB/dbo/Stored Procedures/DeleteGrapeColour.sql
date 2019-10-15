CREATE PROCEDURE [dbo].[DeleteGrapeColour]
	
	@intGrapeColourID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    DELETE		GC
	FROM		GrapeColour			AS	GC
	WHERE		GC.GrapeColourID	=	@intGrapeColourID;

END