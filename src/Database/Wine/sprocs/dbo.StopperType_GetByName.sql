IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[StopperType_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[StopperType_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[StopperType_GetByName]
    @Name NVARCHAR(50)
AS
BEGIN

    SELECT
        ST.[ID],
        ST.[Name]
    FROM [dbo].[StopperType] AS ST
    WHERE ST.[Name] = @Name;

END