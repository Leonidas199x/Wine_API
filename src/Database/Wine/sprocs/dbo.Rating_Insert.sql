IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Rating_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Rating_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Rating_Insert]
    @DrinkerId INT,
    @WineId INT,
    @Rating INT,
    @Note NVARCHAR(MAX)
AS
BEGIN

    INSERT INTO [dbo].[Rating]
    (
        [DrinkerId],
        [WineId],
        [Rating],
        [Note]
    )
    VALUES
    (
        @DrinkerId,
        @WineId,
        @Rating,
        @Note
    );

END