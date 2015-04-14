CREATE TABLE [Security].[Role] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Security.Role] PRIMARY KEY CLUSTERED ([Id] ASC)
);

