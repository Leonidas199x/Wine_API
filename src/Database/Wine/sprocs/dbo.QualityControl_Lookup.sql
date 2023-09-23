IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_Lookup]
AS
BEGIN

    SELECT
        Q.[ID],
        Q.[Name]
    FROM [dbo].[QualityControl] AS Q
    ORDER BY Q.[Name] ASC;

END