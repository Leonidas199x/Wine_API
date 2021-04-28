IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[RetailerWine_GetByName]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[RetailerWine_GetByName] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[RetailerWine_GetByName]
    @Name NVARCHAR(50)
AS
BEGIN

    SELECT 
        RW.[ID],
        RW.[Name],
        RW.[RetailerId],
        RW.[WineId],
        RW.[Description],
        RW.[Discontinued],
        RW.[RetailerTasteGuide],
        RW.[StopperTypeId],
        RW.[WineCode],
        RW.[CustomerRating],
        RW.[TastingNotes],
        RW.[StorageNotes],
        RW.[Range],
        RW.[DateCreated],
        RW.[DateUpdated]
    FROM [dbo].[RetailerWine] AS RW
    WHERE RW.[Name] = @Name;

END