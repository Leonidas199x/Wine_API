IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Issue_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Issue_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Issue_GetById]
    @Id INT
AS
BEGIN

    SELECT
        I.[Id],
        I.[WineId],
        I.[Note],
        I.[Date],
        I.[Quantity],
        I.[DateCreated],
        I.[DateUpdated]
    FROM [dbo].[Issue] AS I
    WHERE I.[Id] = @Id;

END