IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[RetailerWine_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[RetailerWine_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[RetailerWine_Update]
    @RetailerWineId INT,
    @Name NVARCHAR(50),
    @RetailerId INT,
    @WineId INT,
    @Description NVARCHAR(100),
    @Discontinued BIT,
    @RetailerTasteGuide NVARCHAR(20),
    @StopperTypeId INT,
    @WineCode NVARCHAR(50),
    @CustomerRating DECIMAL(4,2),
    @TastingNotes NVARCHAR(MAX),
    @StorageNotes NVARCHAR(MAX),
    @Range NVARCHAR(20)
AS
BEGIN

    UPDATE RW
    SET
        RW.[Name] = @Name,
        RW.[RetailerId] = @RetailerId,
        RW.[WineId] = @WineId,
        RW.[Description] = @Description,
        RW.[Discontinued] = @Discontinued,
        RW.[RetailerTasteGuide] = @RetailerTasteGuide,
        RW.[StopperTypeId] = @StopperTypeId,
        RW.[WineCode] = @WineCode,
        RW.[CustomerRating] = @CustomerRating,
        RW.[TastingNotes] = @TastingNotes,
        RW.[StorageNotes] = @StorageNotes,
        RW.[Range] = @Range
    FROM [dbo].[RetailerWine] AS RW
    WHERE RW.[ID] = @RetailerWineId;

END