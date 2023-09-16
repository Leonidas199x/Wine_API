IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_GetAll]
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

    SELECT @TotalRecords = COUNT(W.[ID])
    FROM [dbo].[Wine] AS W;

    SELECT @TotalPages = CEILING(CAST(COUNT(W.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[Wine] AS W;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages], @TotalRecords [TotalRecords];

    SELECT
        W.[ID],
        W.[Description],
        WT.[Name] AS [WineType]
    FROM [dbo].[Wine] AS W
    LEFT JOIN [dbo].[WineType] WT ON W.[WineTypeID] = WT.[ID]
    ORDER BY W.[Description] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END