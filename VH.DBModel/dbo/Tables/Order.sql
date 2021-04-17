CREATE TABLE [dbo].[Order] (
    [Id]         INT     PRIMARY KEY IDENTITY            NOT NULL,
    [Status]    Nvarchar(32) NOT NULL,
    [From]       DATETIMEOFFSET (7) NOT NULL,
    [To]         DATETIMEOFFSET (7) NOT NULL,
    [CustomerId] INT                NOT NULL,
    [LocationId] INT                NOT NULL,
    [RentableItemId] INT NOT NULL, 
    [StatusBefore] nvarchar(max),
    [StatusAfter] nvarchar(max),

    CONSTRAINT [FK_Order_ToCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]),
    CONSTRAINT [FK_Order_ToLocation] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id]),
    CONSTRAINT [FK_Order_ToRentableItem] FOREIGN KEY ([RentableItemId]) REFERENCES [dbo].[RentableItem] ([Id]),
    CONSTRAINT [StatusBefore should be formatted as JSON] CHECK (ISJSON([StatusBefore])=1),
    CONSTRAINT [StatusAfter should be formatted as JSON] CHECK (ISJSON([StatusAfter])=1)

);

