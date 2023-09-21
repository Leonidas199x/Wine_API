IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Rating_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Rating_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Rating_GetById]
    @Id INT
AS
BEGIN

    SELECT
        R.[Id],
        R.[WineId],
        R.[Note],
        R.[Rating]
    FROM [dbo].[Rating] AS R
    WHERE R.[Id] = @Id;

    SELECT 
        D.[Id],
        D.[Name]
    FROM [dbo].[Drinker] AS D
    INNER JOIN [dbo].[Rating] AS R ON [R].[DrinkerId] = D.[Id]
    WHERE R.[Id] = @Id;

END