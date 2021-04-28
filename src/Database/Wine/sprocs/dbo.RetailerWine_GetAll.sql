IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[RetailerWine_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[RetailerWine_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[RetailerWine_GetAll]
    @Page INT,
    @PageSize INT

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
    
    SELECT @TotalPages = CEILING(CAST(COUNT(RW.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[RetailerWine] AS RW;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

    SELECT 
        RW.[ID],
        RW.[Name],
        RW.[RetailerId],
        RW.[WineId],
        RW.[Description],
        RW.[Discontinued],
        RW.[RetailerTasteGuide],
        RW.[StopperTypeId],
        RW.[WineCode],
        RW.[CustomerRating],
        RW.[TastingNotes],
        RW.[StorageNotes],
        RW.[Range],
        RW.[DateCreated],
        RW.[DateUpdated]
    FROM [dbo].[RetailerWine] AS RW
    ORDER BY RW.[Name]
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END