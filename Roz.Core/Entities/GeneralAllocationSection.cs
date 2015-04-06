using System.Collections.Generic;

namespace Roz.Core.Entities
{
    class GeneralAllocationSection : AllocationSection
    {
        public string Description { get; set; }

        public long TicketsAllocated { get; set; }

        public List<Ticket> BookedTickets { get; set; }

    }
}