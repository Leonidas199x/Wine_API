IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_GetByDescription]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_GetByDescription] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_GetByDescription]
    @Description NVARCHAR(100)
AS
BEGIN

    SELECT
        W.[ProducerID],
        W.[RegionID],
        W.[Vintage],
        W.[QualityControlID],
        W.[VinyardEstateID],
        W.[WineTypeID],
        W.[Description],
        W.[ABV],
        W.[Importer],
        W.[InventoryLevel],
        W.[ExclusiveToRetailerID]
    FROM [dbo].[Wine] AS W
    WHERE W.[Description] = @Description;

END