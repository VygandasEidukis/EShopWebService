CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] TEXT NOT NULL, 
    [Price] MONEY NOT NULL, 
    [UserID] INT NOT NULL, 
    [CategoryID] INT NOT NULL, 
    CONSTRAINT [FK_Product_Account] FOREIGN KEY ([UserID]) REFERENCES [Account]([Id]) 
)
