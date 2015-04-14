CREATE TABLE [Domain].[Event] (
    [Id]                        BIGINT           IDENTITY (1, 1) NOT NULL,
    [Guid]                      UNIQUEIDENTIFIER NOT NULL,
    [Name]                      NVARCHAR (MAX)   NULL,
    [Description]               NVARCHAR (MAX)   NULL,
    [IsPublic]                  BIT              NOT NULL,
    [IsAttendeeDetailsRequired] BIT              NOT NULL,
    [VATRate]                   DECIMAL (18, 2)  NOT NULL,
    [CategoryId]                INT              NOT NULL,
    [OwnerId]                   INT              NOT NULL,
    [EventStatus_Id]            INT              NOT NULL,
    [AllocationType_Id]         INT              NOT NULL,
    CONSTRAINT [PK_Domain.Event] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.Event_dbo.User_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Domain.Event_Domain.AllocationType_AllocationType_Id] FOREIGN KEY ([AllocationType_Id]) REFERENCES [Domain].[AllocationType] ([Id]),
    CONSTRAINT [FK_Domain.Event_Domain.EventCategory_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Domain].[EventCategory] ([Id]),
    CONSTRAINT [FK_Domain.Event_Domain.EventStatus_EventStatus_Id] FOREIGN KEY ([EventStatus_Id]) REFERENCES [Domain].[EventStatus] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AllocationType_Id]
    ON [Domain].[Event]([AllocationType_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EventStatus_Id]
    ON [Domain].[Event]([EventStatus_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OwnerId]
    ON [Domain].[Event]([OwnerId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategoryId]
    ON [Domain].[Event]([CategoryId] ASC);

