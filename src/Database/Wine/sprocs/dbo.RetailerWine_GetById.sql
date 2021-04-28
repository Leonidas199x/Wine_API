IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[RetailerWine_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[RetailerWine_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[RetailerWine_GetById]
    @RetailerWineId INT
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
    WHERE RW.[Id] = @RetailerWineId;

END