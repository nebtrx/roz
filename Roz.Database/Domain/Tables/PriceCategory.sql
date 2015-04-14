CREATE TABLE [Domain].[PriceCategory] (
    [Id]                       BIGINT          IDENTITY (1, 1) NOT NULL,
    [Description]              NVARCHAR (MAX)  NULL,
    [Price]                    DECIMAL (18, 2) NOT NULL,
    [Conditions]               NVARCHAR (MAX)  NULL,
    [MaxBookingPerTransaction] INT             NULL,
    [SectionId]                BIGINT          NOT NULL,
    CONSTRAINT [PK_Domain.PriceCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.PriceCategory_Domain.Section_SectionId] FOREIGN KEY ([SectionId]) REFERENCES [Domain].[Section] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SectionId]
    ON [Domain].[PriceCategory]([SectionId] ASC);

