CREATE TABLE [dbo].[Payment] (
    [Id]            INT          NOT NULL,
    [ReservationId] INT          NOT NULL,
    [Total]         DECIMAL (18) NOT NULL,
    [TotalCurrency] VARCHAR (3)  NULL,
    [PaidCurrency]  VARCHAR (3)  NOT NULL,
    [PaidAmmount]   DECIMAL (18) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_ToReservation] FOREIGN KEY ([ReservationId]) REFERENCES [dbo].[Reservation] ([Id])
);

