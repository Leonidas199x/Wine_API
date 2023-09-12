IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Grape_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Grape_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Grape_GetById]
    @GrapeID INT
AS
BEGIN

    SELECT
        G.[ID],
        G.[Name],
        G.[Note],
        G.[DateCreated],
        G.[DateUpdated]
    FROM [dbo].[Grape] AS G
    LEFT JOIN [dbo].[GrapeColour] AS GC ON G.[GrapeColourID] = GC.[ID]
    WHERE G.[ID] = @GrapeID;

    SELECT
        C.[ID],
        C.[Colour]
    FROM [dbo].[GrapeColour] AS C
    LEFT JOIN [dbo].[Grape] AS G ON G.[GrapeColourID] = C.[ID]
    WHERE G.[ID] = @GrapeID;

END