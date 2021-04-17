IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Producer_GetAll]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Producer_GetAll] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Producer_GetAll]
    @ProducerId INT
AS
BEGIN

    SELECT
        P.[ID],
        P.[Name],
        P.[Note],
        P.[DateCreated],
        P.[DateUpdated]
    FROM [dbo].[Producer] AS P
    WHERE P.[ID] = @ProducerId;

END