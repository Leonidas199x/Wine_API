CREATE TABLE [dbo].[Issue]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [WineId] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID]),
    [Date] DATE NOT NULL,
    [Quantity] TINYINT NOT NULL,
    [Notes] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);