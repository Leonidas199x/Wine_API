CREATE PROCEDURE [dbo].[DeleteGrape]
	
	@intGrapeID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    DELETE		G
	FROM		Grapes		AS	G
	WHERE		G.GrapeID	=	@intGrapeID;

END