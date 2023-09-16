IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_GetAll]
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

    SELECT @TotalPages = CEILING(CAST(COUNT(WT.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[WineType] AS WT;

    SELECT @TotalPages = COUNT(WT.[ID])
    FROM [dbo].[WineType] AS WT;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages], @TotalRecords [TotalRecords];

    SELECT
        WT.[ID],
        WT.[Name],
        WT.[Note],
        WT.[DateCreated],
        WT.[DateUpdated]
    FROM [dbo].[WineType] AS WT
    ORDER BY WT.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END