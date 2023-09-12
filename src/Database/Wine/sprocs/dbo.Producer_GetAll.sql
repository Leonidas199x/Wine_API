IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Producer_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Producer_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Producer_GetAll]
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
    
    SELECT @TotalPages = CEILING(CAST(COUNT(P.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[Producer] P;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

    SELECT
        P.[ID],
        P.[Name],
        P.[Note],
        P.[DateCreated],
        P.[DateUpdated]
    FROM [dbo].[Producer] AS P
    ORDER BY P.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END