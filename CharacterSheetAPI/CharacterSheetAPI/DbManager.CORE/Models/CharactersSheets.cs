using System;
using System.Collections.Generic;

namespace DbManager.CORE.Models
{
    public partial class CharactersSheets
    {
        public int SheetId { get; set; }
        public int PlayerIdFk { get; set; }
        public string Name { get; set; }
        public int? Money { get; set; }
        public string Description { get; set; }
        public bool? Approved { get; set; }
        public int? EventIdFk { get; set; }

        public EventsTable EventIdFkNavigation { get; set; }
        public Players PlayerIdFkNavigation { get; set; }
    }
}
