IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_Search]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_Search] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_Search]
    @Name NVARCHAR(50),
    @IsoCode NVARCHAR(2),
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

    SELECT @TotalPages = CEILING(CAST(COUNT(C.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[Country] C
    WHERE C.[Name] LIKE '%' + ISNULL(@Name, C.[Name]) + '%'
        AND C.[IsoCode] LIKE '%' +  ISNULL(@IsoCode, C.[IsoCode]) + '%';

    SELECT @TotalRecords = COUNT(C.[ID])
    FROM [dbo].[Country] C
    WHERE C.[Name] LIKE '%' + ISNULL(@Name, C.[Name]) + '%'
        AND C.[IsoCode] LIKE '%' +  ISNULL(@IsoCode, C.[IsoCode]) + '%';

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages], @TotalRecords [TotalRecords];

    /*Data*/
    SELECT
        C.[ID],
        C.[Name],
        C.[IsoCode],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[Country] AS C
    WHERE C.[Name] LIKE '%' + ISNULL(@Name, C.[Name]) + '%'
        AND C.[IsoCode] LIKE '%' +  ISNULL(@IsoCode, C.[IsoCode]) + '%'
    ORDER BY C.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END