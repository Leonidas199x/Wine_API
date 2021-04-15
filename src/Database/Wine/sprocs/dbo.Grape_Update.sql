IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Grape_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Grape_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Grape_Update]
    @GrapeID INT,
    @GrapeName NVARCHAR(50),
    @GrapeColourID INT,
    @GrapeNote NVARCHAR(100)
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE G
    SET
        G.[Name] = @GrapeName,
        G.[GrapeColourID] = @GrapeColourID,
        G.[Note] = @GrapeNote,
        G.[DateUpdated] = GETDATE()
    FROM [dbo].[Grape] AS G
    WHERE G.[ID] = @GrapeID;

END