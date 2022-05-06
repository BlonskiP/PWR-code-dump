using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace CodeAndCloud.Core.Entities
{
    public class ContactModel
    {
        [Key]
    public virtual long Id { get; set; }
        [MaxLength(20)]
    public virtual string Email { get; set; }
    public virtual string Name { get; set; }

    public virtual string PhoneNumber { get; set; }
    public virtual DateTime CreateDate { get; set; }
    public virtual bool IsAnswer { get; set; }

    }
}
