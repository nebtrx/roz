CREATE TABLE [Domain].[SeatStatus] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.SeatStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

