-- =============================================
-- Author:		Toby Prince
-- Create date: 20/02/2017
-- Description:	Gets all the Countries in the database
-- =============================================
CREATE PROCEDURE [dbo].[spGetAllCountries]
	
AS
BEGIN

	SET NOCOUNT ON;

	SELECT [CountryID]
	,[CountryName]
	FROM [dbo].[Country]
	ORDER BY [CountryName] ASC
END