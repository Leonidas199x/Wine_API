DECLARE @CountryId INT;

SELECT @CountryId = C.[Id]
FROM [dbo].[Country] C
WHERE C.[Name] = 'Australia';

INSERT INTO [dbo].[Region]
(
    [Name],
    [IsoCode],
    [DateUpdated],
    [DateCreated],
    [CountryId]
)
SELECT ' New South Wales','AU-NSW',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT ' Queensland','AU-QLD',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT ' South Australia','AU-SA',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT ' Tasmania','AU-TAS',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT ' Victoria','AU-VIC',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT ' Western Australia','AU-WA',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT ' Australian Capital Territory','AU-ACT',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT ' Northern Territory','AU-NT',GETDATE(),GETDATE(),@CountryId;
