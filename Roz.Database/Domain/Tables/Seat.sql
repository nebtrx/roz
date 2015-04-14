CREATE TABLE [Domain].[Seat] (
    [Id]                BIGINT           IDENTITY (1, 1) NOT NULL,
    [Guid]              UNIQUEIDENTIFIER NOT NULL,
    [Row]               NVARCHAR (MAX)   NULL,
    [SeatNumber]        NVARCHAR (MAX)   NULL,
    [StatusId]          INT              NOT NULL,
    [IsWheelchairSpace] BIT              NOT NULL,
    [IsHouseReserved]   BIT              NOT NULL,
    [IsAvailable]       BIT              NOT NULL,
    [Comment]           NVARCHAR (MAX)   NULL,
    [SectionId]         BIGINT           NOT NULL,
    CONSTRAINT [PK_Domain.Seat] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.Seat_Domain.SeatStatus_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Domain].[SeatStatus] ([Id]),
    CONSTRAINT [FK_Domain.Seat_Domain.Section_SectionId] FOREIGN KEY ([SectionId]) REFERENCES [Domain].[Section] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SectionId]
    ON [Domain].[Seat]([SectionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StatusId]
    ON [Domain].[Seat]([StatusId] ASC);

