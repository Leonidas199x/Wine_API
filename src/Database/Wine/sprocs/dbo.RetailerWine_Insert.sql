IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[RetailerWine_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[RetailerWine_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[RetailerWine_Insert]
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

    INSERT INTO [dbo].[RetailerWine]
    (
        [Name],
        [RetailerId],
        [WineId],
        [Description],
        [Discontinued],
        [RetailerTasteGuide],
        [StopperTypeId],
        [WineCode],
        [CustomerRating],
        [TastingNotes],
        [StorageNotes],
        [Range]
    )
    VALUES
    (
        @Name,
        @RetailerId,
        @WineId,
        @Description,
        @Discontinued,
        @RetailerTasteGuide,
        @StopperTypeId,
        @WineCode,
        @CustomerRating,
        @TastingNotes,
        @StorageNotes,
        @Range
    );

END