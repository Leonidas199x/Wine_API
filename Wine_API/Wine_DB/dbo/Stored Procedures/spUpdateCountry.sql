CREATE PROCEDURE [dbo].[spUpdateCountry]
	
	@strCountryName	NVARCHAR(50)		,
	@strCountryNote	NVARCHAR(500)		,
	@intCountryID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE		C
	SET			C.CountryName		=	@strCountryName		,
				C.CountryNote		=	@strCountryNote		,
				C.DateUpdated		=	GETDATE()
	FROM		Country				AS	C
	WHERE		C.CountryID			=	@intCountryID;

END