CREATE PROCEDURE [dbo].[spGetCountry]
	
	@intCountryID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT		C.CountryID			,
				C.CountryName		,
				C.CountryNote 		
	FROM		Country				AS	C
	WHERE		C.CountryID			=	@intCountryID;
END