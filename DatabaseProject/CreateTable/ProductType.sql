CREATE TABLE [dbo].[ProductType]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(50) NOT NULL, 
    [featureId] TINYINT NULL,
    FOREIGN KEY (featureId) REFERENCES ProductFeature (typeId)
)
