IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Producer_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Producer_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Producer_Delete]
    @ProducerId INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE P
    FROM [dbo].[Producer] AS P
    WHERE P.[ID] = @ProducerId;

END