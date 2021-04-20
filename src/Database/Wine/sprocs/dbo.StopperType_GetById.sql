IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[StopperType_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[StopperType_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[StopperType_GetById]
    @StopperTypeId INT
AS
BEGIN

    SELECT
        ST.[ID],
        ST.[Name]
    FROM [dbo].[StopperType] AS ST
    WHERE ST.[ID] = @StopperTypeId;

END