CREATE TABLE [Domain].[EventAppointment] (
    [Id]            BIGINT   IDENTITY (1, 1) NOT NULL,
    [VenueId]       BIGINT   NOT NULL,
    [Date]          DATETIME NOT NULL,
    [DoorsOpenTime] DATETIME NULL,
    [StarTime]      DATETIME NOT NULL,
    [EndTime]       DATETIME NULL,
    [SaleStartTime] DATETIME NOT NULL,
    [SaleEndTime]   DATETIME NOT NULL,
    CONSTRAINT [PK_Domain.EventAppointment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.EventAppointment_Domain.Venue_VenueId] FOREIGN KEY ([VenueId]) REFERENCES [Domain].[Venue] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_VenueId]
    ON [Domain].[EventAppointment]([VenueId] ASC);

