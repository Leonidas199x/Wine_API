IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Rating_GetByWineId]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Rating_GetByWineId] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Rating_GetByWineId]
    @WineId INT
AS
BEGIN

    SELECT 
        R.[ID],
        R.[WineId],
        R.[Note],
        D.[ID],
        D.[Name]
    FROM [dbo].[Rating] AS R
    INNER JOIN [dbo].[Drinker] AS D ON R.[DrinkerId] = D.[Id]
    WHERE R.[WineId] = @WineId;

END