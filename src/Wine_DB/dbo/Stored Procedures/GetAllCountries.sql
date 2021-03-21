CREATE PROCEDURE [dbo].[GetAllCountries]
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [CountryID]
	,[CountryName]
	FROM [dbo].[Country]
	ORDER BY [CountryName] ASC
END