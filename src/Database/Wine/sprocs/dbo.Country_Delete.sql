IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_Delete]
    @CountryID	INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE C
    FROM [dbo].[Country] AS C
    WHERE C.[ID] = @CountryID;

END