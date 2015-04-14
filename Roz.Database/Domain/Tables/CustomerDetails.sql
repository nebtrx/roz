CREATE TABLE [Domain].[CustomerDetails] (
    [Id]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Email]        NVARCHAR (MAX) NULL,
    [Phone]        NVARCHAR (MAX) NULL,
    [Position]     NVARCHAR (MAX) NULL,
    [Organization] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.CustomerDetails] PRIMARY KEY CLUSTERED ([Id] ASC)
);

