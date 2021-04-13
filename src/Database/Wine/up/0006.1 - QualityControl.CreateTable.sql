CREATE TABLE [dbo].[QualityControl]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [CountryID] INT NULL
        FOREIGN KEY REFERENCES [Country]([ID]),
    [QualityControlName] NVARCHAR(50) NOT NULL,
    [QualityControlNotes] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);