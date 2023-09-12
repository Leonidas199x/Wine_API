IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Drinker_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Drinker_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Drinker_Update]
    @DrinkerId INT,
    @Name NVARCHAR(255)
AS
BEGIN

    UPDATE D
    SET
        D.[Name] = @Name
    FROM [dbo].[Drinker] AS D
    WHERE D.[ID] = @DrinkerId;

END