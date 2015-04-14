CREATE TABLE [Domain].[EventCategory] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.EventCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

