DECLARE @CountryId INT;

SELECT @CountryId = C.[Id]
FROM [dbo].[Country] C
WHERE C.[Name] = 'France';

INSERT INTO [dbo].[Region]
(
    [Name],
    [IsoCode],
    [DateUpdated],
    [DateCreated],
    [CountryId]
)
SELECT 'Auvergne-Rhône-Alpes','FR-ARA',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Bourgogne-Franche-Comté','FR-BFC',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Bretagne','FR-BRE',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Centre-Val de Loire','FR-CVL',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Corse','FR-20R',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Grand-Est','FR-GES',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Guadeloupe','FR-GP',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Guyane (française)','FR-GF',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Hauts-de-France','FR-HDF',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Île-de-France','FR-IDF',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Martinique','FR-MQ',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Mayotte','FR-YT',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Normandie','FR-NOR',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Nouvelle-Aquitaine','FR-NAQ',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Occitanie','FR-OCC',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Pays-de-la-Loire','FR-PDL',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Provence-Alpes-Côte-d’Azur','FR-PAC',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'La Réunion','FR-RE',GETDATE(),GETDATE(),@CountryId;
