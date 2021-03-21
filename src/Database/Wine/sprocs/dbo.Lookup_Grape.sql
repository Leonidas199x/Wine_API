IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Lookup_Grape]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Lookup_Grape] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Lookup_Grape]
AS
BEGIN

    SELECT 
        G.[ID],
        G.[Name]
    FROM [dbo].[Grape] AS G
    ORDER BY [Name] ASC;

END