IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[VineyardEstate_Delete]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[VineyardEstate_Delete] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[VineyardEstate_Delete]
    @VineyardEstateId INT
AS
BEGIN

    DELETE VE
    FROM [dbo].[VineyardEstate] AS VE
    WHERE VE.[Id] = @VineyardEstateId;

END