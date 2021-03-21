CREATE TABLE [dbo].[WineType]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [WineType] NVARCHAR(50) NULL,
    [Note] NVARCHAR(max) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);