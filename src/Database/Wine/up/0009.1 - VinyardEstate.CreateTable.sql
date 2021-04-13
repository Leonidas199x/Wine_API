CREATE TABLE [dbo].[VinyardEstate]
(
    [ID] INT IDENTITY(1,1) NOT NULL
        PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [VinyardEstateNote] NVARCHAR(MAX) NULL,
    [DateCreated] DATETIME2(3) NOT NULL,
    [DateUpdated] DATETIME2(3) NOT NULL
);