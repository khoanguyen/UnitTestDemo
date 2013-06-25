CREATE TABLE [dbo].[Products]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] NVARCHAR(50) NULL, 
    [Price] DECIMAL(18, 2) NULL, 
    [Photo] VARCHAR(255) NULL
)
