CREATE TABLE [dbo].[ProductImage]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ImagePath] VARCHAR(250) NOT NULL , 
    [ProductID] INT NOT NULL, 
    CONSTRAINT [FK_ProductImage_Product] FOREIGN KEY ([ProductID]) REFERENCES [Product]([Id]), 
)
