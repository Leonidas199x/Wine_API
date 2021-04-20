IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_GetAll]
AS
BEGIN

    SELECT
        QC.[ID],
        QC.[Name],
        QC.[Note],
        QC.[DateCreated],
        QC.[DateUpdated]
    FROM [dbo].[QualityControl] AS QC
    ORDER BY QC.[Name] ASC;

END