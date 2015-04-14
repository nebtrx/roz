CREATE TABLE [Domain].[DiscountType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.DiscountType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

