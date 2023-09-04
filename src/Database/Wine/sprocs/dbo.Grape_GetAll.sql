IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Grape_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Grape_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Grape_GetAll]
    @Page INT = 1,
    @PageSize INT = 10
AS
BEGIN

    DECLARE @Offset INT;

    IF(@Page = 1)
    BEGIN 
        SELECT @Offset = 0;
    END
    ELSE
    BEGIN
        SELECT @Offset = (@PageSize * (@Page - 1));
    END

    DECLARE @TotalPages INT;

    SELECT @TotalPages = CEILING(CAST(COUNT(G.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[Grape] G;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

    SELECT
        G.[ID],
        G.[Name],
        G.[Note],
        G.[DateCreated],
        G.[DateUpdated],
        GC.[ID],
        GC.[Colour]
    FROM [dbo].[Grape] AS G
    INNER JOIN [dbo].[GrapeColour] AS GC ON G.[GrapeColourId] = GC.[ID];

END