CREATE TABLE [Domain].[AllocationType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.AllocationType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

