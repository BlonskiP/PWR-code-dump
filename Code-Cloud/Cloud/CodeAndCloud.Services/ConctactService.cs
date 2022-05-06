using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CodeAndCloud.Core;
using CodeAndCloud.Core.Entities;
using CodeAndCloud.ViewModel;

namespace CodeAndCloud.Services
{
    public class ContactService : IContactService
    {
        public void Add(AddContactViewModel model)
        {
            var db = new DataContext();
            var contact = new ContactModel()
            {
                CreateDate = DateTime.Now,
                Email= model.Email,
                Name=model.Name,
                PhoneNumber=model.PhoneNumber,
                    
            };
            
            db.Add<ContactModel>(contact);
            db.SaveChanges();
        }
    }
}
