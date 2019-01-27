CREATE PROCEDURE [dbo].[spDeleteGrape]
	
	@intGrapeID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    DELETE		G
	FROM		Grapes		AS	G
	WHERE		G.GrapeID	=	@intGrapeID;

END