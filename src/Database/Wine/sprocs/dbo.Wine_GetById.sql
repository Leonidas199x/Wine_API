IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_GetById]
    @WineID INT
AS
BEGIN

    SELECT 
        W.[ID],
        W.[Description],
        R.[Name]
    FROM [dbo].[Wine] AS W
    LEFT JOIN [dbo].[Producer] AS P ON P.[ID] = W.[ProducerID]
    LEFT JOIN [dbo].[Region] AS R ON R.[ID] = W.[RegionID]
    LEFT JOIN [dbo].[QualityControl] AS QC ON QC.[ID] = W.[QualityControlID]
    LEFT JOIN [dbo].[VinyardEstate] AS VE ON VE.[ID] = W.[VinyardEstateID]
    LEFT JOIN [dbo].[WineType] AS WT ON WT.[ID] = W.[WineTypeID]
    WHERE W.[ID] = @WineID;

END