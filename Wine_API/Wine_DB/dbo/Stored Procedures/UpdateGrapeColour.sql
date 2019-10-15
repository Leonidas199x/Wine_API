CREATE PROCEDURE [dbo].[UpdateGrapeColour]
	
	@strGrapeColour		NVARCHAR(50)		,
	@intGrapeColourID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE		GC
	SET			GC.GrapeColour		=	@strGrapeColour						
	FROM		GrapeColour			AS	GC
	WHERE		GC.GrapeColourID	=	@intGrapeColourID;

END