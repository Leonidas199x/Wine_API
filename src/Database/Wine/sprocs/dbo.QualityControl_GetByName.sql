IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_GetByName]
    @Name NVARCHAR(50)
AS
BEGIN

    SELECT
        QC.[ID],
        QC.[Name],
        QC.[Note],
        QC.[DateCreated],
        QC.[DateUpdated]
    FROM [dbo].[QualityControl] AS QC
    WHERE QC.[Name] = @Name;

END