CREATE TABLE [I18N].[ResourceValue] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [CultureName] NVARCHAR (MAX) NULL,
    [Value]       NVARCHAR (MAX) NULL,
    [Resource_Id] BIGINT         NULL,
    CONSTRAINT [PK_I18N.ResourceValue] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_I18N.ResourceValue_I18N.Resource_Resource_Id] FOREIGN KEY ([Resource_Id]) REFERENCES [I18N].[Resource] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Resource_Id]
    ON [I18N].[ResourceValue]([Resource_Id] ASC);

