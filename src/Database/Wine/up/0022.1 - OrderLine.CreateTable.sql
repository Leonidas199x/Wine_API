CREATE TABLE [dbo].[OrderLine]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [OrderId] INT NOT NULL
        FOREIGN KEY REFERENCES [Order]([ID]),
    [RetailerWineId] INT NOT NULL
        FOREIGN KEY REFERENCES [RetailerWine]([ID]),
    [Quantity] TINYINT NOT NULL,
    [Price] MONEY NOT NULL,
    [DiscountedPrice] MONEY NOT NULL,
    [EffectivePrice] MONEY NOT NULL,
    [Cancelled] BIT NULL,
    [Note] VARCHAR(MAX) NULL
);