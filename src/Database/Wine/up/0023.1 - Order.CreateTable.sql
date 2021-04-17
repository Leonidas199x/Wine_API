CREATE TABLE [dbo].[Order]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [RetailerId] INT NOT NULL
        FOREIGN KEY REFERENCES [Retailer]([ID]),
    [Created] DATE NOT NULL,
    [DateOrdered] DATE NULL,
    [DateReceived] DATE NULL,
    [DiscountValue] MONEY NULL,
    [DiscountValueDescription] NVARCHAR(20) NULL,
    [DiscountPercentage] DECIMAL(4,2) NULL,
    [DiscountPercentageDescription] NVARCHAR(20) NULL,
    [Note] VARCHAR(MAX) NULL
);