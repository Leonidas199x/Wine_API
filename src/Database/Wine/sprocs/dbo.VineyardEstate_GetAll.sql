IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_GetAll]
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

    SELECT @TotalRecords = COUNT(VE.[ID])
    FROM [dbo].[VineyardEstate] AS VE;

    SELECT @TotalPages = CEILING(CAST(COUNT(VE.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[VineyardEstate] AS VE;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages], @TotalRecords [TotalRecords];

    SELECT
        VE.[ID],
        VE.[Name],
        VE.[Note],
        VE.[Longitude],
        VE.[Latitude],
        VE.[DateCreated],
        VE.[DateUpdated]
    FROM [dbo].[VineyardEstate] AS VE
    ORDER BY VE.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END