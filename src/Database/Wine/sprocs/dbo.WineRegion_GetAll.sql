IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineRegion_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineRegion_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineRegion_GetAll]
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

    SELECT @TotalPages = CEILING(CAST(COUNT(WR.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[WineRegion] AS WR;

    SELECT @TotalRecords = COUNT(WR.[ID])
    FROM [dbo].[WineRegion] AS WR;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages], @TotalRecords [TotalRecords];

    SELECT
        WR.[ID],
        WR.[Name],
        WR.[Note],
        WR.[DateCreated],
        WR.[DateUpdated],
        R.[ID],
        R.[Name],
        R.[IsoCode],
        R.[Note],
        R.[Latitude],
        R.[Longitude],
        C.[ID],
        C.[Name],
        C.[IsoCode]
    FROM [dbo].[WineRegion] AS WR
    INNER JOIN [dbo].[Region] AS R ON R.[ID] = WR.[RegionId]
    INNER JOIN [dbo].[Country] AS C ON C.[ID] = R.[CountryId]
    ORDER BY WR.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END