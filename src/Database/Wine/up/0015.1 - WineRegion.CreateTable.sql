CREATE TABLE [dbo].[WineRegion]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [RegionId] INT NOT NULL
        FOREIGN KEY REFERENCES [Region]([ID]),
    [Note] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);