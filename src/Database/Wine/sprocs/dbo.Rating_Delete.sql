IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Rating_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Rating_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Rating_Delete]
    @Id INT
AS
BEGIN

    DELETE R
    FROM [dbo].[Rating] AS R
    WHERE R.[Id] = @Id;

END