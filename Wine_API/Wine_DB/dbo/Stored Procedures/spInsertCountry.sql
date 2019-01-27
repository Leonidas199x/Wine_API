-- =============================================
-- Author:		Toby Prince
-- Create date: 20/02/2017
-- Description:	Inserts a new country into the database. LIKE A BOSS.
-- =============================================
CREATE PROCEDURE [dbo].[spInsertCountry] 

	@strCountryName NVARCHAR(50)	,
	@strCountryNote	NVARCHAR(500)	,
	@bitExists		INT	OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

IF EXISTS (SELECT 1 FROM Country AS C WHERE LTRIM(RTRIM(C.CountryName)) = LTRIM(RTRIM(@strCountryName)))
	BEGIN 
		SET @bitExists = 1 /*True*/
	END

	ELSE

	BEGIN
		DECLARE @dteRunDate DATETIME2(3);
		SET		@dteRunDate = GETDATE();

		INSERT INTO Country
		(	
			CountryName,
			CountryNote,
			DateCreated,
			DateUpdated
		)
		VALUES
		(
			@strCountryName,
			@strCountryNote,
			@dteRunDate,
			@dteRunDate
		)
		SET @bitExists = 0 /*False*/
	END

END