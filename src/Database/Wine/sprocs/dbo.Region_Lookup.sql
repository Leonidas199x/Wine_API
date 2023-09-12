IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_Lookup]
AS
BEGIN

    SELECT
        R.[ID],
        R.[Name]
    FROM [dbo].[Region] AS R
    ORDER BY R.[Name] ASC;

END