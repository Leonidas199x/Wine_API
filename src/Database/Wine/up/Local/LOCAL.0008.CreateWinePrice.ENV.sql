INSERT INTO [dbo].[WinePrice]
(
    [WineId],
    [RetailerWineId],
    [FullPrice],
    [EffectiveDate],
    [DateCreated],
    [DateUpdated]
)
VALUES
(
    1,
    1,
    10,
    GETDATE(),
    GETDATE(),
    GETDATE()
);