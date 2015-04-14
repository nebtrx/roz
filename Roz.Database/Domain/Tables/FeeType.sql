CREATE TABLE [Domain].[FeeType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.FeeType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

