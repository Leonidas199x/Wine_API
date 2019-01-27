-- =============================================
-- Author:		Toby Prince
-- Create date: 15/02/2017
-- Description:	Get grape colours
-- =============================================
CREATE PROCEDURE [dbo].[spGetGrapeColours]
AS
BEGIN
	
SET NOCOUNT ON;

SELECT		GC.GrapeColourID	,
			GC.GrapeColour
FROM		dbo.GrapeColour		AS GC
ORDER BY	GC.GrapeColour		ASC;

END