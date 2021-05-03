IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[StopperType_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[StopperType_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[StopperType_GetAll]
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
    
    SELECT @TotalPages = CEILING(CAST(COUNT(ST.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[StopperType] ST;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

    SELECT
        ST.[ID],
        ST.[Name]
    FROM [dbo].[StopperType] AS ST
    ORDER BY ST.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END