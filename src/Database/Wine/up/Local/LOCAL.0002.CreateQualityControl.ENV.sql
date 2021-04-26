INSERT INTO [dbo].[QualityControl]
(
    [CountryId],
    [Name],
    [DateCreated],
    [DateUpdated]
)
VALUES
(
    1,
    'Test',
    GETDATE(),
    GETDATE()
);