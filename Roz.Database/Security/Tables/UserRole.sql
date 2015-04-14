CREATE TABLE [Security].[UserRole] (
    [RoleId] INT NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [PK_Security.UserRole] PRIMARY KEY CLUSTERED ([RoleId] ASC, [UserId] ASC),
    CONSTRAINT [FK_Security.UserRole_Security.Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Security].[Role] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Security.UserRole_Security.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Security].[User] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [Security].[UserRole]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [Security].[UserRole]([RoleId] ASC);

