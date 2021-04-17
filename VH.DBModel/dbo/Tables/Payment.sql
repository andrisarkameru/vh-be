CREATE TABLE [dbo].[Payment] (
    [Id]   INT      PRIMARY KEY IDENTITY     NOT NULL,
    [OrderId] INT          NOT NULL,
    [Total]         DECIMAL (18) NOT NULL,
    [TotalCurrency] VARCHAR (3)  NULL,
    [PaidCurrency]  VARCHAR (3)  NOT NULL,
    [PaidAmmount]   DECIMAL (18) NULL,    
    CONSTRAINT [FK_Paymet_ToOrder] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);

