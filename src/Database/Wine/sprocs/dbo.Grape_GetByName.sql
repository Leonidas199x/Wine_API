IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Grape_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Grape_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Grape_GetByName]
    @GrapeName VARCHAR(25)
AS
BEGIN

    SELECT
        G.[ID],
        G.[Name],
        G.[Note],
        G.[DateCreated],
        G.[DateUpdated],
        GC.[ID],
        GC.[Colour]
    FROM [dbo].[Grape] AS G
    LEFT JOIN [dbo].[GrapeColour] AS GC ON G.[GrapeColourID] = GC.[ID]
    WHERE G.[Name] = @GrapeName;

END