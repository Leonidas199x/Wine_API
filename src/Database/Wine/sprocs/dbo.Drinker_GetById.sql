IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Drinker_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Drinker_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Drinker_GetById]
    @DrinkerId INT
AS
BEGIN

    SELECT
        D.[ID],
        D.[Name]
    FROM [dbo].[Drinker] AS D
    WHERE D.[ID] = @DrinkerId;

END