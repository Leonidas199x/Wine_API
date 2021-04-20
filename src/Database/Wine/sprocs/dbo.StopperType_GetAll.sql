IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[StopperType_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[StopperType_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[StopperType_GetAll]

AS
BEGIN

    SELECT
        ST.[ID],
        ST.[Name]
    FROM [dbo].[StopperType] AS ST
    ORDER BY ST.[Name] ASC;

END