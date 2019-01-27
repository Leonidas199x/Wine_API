-- =============================================
-- Author:		Toby Prince
-- Create date: 25/02/2017
-- Description:	Inserts a new producer
-- =============================================
CREATE PROCEDURE [dbo].[spInsertProducer]

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