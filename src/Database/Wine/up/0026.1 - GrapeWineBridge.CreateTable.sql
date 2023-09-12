CREATE TABLE [dbo].[GrapeWineBridge]
(
    [ID] INT IDENTITY(1,1),
    [WineId] INT NOT NULL
        FOREIGN KEY REFERENCES [dbo].[Wine]([Id]),
    [GrapeId] INT NOT NULL
        FOREIGN KEY REFERENCES [dbo].[Grape]([Id])
);