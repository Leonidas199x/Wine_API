CREATE PROCEDURE [dbo].[InsertProducer]

	@strProducerNote NVARCHAR(MAX),
	@strProducerName NVARCHAR(50)	
AS
BEGIN

DECLARE @dteRunDate DATETIME2(3);
SELECT @dteRunDate = GETDATE();

	SET NOCOUNT ON;
	INSERT INTO [dbo].[Producer]
           (
           [ProducerNote]
           ,[DateCreated]
           ,[DateUpdated]
           ,[ProducerName]
		   )
     VALUES
           (
			@strProducerNote
           ,@dteRunDate
           ,@dteRunDate
           ,@strProducerName
		   )
END