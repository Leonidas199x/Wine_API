IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Issue_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Issue_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Issue_Delete]
    @Id INT
AS
BEGIN

    DELETE I
    FROM [dbo].[Issue] AS I
    WHERE I.[Id] = @Id;

END