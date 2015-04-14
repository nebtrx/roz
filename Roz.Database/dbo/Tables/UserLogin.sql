CREATE TABLE [dbo].[UserLogin] (
    [UserId]        INT            IDENTITY (1, 1) NOT NULL,
    [LoginProvider] NVARCHAR (MAX) NULL,
    [ProviderKey]   NVARCHAR (MAX) NULL,
    [User_Id]       INT            NULL,
    CONSTRAINT [PK_dbo.UserLogin] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_dbo.UserLogin_dbo.User_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[UserLogin]([User_Id] ASC);

