CREATE TABLE [Domain].[Booking] (
    [Id]              BIGINT           IDENTITY (1, 1) NOT NULL,
    [Guid]            UNIQUEIDENTIFIER NOT NULL,
    [VenueId]         BIGINT           NOT NULL,
    [EventId]         BIGINT           NOT NULL,
    [BookerDetailsId] BIGINT           NOT NULL,
    [IsConfirmed]     BIT              NOT NULL,
    [ReservationTime] DATETIME         NOT NULL,
    [FeeType_Id]      INT              NOT NULL,
    CONSTRAINT [PK_Domain.Booking] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.Booking_Domain.CustomerDetails_BookerDetailsId] FOREIGN KEY ([BookerDetailsId]) REFERENCES [Domain].[CustomerDetails] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Domain.Booking_Domain.Event_EventId] FOREIGN KEY ([EventId]) REFERENCES [Domain].[Event] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Domain.Booking_Domain.FeeType_FeeType_Id] FOREIGN KEY ([FeeType_Id]) REFERENCES [Domain].[FeeType] ([Id]),
    CONSTRAINT [FK_Domain.Booking_Domain.Venue_VenueId] FOREIGN KEY ([VenueId]) REFERENCES [Domain].[Venue] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FeeType_Id]
    ON [Domain].[Booking]([FeeType_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BookerDetailsId]
    ON [Domain].[Booking]([BookerDetailsId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EventId]
    ON [Domain].[Booking]([EventId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VenueId]
    ON [Domain].[Booking]([VenueId] ASC);

