CREATE PROCEDURE [dbo].[UpdateGrape]
	
	@intGrapeID				INT					,
	@strGrapeName			NVARCHAR(50)		,
	@intGrapeColourID		INT					,
	@strGrapeNote			NVARCHAR(100)		,
	@strGrapeAlternateName	NVARCHAR(100)		


AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE		G
	SET			G.GrapeName				=	@strGrapeName			,
				G.GrapeColourID			=	@intGrapeColourID		,	
				G.GrapeNote				=	@strGrapeNote			,
				G.GrapeAlternateName	=	@strGrapeAlternateName	,
				G.DateUpdated			=	GETDATE()					
	FROM		Grapes					AS	G
	WHERE		G.GrapeID				=	@intGrapeID;

END