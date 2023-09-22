IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Issue_Update]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Issue_Update] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Issue_Update]
    @Id INT,
    @WineId INT,
    @Note NVARCHAR(MAX),
    @Date DATE,
    @Quantity INT
AS
BEGIN

    UPDATE I
    SET
        I.[WineId] = @WineId,
        I.[Note] = @Note,
        I.[Date] = @Date,
        I.[Quantity] = @Quantity
    FROM [dbo].[Issue] AS I
    WHERE I.[Id] = @Id;

END