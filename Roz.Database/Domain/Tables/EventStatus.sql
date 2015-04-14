CREATE TABLE [Domain].[EventStatus] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.EventStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

