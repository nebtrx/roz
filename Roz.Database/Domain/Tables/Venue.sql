CREATE TABLE [Domain].[Venue] (
    [Id]                    BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]                  NVARCHAR (MAX) NULL,
    [MainStreet]            NVARCHAR (MAX) NULL,
    [StreetNumber]          NVARCHAR (MAX) NULL,
    [SecondaryStreet]       NVARCHAR (MAX) NULL,
    [PostalCode]            NVARCHAR (MAX) NULL,
    [Country]               NVARCHAR (MAX) NULL,
    [State]                 NVARCHAR (MAX) NULL,
    [City]                  NVARCHAR (MAX) NULL,
    [Locality]              NVARCHAR (MAX) NULL,
    [Longitude]             FLOAT (53)     NOT NULL,
    [Latitude]              FLOAT (53)     NOT NULL,
    [Email]                 NVARCHAR (MAX) NULL,
    [Phone]                 NVARCHAR (MAX) NULL,
    [OwnerId]               INT            NOT NULL,
    [GraphicRepresentation] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Domain.Venue] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Domain.Venue_dbo.User_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OwnerId]
    ON [Domain].[Venue]([OwnerId] ASC);

