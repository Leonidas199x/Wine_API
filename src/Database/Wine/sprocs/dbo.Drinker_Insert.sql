IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Drinker_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Drinker_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Drinker_Insert]
    @Name NVARCHAR(255)
AS
BEGIN

    INSERT INTO [dbo].[Drinker]
    (
        [Name]
    )
    VALUES
    (
        @Name
    );

END