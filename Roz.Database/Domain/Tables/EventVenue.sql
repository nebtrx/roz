CREATE TABLE [Domain].[EventVenue] (
    [Event_Id] BIGINT NOT NULL,
    [Venue_Id] BIGINT NOT NULL,
    CONSTRAINT [PK_Domain.EventVenue] PRIMARY KEY CLUSTERED ([Event_Id] ASC, [Venue_Id] ASC),
    CONSTRAINT [FK_Domain.EventVenue_Domain.Event_Event_Id] FOREIGN KEY ([Event_Id]) REFERENCES [Domain].[Event] ([Id]),
    CONSTRAINT [FK_Domain.EventVenue_Domain.Venue_Venue_Id] FOREIGN KEY ([Venue_Id]) REFERENCES [Domain].[Venue] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Venue_Id]
    ON [Domain].[EventVenue]([Venue_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Event_Id]
    ON [Domain].[EventVenue]([Event_Id] ASC);

