IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Country_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Country_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Country_Update]
    @CountryName NVARCHAR(50),
    @CountryNote NVARCHAR(500),
    @CountryID INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE C
    SET
        C.[Note] = @CountryNote,
        C.[Name] = @CountryName,
        C.[DateUpdated] = GETDATE()
    FROM [dbo].[Country] AS C
    WHERE C.[ID] = @CountryID;

END