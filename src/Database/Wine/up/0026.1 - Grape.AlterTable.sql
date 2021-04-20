ALTER TABLE [dbo].[Grape]
ADD [StopperTypeID]  INT NULL
    FOREIGN KEY REFERENCES [StopperType]([ID]);