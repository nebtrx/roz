using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roz.Data.Model.Entities
{
    public enum DiscountType
    {
        Progressive,
        ItemsPrice
    }

    public enum AllocationType
    {
        GeneralAllocation,
        SeatingPlan,
    }

    public enum FeeType
    {
        Flat
    }

    public enum EventCategory
    {
        Bussiness = 1,
        Cinema = 2,
        FoodEvent = 3,
        Sports = 4,
        Social = 5,  // Pub, club, bars, 
        Music = 6,
        Theather = 7,
        Tour = 8,
        Conference = 9,
        Weeding = 10,
        FundRaising = 11,
        Other = 12,
    }

    public enum SeatStatus
    {
        Reserved,
        Confirmed,
        Empty
    }
}
