﻿IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[QualityControl_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[QualityControl_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[QualityControl_GetById]
    @QualityControlId INT
AS
BEGIN

    SELECT
        QC.[ID],
        QC.[Name],
        QC.[Note],
        QC.[DateCreated],
        QC.[DateUpdated], 
        C.[ID],
        C.[Name],
        C.[IsoCode],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[QualityControl] AS QC
    INNER JOIN [dbo].[Country] AS C ON QC.[CountryID] = C.[ID]
    WHERE QC.[ID] = @QualityControlId;

END