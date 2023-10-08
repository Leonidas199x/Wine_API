IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Grape_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Grape_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Grape_Lookup]
AS
BEGIN

    SELECT
        G.[ID],
        G.[Name]
    FROM [dbo].[Grape] AS G
    ORDER BY G.[Name] ASC;

END