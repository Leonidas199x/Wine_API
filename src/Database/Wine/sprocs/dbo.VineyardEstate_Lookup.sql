IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_Lookup]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_Lookup] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_Lookup]
AS
BEGIN

    SELECT
        VE.[ID],
        VE.[Name]
    FROM [dbo].[VineyardEstate] AS VE
    ORDER BY VE.[Name] ASC;

END