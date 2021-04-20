IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_Update]
    @QualityControlId INT,
    @Name NVARCHAR(50),
    @Note NVARCHAR(MAX),
    @CountryId INT
AS
BEGIN

    UPDATE QC
    SET
        [CountryId] = @CountryId,
        [Name] = @Name,
        [Note] = @Note,
        [DateUpdated] = GETDATE()
    FROM [dbo].[QualityControl] AS QC
    WHERE QC.[ID] = @QualityControlId;

END