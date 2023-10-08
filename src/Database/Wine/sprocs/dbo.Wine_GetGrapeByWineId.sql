IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_GetGrapeByWineId]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_GetGrapeByWineId] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_GetGrapeByWineId]
    @WineId INT
AS
BEGIN

    SELECT 
        WG.[ID],
        WG.[WineId],
        WG.[GrapeId],
        G.[ID],
        G.[Name],
        G.[GrapeColourID],
        G.[Note],
        G.[DateCreated],
        G.[DateUpdated]
    FROM [dbo].[GrapeWineBridge] AS WG
    INNER JOIN [dbo].[Grape] AS G ON WG.[GrapeId] = G.[ID]
    WHERE WG.[WineId] = @WineId;

END