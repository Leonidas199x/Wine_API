CREATE TABLE [dbo].[WineRegion]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [RegionID] INT NULL
        FOREIGN KEY REFERENCES [Region]([ID]),
    [Note] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NULL,
    [DateUpdated] DATETIME2(3) NULL
);