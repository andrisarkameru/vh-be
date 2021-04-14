CREATE TABLE [dbo].[Payment] (
    [Id]            INT          NOT NULL,
    [OrderId] INT          NOT NULL,
    [Total]         DECIMAL (18) NOT NULL,
    [TotalCurrency] VARCHAR (3)  NULL,
    [PaidCurrency]  VARCHAR (3)  NOT NULL,
    [PaidAmmount]   DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Paymet_ToOrder] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);

