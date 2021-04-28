IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Drinker_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Drinker_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Drinker_Lookup]
AS
BEGIN

    SELECT
        D.[ID],
        D.[Name]
    FROM [dbo].[Drinker] AS D
    ORDER BY D.[Name] ASC;

END