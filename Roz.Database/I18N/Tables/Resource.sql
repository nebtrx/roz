CREATE TABLE [I18N].[Resource] (
    [Id]  BIGINT         IDENTITY (1, 1) NOT NULL,
    [Key] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_I18N.Resource] PRIMARY KEY CLUSTERED ([Id] ASC)
);

