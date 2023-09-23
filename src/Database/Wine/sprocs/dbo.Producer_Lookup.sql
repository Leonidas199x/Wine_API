IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Producer_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Producer_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Producer_Lookup]
AS
BEGIN

    SELECT
        P.[ID],
        P.[Name]
    FROM [dbo].[Producer] AS P
    ORDER BY P.[Name] ASC;

END