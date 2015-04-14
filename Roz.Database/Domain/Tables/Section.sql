CREATE TABLE [Domain].[Section] (
    [Id]                    BIGINT         IDENTITY (1, 1) NOT NULL,
    [Description]           NVARCHAR (MAX) NULL,
    [GraphicRepresentation] NVARCHAR (MAX) NULL,
    [SeatsAllocated]        BIGINT         NOT NULL,
    [DiscountTypeId]        INT            NOT NULL,
    [VenueId]               BIGINT         NOT NULL,
    [Discriminator]         NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Domain.Section] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.Section_Domain.DiscountType_DiscountTypeId] FOREIGN KEY ([DiscountTypeId]) REFERENCES [Domain].[DiscountType] ([Id]),
    CONSTRAINT [FK_Domain.Section_Domain.Venue_VenueId] FOREIGN KEY ([VenueId]) REFERENCES [Domain].[Venue] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_VenueId]
    ON [Domain].[Section]([VenueId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DiscountTypeId]
    ON [Domain].[Section]([DiscountTypeId] ASC);

