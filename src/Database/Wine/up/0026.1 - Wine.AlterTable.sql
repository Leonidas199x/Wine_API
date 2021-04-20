ALTER TABLE [dbo].[Wine]
ADD [StopperTypeID]  INT NULL
    FOREIGN KEY REFERENCES [StopperType]([ID]);