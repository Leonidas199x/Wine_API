IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_GetById]
    @WineID INT
AS
BEGIN

    /*Wine*/
    SELECT 
        W.[ID],
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
        W.[ExclusiveToRetailerID],
        W.[DateCreated],
        W.[DateUpdated]
    FROM [dbo].[Wine] AS W
    WHERE W.[ID] = @WineID;

    /*Rating*/
    SELECT
        R.[Id],
        R.[DrinkerId],
        R.[WineId],
        R.[Rating],
        R.[Note]
    FROM [dbo].[Rating] R
    WHERE R.[WineId] = @WineID;

    /*Grapes*/
    SELECT
        G.[ID],
        G.[Name],
        G.[GrapeColourID],
        GC.[Colour],
        G.[Note],
        G.[DateCreated],
        G.[DateUpdated]
    FROM [dbo].[GrapeWineBridge] GW
    INNER JOIN [dbo].[Grape] G ON G.[Id] = GW.[GrapeId]
    LEFT JOIN [dbo].[GrapeColour] GC ON G.[GrapeColourID] = GC.[ID]
    WHERE GW.[WineId] = @WineID;

    /*Prices*/
    SELECT
        P.[ID],
        P.[WineId],
        P.[RetailerWineId],
        P.[EffectiveDate],
        P.[FullPrice],
        P.[DiscountPrice],
        P.[DateCreated],
        P.[DateUpdated]
    FROM [dbo].[WinePrice] P
    WHERE P.[WineId] = @WineID;

    /*Issues*/
    SELECT
        I.[ID],
        I.[WineId],
        I.[Date],
        I.[Quantity],
        I.[Note],
        I.[DateCreated],
        I.[DateUpdated]
    FROM [dbo].[Issue] I
    WHERE I.[WineId] = @WineID;

    /*Receipts*/
    SELECT
        R.[ID],
        R.[WineId],
        R.[RetailerId],
        R.[Date],
        R.[Quantity],
        R.[Note],
        R.[DateCreated],
        R.[DateUpdated]
    FROM [dbo].[Receipt] R
    WHERE R.[WineId] = @WineID;

END