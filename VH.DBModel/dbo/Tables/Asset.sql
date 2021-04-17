CREATE TABLE [dbo].[Asset]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Type] varchar(128) NOT NULL,
	[Identification] varchar(256) NOT NULL, 
	[BasePrice] decimal NOT NULL,
	[Properties] nvarchar(max),
    CONSTRAINT [Properties should be formatted as JSON] CHECK (ISJSON([Properties])=1),
)
