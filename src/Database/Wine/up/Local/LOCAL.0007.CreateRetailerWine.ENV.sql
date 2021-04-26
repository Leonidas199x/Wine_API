INSERT INTO [dbo].[RetailerWine]
(
    [Name],
    [RetailerId],
    [WineId],
    [Description],
    [DateCreated],
    [DateUpdated]
)
VALUES
(
    'Test Retailer Wine',
    1,
    1,
    'Retailer and stuff',
    GETDATE(),
    GETDATE()
);