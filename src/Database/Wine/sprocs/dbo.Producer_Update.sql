IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Producer_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Producer_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Producer_Update]
    @ProducerId INT,
    @ProducerName NVARCHAR(50),
    @ProducerNote NVARCHAR(MAX)
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE P
    SET
        P.[Name] = @ProducerName,
        P.[Note] = @ProducerNote,
        P.[DateUpdated] = GETDATE()
    FROM [dbo].[Producer] P
    WHERE P.[ID] = @ProducerId;

END