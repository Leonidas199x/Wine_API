CREATE PROCEDURE [dbo].[GetCountries]
	
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT		C.CountryID			, 
				C.CountryName		,
				C.CountryNote 		,
				C.DateCreated		,
				C.DateUpdated
	FROM		Country				AS C
	ORDER BY	C.CountryName		ASC;
END