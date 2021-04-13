CREATE TABLE [dbo].[Customer] (
    [Id]     INT            NOT NULL,
    [Name]   NVARCHAR (256) NULL,
    [Email]  VARCHAR (256)  NULL,
    [Adress] NVARCHAR (256) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

