CREATE TABLE [dbo].[QualityControl]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [CountryID] INT NULL
        FOREIGN KEY REFERENCES [Country]([ID]),
    [QualityControlName] NVARCHAR(50) NOT NULL,
    [QualityControlShortNote] NVARCHAR(50) NULL,
    [QualityControlNotes] NVARCHAR(max) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);