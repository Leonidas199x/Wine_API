﻿CREATE PROCEDURE [dbo].[InsertGrapeColour]

	@strGrapeColour		NVARCHAR(20)	,
	@bitExists			INT	OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF EXISTS (SELECT 1 FROM GrapeColour AS GC WHERE GC.GrapeColour = @strGrapeColour)
	BEGIN 
		SET @bitExists = 1 /*True*/
	END

	ELSE

	BEGIN
		INSERT INTO dbo.GrapeColour
			(
				GrapeColour
			)
		VALUES
			(
				@strGrapeColour
			)
		SET @bitExists = 0 /*False*/
	END
END