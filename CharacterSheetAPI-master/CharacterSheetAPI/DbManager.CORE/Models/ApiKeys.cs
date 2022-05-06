using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;
namespace DbManager.CORE.Models
{
    public partial class ApiKeys
    {
        public ApiKeys() { }
        public ApiKeys(EventsTable Event, DbCharacterContext db, IdentityUser user)
        {
            Id = db.ApiKeys.Count();
            Apikey = randomKey();
            EventId = Event.EventId;
            this.Event = Event;
            Event.ApiKeys.Add(this);
            AspUserIdFkNavigation = user;
            AspUserIdFk = user.Id;

        }
        public int Id { get; set; }
        public string Apikey { get; set; }
        public int EventId { get; set; }
        public string AspUserIdFk { get; set; }
        public IdentityUser AspUserIdFkNavigation { get; set; }
        public EventsTable Event { get; set; }

        public string randomKey()
        {
            Random rnd = new Random();
            string newKey = "";
            for(int i=0;i<10;i++)
            {
                char rndChar = (char)rnd.Next(65,90);
                newKey = newKey + rndChar;
            }
            return newKey;
        }
    }
}
