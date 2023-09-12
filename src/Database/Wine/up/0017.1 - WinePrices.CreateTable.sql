CREATE TABLE [dbo].[WinePrice]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [WineId] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID]),
    [RetailerWineId] INT NOT NULL
        FOREIGN KEY REFERENCES [RetailerWine]([ID]),
    [EffectiveDate] DATE NOT NULL,
    [FullPrice] MONEY NOT NULL,
    [DiscountPrice] MONEY NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);