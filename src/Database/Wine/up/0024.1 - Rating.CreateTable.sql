CREATE TABLE [dbo].[Rating]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [DrinkerId] INT NOT NULL
        FOREIGN KEY REFERENCES [Drinker]([ID]),
    [WineId] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID]),
    [Rating] INT NOT NULL,
    [Note] NVARCHAR(MAX)
);