﻿IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_GetById]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_GetById] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_GetById]
    @RegionId INT
AS
BEGIN

    SELECT
        R.[ID],
        R.[Name],
        R.[IsoCode],
        R.[Note],
        R.[Longitude],
        R.[Latitude],
        R.[DateCreated],
        R.[DateUpdated]
    FROM [dbo].[Region] AS R
    WHERE R.[ID] = @RegionId;

    SELECT
        C.[ID],
        C.[Name],
        C.[IsoCode],
        C.[Note],
        C.[DateCreated],
        C.[DateUpdated]
    FROM [dbo].[Country] AS C
    INNER JOIN [dbo].[Region] AS R ON C.[ID] = R.[CountryID]
    WHERE R.[ID] = @RegionId;

END