-- =============================================
-- Author:		Toby Prince
-- Create date: 31st January 2017
-- Description:	Get wine
-- =============================================
CREATE PROCEDURE [dbo].[spGetWine]

	@intWineID INT
AS
BEGIN
	
SET NOCOUNT ON;

SELECT W.WineID,W.[Description],R.RegionName
FROM Wine AS W
LEFT JOIN Producer AS P ON P.ProducerID = W.ProducerID
LEFT JOIN Region AS R ON R.RegionID = W.RegionID
LEFT JOIN QualityControl AS QC ON QC.QualityControlID = W.QualityControlID
LEFT JOIN VinyardEstate AS VE ON VE.VinyardEstateID = W.VinyardEstateID
LEFT JOIN WineType AS WT ON WT.WineTypeID = W.WineTypeID
WHERE W.WineID = @intWineID
END