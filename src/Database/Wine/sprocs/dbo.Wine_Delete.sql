IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Wine_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Wine_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Wine_Delete]
    @Id INT
AS
BEGIN

    DELETE R
    FROM [dbo].[Rating] AS R
    WHERE R.[WineId] = @Id;

    DELETE I
    FROM [dbo].[Issue] AS I
    WHERE I.[WineId] = @Id;

    DELETE GWB
    FROM [dbo].[GrapeWineBridge] AS GWB
    WHERE GWB.[WineId] = @Id;

    DELETE W
    FROM [dbo].[Wine] AS W
    WHERE W.[ID] = @Id;

END