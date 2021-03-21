CREATE TABLE [dbo].[GrapeAlternateName]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [GrapeId] INT NOT NULL
        FOREIGN KEY REFERENCES [Grape]([ID]),
    [AlternateName] NVARCHAR(250) NOT NULL
);