CREATE TABLE [dbo].[Grape]
(
    [ID] [int] IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(25) NOT NULL,
    [GrapeColourID] INT NULL
        FOREIGN KEY REFERENCES [GrapeColour]([ID]),
    [Note] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);