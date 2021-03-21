CREATE TABLE [dbo].[Producer]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NULL,
    [ShortNote] NVARCHAR(25) NULL,
    [Note] NVARCHAR(50) NULL,
    [DateCreated] DATETIME2(3) NULL,
    [DateUpdated] DATETIME2(3) NULL
);