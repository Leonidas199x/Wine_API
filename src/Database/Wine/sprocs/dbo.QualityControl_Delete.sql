IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_Delete]
    @QualityControlId INT
AS
BEGIN

    DELETE QC
    FROM [dbo].[QualityControl] AS QC
    WHERE QC.[ID] = @QualityControlId;

END