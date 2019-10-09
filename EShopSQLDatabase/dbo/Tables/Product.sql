CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [UserID] INT NOT NULL 
)
