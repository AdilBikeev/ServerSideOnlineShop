CREATE TABLE [dbo].[Product]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [sallerId] INT NOT NULL,
    [name] NVARCHAR(100) NOT NULL, 
    [price] FLOAT NOT NULL, 
    [status] TINYINT NOT NULL,
    [type] TINYINT NOT NULL, 
    [datePublication] DATETIME NOT NULL, 
    FOREIGN KEY ([status]) REFERENCES ProductStatus (id),
    FOREIGN KEY ([type]) REFERENCES ProductFeature (typeId),
    FOREIGN KEY ([sallerId]) REFERENCES [User] (id)
)
