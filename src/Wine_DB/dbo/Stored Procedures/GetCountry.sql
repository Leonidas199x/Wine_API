CREATE PROCEDURE [dbo].[GetCountry]
	
	@intCountryID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT		C.CountryID			,
				C.CountryName		,
				C.CountryNote 		,
				C.DateCreated		,
				C.DateUpdated
	FROM		Country				AS	C
	WHERE		C.CountryID			=	@intCountryID;
END