﻿CREATE TABLE [dbo].[Region]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [IsoCode] NVARCHAR(10) NOT NULL,
    [CountryID] INT NOT NULL
        FOREIGN KEY REFERENCES [Country]([ID]),
    [Note] NVARCHAR(MAX) NULL,
    [Longitude] DECIMAL(9,6) NULL,
    [Latitude] DECIMAL(8,6) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);