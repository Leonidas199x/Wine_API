IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[WineType_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[WineType_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[WineType_Lookup]
AS
BEGIN

    SELECT
        WT.[ID],
        WT.[Name]
    FROM [dbo].[WineType] AS WT
    ORDER BY WT.[Name] ASC;

END