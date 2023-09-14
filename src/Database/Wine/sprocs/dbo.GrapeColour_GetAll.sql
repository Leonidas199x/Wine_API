IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[GrapeColour_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[GrapeColour_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[GrapeColour_GetAll]
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

    DECLARE @TotalPages INT, @TotalRecords INT;
    
    SELECT @TotalPages = CEILING(CAST(COUNT(GC.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[GrapeColour] AS GC;

    SELECT @TotalRecords = COUNT(GC.[ID])
    FROM [dbo].[GrapeColour] AS GC;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages], @TotalRecords [TotalRecords];

    SET NOCOUNT ON;

    SELECT
        GC.[ID],
        GC.[Colour]
    FROM [dbo].[GrapeColour] AS GC
    ORDER BY GC.[Colour], GC.[ID]
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END