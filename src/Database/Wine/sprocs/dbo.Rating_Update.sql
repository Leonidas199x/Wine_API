IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Rating_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Rating_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Rating_Update]
    @Id INT,
    @DrinkerId INT,
    @WineId INT,
    @Rating INT,
    @Note NVARCHAR(MAX)
AS
BEGIN

    UPDATE R
    SET
        R.[DrinkerId] = @DrinkerId,
        R.[WineId] = @WineID,
        R.[Rating] = @Rating,
        R.[Note] = @Note
    FROM [dbo].[Rating] AS R
    WHERE R.[Id] = @Id;

END