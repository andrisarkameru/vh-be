CREATE TABLE [dbo].[Customer] (
    [Id]     INT      PRIMARY KEY IDENTITY    NOT NULL,
    [Name]   NVARCHAR (256) NOT NULL,
    [Email]  VARCHAR (256)  NOT NULL,
    [Adress] NVARCHAR (256) NULL,
    [Age] INT NOT NULL, 
);
GO
CREATE NONCLUSTERED INDEX i1 ON Customer (email)

