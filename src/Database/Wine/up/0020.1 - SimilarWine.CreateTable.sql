CREATE TABLE [dbo].[SimilarWine]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [WineOne] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID]),
    [WineTwo] INT NOT NULL
        FOREIGN KEY REFERENCES [Wine]([ID])
);