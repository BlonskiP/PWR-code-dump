using System;
using System.Collections.Generic;

namespace DbManager.CORE.Models
{
    public partial class EventsTable
    {
        public EventsTable()
        {
            ApiKeys = new HashSet<ApiKeys>();
            AspUserEvent = new HashSet<AspUserEvent>();
            CharactersSheets = new HashSet<CharactersSheets>();
        }

        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime? EventDate { get; set; }
        public string Place { get; set; }
        public string EventDescription { get; set; }

        public ICollection<ApiKeys> ApiKeys { get; set; }
        public ICollection<AspUserEvent> AspUserEvent { get; set; }
        public ICollection<CharactersSheets> CharactersSheets { get; set; }
    }
}
