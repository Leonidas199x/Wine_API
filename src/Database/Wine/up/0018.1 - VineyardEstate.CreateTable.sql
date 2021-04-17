CREATE TABLE [dbo].[VineyardEstate]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [WineRegionId] INT NOT NULL
        FOREIGN KEY REFERENCES [WineRegion]([ID]),
    [Note] NVARCHAR(MAX) NULL,
    [Longitude] DECIMAL(9,6) NULL,
    [Latitude] DECIMAL(8,6) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);