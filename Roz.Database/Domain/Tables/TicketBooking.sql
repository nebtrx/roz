CREATE TABLE [Domain].[TicketBooking] (
    [Id]                BIGINT IDENTITY (1, 1) NOT NULL,
    [SeatId]            BIGINT NOT NULL,
    [AppointmentId]     BIGINT NOT NULL,
    [VenueId]           BIGINT NOT NULL,
    [BookingId]         BIGINT NOT NULL,
    [AttendeeDetailsId] BIGINT NOT NULL,
    CONSTRAINT [PK_Domain.TicketBooking] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.TicketBooking_Domain.Booking_BookingId] FOREIGN KEY ([BookingId]) REFERENCES [Domain].[Booking] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Domain.TicketBooking_Domain.CustomerDetails_AttendeeDetailsId] FOREIGN KEY ([AttendeeDetailsId]) REFERENCES [Domain].[CustomerDetails] ([Id]),
    CONSTRAINT [FK_Domain.TicketBooking_Domain.EventAppointment_AppointmentId] FOREIGN KEY ([AppointmentId]) REFERENCES [Domain].[EventAppointment] ([Id]),
    CONSTRAINT [FK_Domain.TicketBooking_Domain.Seat_SeatId] FOREIGN KEY ([SeatId]) REFERENCES [Domain].[Seat] ([Id]),
    CONSTRAINT [FK_Domain.TicketBooking_Domain.Venue_VenueId] FOREIGN KEY ([VenueId]) REFERENCES [Domain].[Venue] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_AttendeeDetailsId]
    ON [Domain].[TicketBooking]([AttendeeDetailsId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BookingId]
    ON [Domain].[TicketBooking]([BookingId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_VenueId]
    ON [Domain].[TicketBooking]([VenueId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_AppointmentId]
    ON [Domain].[TicketBooking]([AppointmentId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SeatId]
    ON [Domain].[TicketBooking]([SeatId] ASC);

