CREATE PROCEDURE [dbo].[GetRegions]
	
AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT		R.RegionID				,
				R.CountryID				,
				R.RegionName			,
				R.RegionNote			,
				R.DateCreated			,
				R.DateUpdated			,
				R.LocationRegionImage
	FROM		Region					AS	R
	ORDER BY	R.RegionName			ASC;
END