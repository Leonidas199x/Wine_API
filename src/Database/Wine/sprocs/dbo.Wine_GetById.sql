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
        W.[Description],
        W.[Vintage],
        W.[ABV],
        W.[Importer],
        W.[InventoryLevel],
        W.[DateCreated],
        W.[DateUpdated]
    FROM [dbo].[Wine] AS W
    WHERE W.[ID] = @WineID;

    /*Producer*/
    SELECT
        P.[ID],
        P.[Name],
        P.[Note],
        P.[DateCreated],
        P.[DateUpdated]
    FROM [dbo].[Producer] AS P
    INNER JOIN [dbo].[Wine] AS W ON W.[ProducerID] = P.[ID]
    WHERE W.[ID] = @WineID;

    /*Region*/
    SELECT
        R.[ID],
        R.[Name],
        R.[IsoCode],
        R.[Note],
        R.[Longitude],
        R.[Latitude],
        R.[DateCreated],
        R.[DateUpdated],
        C.[ID],
        C.[Name],
        C.[IsoCode],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[Region] AS R
    INNER JOIN [dbo].[Country] AS C ON R.[CountryID] = C.[ID]
    INNER JOIN [dbo].[Wine] AS W ON W.[RegionID] = R.[ID]
    WHERE W.[ID] = @WineID;

    /*QualityControl*/
    SELECT
        QC.[ID],
        QC.[Name],
        QC.[Note],
        QC.[DateCreated],
        QC.[DateUpdated],
        C.[ID],
        C.[Name],
        C.[IsoCode],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[QualityControl] AS QC
    INNER JOIN [dbo].[Country] AS C ON C.[ID] = QC.[CountryID]
    INNER JOIN [dbo].[Wine] AS W ON W.[QualityControlID] = QC.[ID]
    WHERE W.[ID] = @WineID;

    /*Vineyard Estate*/
    SELECT
        VE.[ID],
        VE.[Name],
        VE.[Note],
        VE.[Longitude],
        VE.[Latitude],
        VE.[DateCreated],
        VE.[DateUpdated]
    FROM [dbo].[VineyardEstate] AS VE
    INNER JOIN [dbo].[Wine] AS W ON W.[VinyardEstateID] = VE.[ID]
    WHERE W.[ID] = @WineID;

    /*Wine Type*/
    SELECT
        WT.[ID],
        WT.[Name],
        WT.[Note],
        WT.[DateCreated],
        WT.[DateUpdated]
    FROM [dbo].[WineType] AS WT
    INNER JOIN [dbo].[Wine] AS W ON W.[WineTypeID] = WT.[ID]
    WHERE W.[ID] = @WineID;

    /*Retailer*/
    SELECT
        R.[ID],
        R.[Name],
        R.[MinimumPurchaseQuantity],
        R.[IncrementQuantity],
        R.[GenericDiscountPercentage],
        R.[GenericDiscountName],
        R.[WebsiteUrl],
        R.[WebsiteRating],
        R.[OrderRating],
        R.[DeliveryRating],
        R.[MaxCustomerRating],
        R.[Note],
        R.[DateCreated],
        R.[DateUpdated]
    FROM [dbo].[Retailer] AS R
    INNER JOIN [dbo].[Wine] AS W ON W.[ExclusiveToRetailerID] = R.[ID]
    WHERE W.[ID] = @WineID;

    /*Ratings*/
    SELECT
        R.[Id],
        R.[WineId],
        R.[Rating],
        R.[Note],
        D.[ID],
        D.[Name]
    FROM [dbo].[Rating] AS R
    INNER JOIN [dbo].[Drinker] AS D ON D.[ID] = R.[DrinkerId]
    WHERE R.[WineId] = @WineID;

    /*Grapes*/
    SELECT
        G.[ID],
        G.[Name],
        G.[Note],
        G.[DateCreated],
        G.[DateUpdated],
        GC.[ID],
        GC.[Colour]
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