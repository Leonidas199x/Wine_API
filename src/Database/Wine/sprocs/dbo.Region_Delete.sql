IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_Delete]
    @RegionID INT
AS
BEGIN

    SET NOCOUNT ON;

    DELETE R
    FROM [dbo].[Region] AS R
    WHERE R.[ID] = @RegionID;

END