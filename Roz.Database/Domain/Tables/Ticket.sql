CREATE TABLE [Domain].[Ticket] (
    [Id]              BIGINT           IDENTITY (1, 1) NOT NULL,
    [Guid]            UNIQUEIDENTIFIER NOT NULL,
    [TicketBookingId] BIGINT           NOT NULL,
    CONSTRAINT [PK_Domain.Ticket] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.Ticket_Domain.TicketBooking_TicketBookingId] FOREIGN KEY ([TicketBookingId]) REFERENCES [Domain].[TicketBooking] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TicketBookingId]
    ON [Domain].[Ticket]([TicketBookingId] ASC);

