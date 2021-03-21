CREATE PROCEDURE [dbo].[DeleteCountry]
	
	@intCountryID	INT
AS
BEGIN
	
	SET NOCOUNT ON;

    DELETE		C
	FROM		Country				AS	C
	WHERE		C.CountryID			=	@intCountryID;

END