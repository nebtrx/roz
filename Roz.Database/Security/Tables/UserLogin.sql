CREATE TABLE [Security].[UserLogin] (
    [UserId]        INT            IDENTITY (1, 1) NOT NULL,
    [LoginProvider] NVARCHAR (MAX) NULL,
    [ProviderKey]   NVARCHAR (MAX) NULL,
    [User_Id]       INT            NULL,
    CONSTRAINT [PK_Security.UserLogin] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Security.UserLogin_Security.User_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [Security].[User] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [Security].[UserLogin]([User_Id] ASC);

