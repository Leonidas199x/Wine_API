CREATE TABLE [dbo].[Region]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [CountryID] INT NOT NULL
        FOREIGN KEY REFERENCES [Country]([ID]),
    [Note] NVARCHAR(500) NULL,
    [LocationRegionImage] NVARCHAR(100) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);