﻿IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Region_GetByIsoCode]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Region_GetByIsoCode] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Region_GetByIsoCode]
    @IsoCode NVARCHAR(10)
AS
BEGIN

    SELECT
        R.[ID],
        R.[CountryID],
        R.[Name],
        R.[IsoCode],
        R.[Note],
        R.[Longitude],
        R.[Latitude],
        R.[DateCreated],
        R.[DateUpdated]
    FROM [dbo].[Region] AS R
    WHERE R.[IsoCode] = @IsoCode;

END