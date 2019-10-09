CREATE TABLE [dbo].[ProductImage]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [varbinary(8000)] NCHAR(10) NOT NULL, 
    [ProductID] NCHAR(10) NOT NULL
)
