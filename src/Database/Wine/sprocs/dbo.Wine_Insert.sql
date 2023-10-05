IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_Insert]
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
    INSERT INTO [dbo].[Wine]
    (
        [ProducerID],
        [RegionID],
        [Vintage],
        [QualityControlID],
        [VinyardEstateID],
        [WineTypeID],
        [Description],
        [ABV],
        [Importer],
        [InventoryLevel],
        [ExclusiveToRetailerID],
        [DateCreated],
        [DateUpdated]
    )
    VALUES
    (
        @ProducerId,
        @RegionId,
        @Vintage,
        @QualityControlId,
        @VineyardEstateId,
        @WineTypeId,
        @Description,
        @Abv,
        @Importer,
        @InventoryLevel,
        @ExclusiveToRetailerId,
        GETDATE(),
        GETDATE()
    );

    SELECT SCOPE_IDENTITY();

END