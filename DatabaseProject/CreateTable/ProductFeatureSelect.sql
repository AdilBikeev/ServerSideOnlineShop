CREATE TABLE [dbo].[ProductFeatureSelect]
( 
    [productId] INT NOT NULL PRIMARY KEY,
    [description] NVARCHAR(250) NULL, 
    [location] NVARCHAR(100) NULL, 
    [phone] NVARCHAR(20) NULL, 
    [params] NVARCHAR(250) NULL,
    FOREIGN KEY ([productId]) REFERENCES Product (id)
)
