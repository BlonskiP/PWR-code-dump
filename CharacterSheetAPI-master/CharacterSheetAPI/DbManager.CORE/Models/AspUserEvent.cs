using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DbManager.CORE.Models
{
    public partial class AspUserEvent
    {
        public int AspUserEventId { get; set; }
        public string AspUserIdFk { get; set; }
        public int EventIdFk { get; set; }

        public IdentityUser AspUserIdFkNavigation { get; set; }
        public EventsTable EventIdFkNavigation { get; set; }
    }
}
