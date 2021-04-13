CREATE TABLE [dbo].[Country](
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NULL,
    [Note] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);