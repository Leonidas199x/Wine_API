CREATE TABLE [dbo].[Retailer]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [RetailerId] INT NOT NULL
        FOREIGN KEY REFERENCES [Retailer]([ID]),
    [WineId] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID]),
    [Description] NVARCHAR(100) NOT NULL,
    [Discontinued] BIT NULL,
    [RetailerTasteGuide] NVARCHAR(20) NULL,
    [StopperTypeId] INT NULL
        FOREIGN KEY REFERENCES [StopperType]([ID]),
    [WineCode] NVARCHAR(50) NULL,
    [CustomerRating] DECIMAL(4,2) NULL,
    [TastingNotes] NVARCHAR(MAX) NULL,
    [StorageNotes] NVARCHAR(MAX) NULL,
    [Range] NVARCHAR(20) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);