IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_GetAll]
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
    
    SELECT @TotalPages = CEILING(CAST(COUNT(QC.[ID]) AS FLOAT)/@PageSize) 
    FROM [dbo].[QualityControl] QC;

    /*Paging info*/
    SELECT @Page [Page], @PageSize [PageSize], @TotalPages [TotalPages];

    SELECT
        QC.[ID],
        QC.[Name],
        QC.[Note],
        QC.[CountryId],
        QC.[DateCreated],
        QC.[DateUpdated]
    FROM [dbo].[QualityControl] AS QC
    ORDER BY QC.[Name] ASC
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

END