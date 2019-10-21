﻿CREATE PROCEDURE [dbo].[GetGrapes]

AS
BEGIN

	SET NOCOUNT ON;

    SELECT	G.GrapeID								,
      		G.GrapeName								,
      		G.GrapeColourID							,
			GC.GrapeColour							,
      		G.GrapeNote								,
      		G.GrapeAlternateName					,
      		G.DateCreated							,
      		G.DateUpdated
  FROM		Grapes				AS	G
  LEFT JOIN	GrapeColour			AS	GC	ON	G.GrapeColourID = GC.GrapeColourID;
END