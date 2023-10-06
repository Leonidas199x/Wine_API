CREATE TABLE [dbo].[SimilarWine]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [WineId] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID]),
    [SimilarWineId] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID])
);