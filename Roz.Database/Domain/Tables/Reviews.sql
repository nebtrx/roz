CREATE TABLE [Domain].[Reviews] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [BookID]     INT            NOT NULL,
    [ReviewText] NVARCHAR (MAX) NULL,
    [RowVersion] ROWVERSION     NOT NULL,
    CONSTRAINT [PK_Domain.Reviews] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.Reviews_Domain.Books_BookID] FOREIGN KEY ([BookID]) REFERENCES [Domain].[Books] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BookID]
    ON [Domain].[Reviews]([BookID] ASC);

