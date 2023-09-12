IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_GetByNameAndCountryId]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_GetByNameAndCountryId] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_GetByNameAndCountryId]
    @Name NVARCHAR(50),
    @CountryId INT
AS
BEGIN

    SELECT
        QC.[ID],
        QC.[Name],
        QC.[Note],
        QC.[CountryId],
        QC.[DateCreated],
        QC.[DateUpdated]
    FROM [dbo].[QualityControl] AS QC
    WHERE QC.[Name] = @Name
        AND QC.[CountryId] = @CountryId;

END