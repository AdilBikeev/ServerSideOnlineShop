CREATE TABLE [dbo].[User] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [login]    NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

