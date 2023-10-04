CREATE TABLE [dbo].[Wine]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [ProducerID] INT NULL
        FOREIGN KEY REFERENCES [Producer]([ID]),
    [RegionID] INT NOT NULL
        FOREIGN KEY REFERENCES [Region]([ID]),
    [Vintage] INT NULL,
    [QualityControlID] INT NULL
        FOREIGN KEY REFERENCES [QualityControl]([ID]),
    [VinyardEstateID] INT NULL
        FOREIGN KEY REFERENCES [VineyardEstate]([ID]),
    [WineTypeID] INT NULL
        FOREIGN KEY REFERENCES [WineType]([ID]),
    [Description] NVARCHAR(100) NOT NULL,
    [ABV] DECIMAL(4, 2) NOT NULL,
    [Importer] NVARCHAR(25) NULL,
    [InventoryLevel] TINYINT NULL,
    [ExclusiveToRetailerID] INT NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);