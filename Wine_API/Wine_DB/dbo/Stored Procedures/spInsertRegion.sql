-- =============================================
-- Author:		Toby Prince
-- Create date: 20/02/2017
-- Description:	Inserts a new region into the database. LIKE A BOSS.
-- =============================================
CREATE PROCEDURE [dbo].[spInsertRegion] 

	@strRegionName	NVARCHAR(50),
	@strRegionNote	NVARCHAR(500),
	@intCountryID	INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @dteRunDate DATETIME2(3);

	SET @dteRunDate = GETDATE();

INSERT INTO Region
(	
	RegionName,
	RegionNote,
	CountryID,
	DateCreated,
	DateUpdated
)
VALUES
(
	@strRegionName,
	@strRegionNote,
	@intCountryID,
	@dteRunDate,
	@dteRunDate
)
END