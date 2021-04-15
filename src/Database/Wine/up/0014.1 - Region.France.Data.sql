﻿DECLARE @CountryId INT;

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
SELECT 'Ain','FR-01',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Aisne','FR-02',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Allier','FR-03',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Alpes-de-Haute-Provence','FR-04',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Alpes-Maritimes','FR-06',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Ardèche','FR-07',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Ardennes','FR-08',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Ariège','FR-09',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Aube','FR-10',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Aude','FR-11',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Aveyron','FR-12',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Bas-Rhin','FR-67',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Bouches-du-Rhône','FR-13',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Calvados','FR-14',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Cantal','FR-15',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Charente','FR-16',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Charente-Maritime','FR-17',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Cher','FR-18',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Corrèze','FR-19',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Corse-du-Sud','FR-2A',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Côte-d''Or','FR-21',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Côtes-d''Armor','FR-22',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Creuse','FR-23',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Deux-Sèvres','FR-79',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Dordogne','FR-24',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Doubs','FR-25',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Drôme','FR-26',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Essonne','FR-91',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Eure','FR-27',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Eure-et-Loir','FR-28',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Finistère','FR-29',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Guyane (française)','FR-973',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Gard','FR-30',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Gers','FR-32',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Gironde','FR-33',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Guadeloupe','FR-971',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haute-Corse','FR-2B',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haute-Garonne','FR-31',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haute-Loire','FR-43',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haute-Marne','FR-52',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Hautes-Alpes','FR-05',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haute-Saône','FR-70',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haute-Savoie','FR-74',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Hautes-Pyrénées','FR-65',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haute-Vienne','FR-87',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Haut-Rhin','FR-68',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Hauts-de-Seine','FR-92',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Hérault','FR-34',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Ille-et-Vilaine','FR-35',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Indre','FR-36',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Indre-et-Loire','FR-37',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Isère','FR-38',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Jura','FR-39',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Landes','FR-40',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Loire','FR-42',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Loire-Atlantique','FR-44',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Loiret','FR-45',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Loir-et-Cher','FR-41',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Lot','FR-46',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Lot-et-Garonne','FR-47',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Lozère','FR-48',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Maine-et-Loire','FR-49',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Manche','FR-50',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Marne','FR-51',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Martinique','FR-972',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Mayenne','FR-53',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Mayotte','FR-976',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Meurthe-et-Moselle','FR-54',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Meuse','FR-55',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Morbihan','FR-56',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Moselle','FR-57',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Nièvre','FR-58',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Nord','FR-59',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Oise','FR-60',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Orne','FR-61',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Paris','FR-75',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Pas-de-Calais','FR-62',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Puy-de-Dôme','FR-63',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Pyrénées-Atlantiques','FR-64',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Pyrénées-Orientales','FR-66',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'La Réunion','FR-974',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Rhône[1]','FR-69',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Saône-et-Loire','FR-71',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Sarthe','FR-72',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Savoie','FR-73',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Seine-et-Marne','FR-77',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Seine-Maritime','FR-76',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Seine-Saint-Denis','FR-93',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Somme','FR-80',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Tarn','FR-81',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Tarn-et-Garonne','FR-82',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Territoire de Belfort','FR-90',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Val-de-Marne','FR-94',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Val-d''Oise','FR-95',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Var','FR-83',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Vaucluse','FR-84',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Vendée','FR-85',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Vienne','FR-86',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Vosges','FR-88',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Yonne','FR-89',GETDATE(),GETDATE(),@CountryId UNION ALL
SELECT 'Yvelines','FR-78',GETDATE(),GETDATE(),@CountryId;
