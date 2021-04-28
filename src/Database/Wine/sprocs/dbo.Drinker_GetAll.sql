IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Drinker_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Drinker_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Drinker_GetAll]
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
    
    SELECT @TotalPages = CEILING(CAST(COUNT(D.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[Drinker] D;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

    /*Data*/
    SELECT
        D.[ID],
        D.[Name]
    FROM [dbo].[Drinker] AS D
    ORDER BY D.[Name] ASC;

END