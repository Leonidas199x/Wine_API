IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Rating_GetByWineIdAndDrinkerId]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Rating_GetByWineIdAndDrinkerId] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Rating_GetByWineIdAndDrinkerId]
    @WineId INT,
    @DrinkerId INT
AS
BEGIN

    SELECT 
        R.[ID],
        R.[WineId],
        R.[Rating],
        R.[Note],
        D.[ID],
        D.[Name]
    FROM [dbo].[Rating] AS R
    INNER JOIN [dbo].[Drinker] AS D ON R.[DrinkerId] = D.[Id]
    WHERE R.[WineId] = @WineId
        AND D.[Id] = @DrinkerId;

END