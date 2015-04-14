namespace Roz.Data.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDomainModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Domain.AllocationType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.Event",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        IsAttendeeDetailsRequired = c.Boolean(nullable: false),
                        VATRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        EventStatus_Id = c.Int(nullable: false),
                        AllocationType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.EventCategory", t => t.CategoryId)
                .ForeignKey("Domain.EventStatus", t => t.EventStatus_Id)
                .ForeignKey("dbo.User", t => t.OwnerId, cascadeDelete: true)
                .ForeignKey("Domain.AllocationType", t => t.AllocationType_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.OwnerId)
                .Index(t => t.EventStatus_Id)
                .Index(t => t.AllocationType_Id);
            
            CreateTable(
                "Domain.Venue",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MainStreet = c.String(),
                        StreetNumber = c.String(),
                        SecondaryStreet = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Locality = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Email = c.String(),
                        Phone = c.String(),
                        OwnerId = c.Int(nullable: false),
                        GraphicRepresentation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "Domain.EventAppointment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VenueId = c.Long(nullable: false),
                        Date = c.DateTime(nullable: false),
                        DoorsOpenTime = c.DateTime(),
                        StarTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(),
                        SaleStartTime = c.DateTime(nullable: false),
                        SaleEndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.Venue", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId);
            
            CreateTable(
                "Domain.TicketBooking",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SeatId = c.Long(nullable: false),
                        AppointmentId = c.Long(nullable: false),
                        VenueId = c.Long(nullable: false),
                        BookingId = c.Long(nullable: false),
                        AttendeeDetailsId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.Booking", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("Domain.CustomerDetails", t => t.AttendeeDetailsId)
                .ForeignKey("Domain.Seat", t => t.SeatId)
                .ForeignKey("Domain.EventAppointment", t => t.AppointmentId)
                .ForeignKey("Domain.Venue", t => t.VenueId)
                .Index(t => t.SeatId)
                .Index(t => t.AppointmentId)
                .Index(t => t.VenueId)
                .Index(t => t.BookingId)
                .Index(t => t.AttendeeDetailsId);
            
            CreateTable(
                "Domain.CustomerDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Position = c.String(),
                        Organization = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.Booking",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        VenueId = c.Long(nullable: false),
                        EventId = c.Long(nullable: false),
                        BookerDetailsId = c.Long(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        ReservationTime = c.DateTime(nullable: false),
                        FeeType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.FeeType", t => t.FeeType_Id)
                .ForeignKey("Domain.CustomerDetails", t => t.BookerDetailsId, cascadeDelete: true)
                .ForeignKey("Domain.Venue", t => t.VenueId)
                .ForeignKey("Domain.Event", t => t.EventId, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.EventId)
                .Index(t => t.BookerDetailsId)
                .Index(t => t.FeeType_Id);
            
            CreateTable(
                "Domain.FeeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.Seat",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Row = c.String(),
                        SeatNumber = c.String(),
                        StatusId = c.Int(nullable: false),
                        IsWheelchairSpace = c.Boolean(nullable: false),
                        IsHouseReserved = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Comment = c.String(),
                        SectionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.Section", t => t.SectionId, cascadeDelete: true)
                .ForeignKey("Domain.SeatStatus", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.SectionId);
            
            CreateTable(
                "Domain.Section",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        GraphicRepresentation = c.String(),
                        SeatsAllocated = c.Long(nullable: false),
                        DiscountTypeId = c.Int(nullable: false),
                        VenueId = c.Long(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.DiscountType", t => t.DiscountTypeId)
                .ForeignKey("Domain.Venue", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.DiscountTypeId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "Domain.PriceCategory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Conditions = c.String(),
                        MaxBookingPerTransaction = c.Int(),
                        SectionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.Section", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "Domain.DiscountType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.SeatStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.EventCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.EventStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Domain.Ticket",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        TicketBookingId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Domain.TicketBooking", t => t.TicketBookingId, cascadeDelete: true)
                .Index(t => t.TicketBookingId);
            
            CreateTable(
                "Domain.EventVenue",
                c => new
                    {
                        Event_Id = c.Long(nullable: false),
                        Venue_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Venue_Id })
                .ForeignKey("Domain.Event", t => t.Event_Id)
                .ForeignKey("Domain.Venue", t => t.Venue_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.Venue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Domain.Ticket", "TicketBookingId", "Domain.TicketBooking");
            DropForeignKey("Domain.Event", "AllocationType_Id", "Domain.AllocationType");
            DropForeignKey("Domain.Event", "OwnerId", "dbo.User");
            DropForeignKey("Domain.Event", "EventStatus_Id", "Domain.EventStatus");
            DropForeignKey("Domain.Event", "CategoryId", "Domain.EventCategory");
            DropForeignKey("Domain.Booking", "EventId", "Domain.Event");
            DropForeignKey("Domain.EventVenue", "Venue_Id", "Domain.Venue");
            DropForeignKey("Domain.EventVenue", "Event_Id", "Domain.Event");
            DropForeignKey("Domain.TicketBooking", "VenueId", "Domain.Venue");
            DropForeignKey("Domain.Venue", "OwnerId", "dbo.User");
           DropForeignKey("Domain.Booking", "VenueId", "Domain.Venue");
            DropForeignKey("Domain.Section", "VenueId", "Domain.Venue");
            DropForeignKey("Domain.EventAppointment", "VenueId", "Domain.Venue");
            DropForeignKey("Domain.TicketBooking", "AppointmentId", "Domain.EventAppointment");
            DropForeignKey("Domain.TicketBooking", "SeatId", "Domain.Seat");
            DropForeignKey("Domain.Seat", "StatusId", "Domain.SeatStatus");
            DropForeignKey("Domain.Seat", "SectionId", "Domain.Section");
            DropForeignKey("Domain.Section", "DiscountTypeId", "Domain.DiscountType");
            DropForeignKey("Domain.PriceCategory", "SectionId", "Domain.Section");
            DropForeignKey("Domain.TicketBooking", "AttendeeDetailsId", "Domain.CustomerDetails");
            DropForeignKey("Domain.Booking", "BookerDetailsId", "Domain.CustomerDetails");
            DropForeignKey("Domain.TicketBooking", "BookingId", "Domain.Booking");
            DropForeignKey("Domain.Booking", "FeeType_Id", "Domain.FeeType");
            DropIndex("Domain.EventVenue", new[] { "Venue_Id" });
            DropIndex("Domain.EventVenue", new[] { "Event_Id" });
            DropIndex("Domain.Ticket", new[] { "TicketBookingId" });
            DropIndex("Domain.PriceCategory", new[] { "SectionId" });
            DropIndex("Domain.Section", new[] { "VenueId" });
            DropIndex("Domain.Section", new[] { "DiscountTypeId" });
            DropIndex("Domain.Seat", new[] { "SectionId" });
            DropIndex("Domain.Seat", new[] { "StatusId" });
            DropIndex("Domain.Booking", new[] { "FeeType_Id" });
            DropIndex("Domain.Booking", new[] { "BookerDetailsId" });
            DropIndex("Domain.Booking", new[] { "EventId" });
            DropIndex("Domain.Booking", new[] { "VenueId" });
            DropIndex("Domain.TicketBooking", new[] { "AttendeeDetailsId" });
            DropIndex("Domain.TicketBooking", new[] { "BookingId" });
            DropIndex("Domain.TicketBooking", new[] { "VenueId" });
            DropIndex("Domain.TicketBooking", new[] { "AppointmentId" });
            DropIndex("Domain.TicketBooking", new[] { "SeatId" });
            DropIndex("Domain.EventAppointment", new[] { "VenueId" });
            DropIndex("Domain.Venue", new[] { "OwnerId" });
            DropIndex("Domain.Event", new[] { "AllocationType_Id" });
            DropIndex("Domain.Event", new[] { "EventStatus_Id" });
            DropIndex("Domain.Event", new[] { "OwnerId" });
            DropIndex("Domain.Event", new[] { "CategoryId" });
            DropTable("Domain.EventVenue");
            DropTable("Domain.Ticket");
            DropTable("Domain.EventStatus");
            DropTable("Domain.EventCategory");
            DropTable("Domain.SeatStatus");
            DropTable("Domain.DiscountType");
            DropTable("Domain.PriceCategory");
            DropTable("Domain.Section");
            DropTable("Domain.Seat");
            DropTable("Domain.FeeType");
            DropTable("Domain.Booking");
            DropTable("Domain.CustomerDetails");
            DropTable("Domain.TicketBooking");
            DropTable("Domain.EventAppointment");
            DropTable("Domain.Venue");
            DropTable("Domain.Event");
            DropTable("Domain.AllocationType");
        }
    }
}
