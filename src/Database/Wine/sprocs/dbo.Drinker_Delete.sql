IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Drinker_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Drinker_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Drinker_Delete]
    @DrinkerId INT
AS
BEGIN

    DELETE D
    FROM [dbo].[Drinker] AS D
    WHERE D.[ID] = @DrinkerId;

END