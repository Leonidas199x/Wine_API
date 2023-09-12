CREATE TABLE [dbo].[Receipt]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [WineId] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID]),
    [RetailerId] INT NULL
        FOREIGN KEY REFERENCES [Retailer]([ID]),
    [Date] DATE NOT NULL,
    [Quantity] TINYINT NOT NULL,
    [Note] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);