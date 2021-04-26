INSERT INTO [dbo].[Retailer]
(
    [Name],
    [MinimumPurchaseQuantity],
    [IncrementQuantity],
    [MaxCustomerRating],
    [DateCreated],
    [DateUpdated]
)
VALUES
(
    'Test Retailer',
    1,
    1,
    10,
    GETDATE(),
    GETDATE()
);