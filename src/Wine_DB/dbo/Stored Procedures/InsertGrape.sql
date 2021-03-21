CREATE PROCEDURE [dbo].[InsertGrape]
	
	@strGrapeName			NVARCHAR(25)	,
	@strGrapeNote			NVARCHAR(MAX)	,
	@strGrapeAlternateName	NVARCHAR(MAX)	,
	@intGrapeColourID		INT				,
	@bitExists				BIT OUTPUT

AS
BEGIN
	
	SET NOCOUNT ON;

	IF EXISTS (SELECT 1 FROM Grapes AS G WHERE G.GrapeName = @strGrapeName)
	BEGIN 
		SET @bitExists = 1 /*True*/
	END
	ELSE
	BEGIN
		DECLARE @dteRunDate DATETIME2(3);
		SELECT @dteRunDate = GETDATE();
		INSERT INTO dbo.Grapes
		(
			[GrapeName],
			[GrapeColourID],
			[GrapeAlternateName],
			[GrapeNote],
			[DateCreated],
			[DateUpdated]
		)
		VALUES
		(
			@strGrapeName,
			@intGrapeColourID,
			@strGrapeAlternateName,
			@strGrapeNote,
			@dteRunDate,
			@dteRunDate
		);
		SET @bitExists = 0;
	END		
END