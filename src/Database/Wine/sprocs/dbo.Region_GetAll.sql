IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_GetAll]
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

    SELECT @TotalPages = CEILING(CAST(COUNT(R.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[Region] R;

    SELECT @TotalRecords = COUNT(R.[ID])
    FROM [dbo].[Region] AS R
    LEFT JOIN [dbo].[Country] AS C ON R.[CountryId] = C.[ID];

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

    /*Data*/
    SELECT
        R.[ID],
        R.[Name],
        R.[IsoCode],
        R.[Note],
        R.[Longitude],
        R.[Latitude],
        R.[DateCreated],
        R.[DateUpdated],
        C.[ID],
        C.[Name],
        C.[IsoCode],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[Region] AS R
    LEFT JOIN [dbo].[Country] AS C ON R.[CountryId] = C.[ID]
    ORDER BY R.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END