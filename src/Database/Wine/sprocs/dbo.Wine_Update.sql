IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_Update]
    @Id INT,
    @ProducerId INT,
    @RegionId INT,
    @Vintage INT,
    @QualityControlId INT,
    @VineyardEstateId INT,
    @WineTypeId INT,
    @Description NVARCHAR(100),
    @Abv DECIMAL(4,2),
    @Importer NVARCHAR(25),
    @InventoryLevel INT,
    @ExclusiveToRetailerId INT
AS
BEGIN
    UPDATE w
    SET
        w.[ProducerID] = @ProducerId,
        w.[RegionID] = @RegionId,
        w.[Vintage] = @Vintage,
        w.[QualityControlID] = @QualityControlId,
        w.[VinyardEstateID] = @VineyardEstateId,
        w.[WineTypeID] = @WineTypeId,
        w.[Description] = @Description,
        w.[ABV] = @Abv,
        w.[Importer] = @Importer,
        w.[InventoryLevel] = @InventoryLevel,
        w.[ExclusiveToRetailerID] = @ExclusiveToRetailerId,
        w.[DateUpdated] = GETDATE()
    FROM [dbo].[Wine] AS w
    WHERE w.[ID] = @Id;

END