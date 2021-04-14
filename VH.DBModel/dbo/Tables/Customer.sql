CREATE TABLE [dbo].[Customer] (
    [Id]     INT            NOT NULL,
    [Name]   NVARCHAR (256) NOT NULL,
    [Email]  VARCHAR (256)  NOT NULL,
    [Adress] NVARCHAR (256) NULL,
    [Age] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

