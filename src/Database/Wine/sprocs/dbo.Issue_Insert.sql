IF NOT EXISTS (SELECT * FROM sys.objects WHERE OBJECT_ID = OBJECT_ID('[dbo].[Issue_Insert]') AND TYPE IN ('P','PC'))
    EXEC ('CREATE PROCEDURE [dbo].[Issue_Insert] AS BEGIN RETURN; END')
GO

ALTER PROCEDURE [dbo].[Issue_Insert]
    @WineId INT,
    @Note NVARCHAR(MAX),
    @Date DATE,
    @Quantity INT
AS
BEGIN

    INSERT INTO [dbo].[Issue]
    (
        [WineId],
        [Note],
        [Date],
        [Quantity],
        [DateUpdated],
        [DateCreated]
    )
    VALUES
    (
        @WineId,
        @Note,
        @Date,
        @Quantity,
        GETDATE(),
        GETDATE()
    );

END