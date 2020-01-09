CREATE TABLE [dbo].[ProductType]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [name] NVARCHAR(50) NOT NULL, 
    [featureId] TINYINT NOT NULL,
    FOREIGN KEY (featureId) REFERENCES ProductFeature (typeId)
)
