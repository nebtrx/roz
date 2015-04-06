CREATE TABLE [Domain].[Books] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [BookName]   NVARCHAR (MAX) NULL,
    [ISBN]       NVARCHAR (MAX) NULL,
    [RowVersion] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Domain.Books] PRIMARY KEY CLUSTERED ([Id] ASC)
);

