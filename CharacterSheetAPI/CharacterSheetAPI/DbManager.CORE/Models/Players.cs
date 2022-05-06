using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace DbManager.CORE.Models
{
    public partial class Players
    {
        public Players()
        {
            CharactersSheets = new HashSet<CharactersSheets>();
        }

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AspUserIdFk { get; set; }

        public IdentityUser AspUserIdFkNavigation { get; set; }
        public ICollection<CharactersSheets> CharactersSheets { get; set; }
    }
}
