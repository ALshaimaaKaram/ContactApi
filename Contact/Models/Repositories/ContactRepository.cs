using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Models.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _db;

        public ContactRepository(ContactDbContext db)
        {
            _db = db;
        }
        public void Add(Contact entity)
        {
            _db.Contacts.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(IList<int> ids)
        {
            foreach (var id in ids)
            {
                var contact = FindById(id);
                if (contact == null) continue;
                _db.Contacts.Remove(contact);
            }
            _db.SaveChanges();
        }

        public void Edit(Contact entity)
        {
            _db.Contacts.Update(entity);
            _db.SaveChanges();
        }

        public Contact FindById(int id)
        {
            return _db.Contacts.FirstOrDefault(i => i.Id == id);
        }

        public IList<Contact> List()
        {
            return _db.Contacts.Select(c => c).ToList();
        }

        public void Star(int id)
        {
            var contact = _db.Contacts.FirstOrDefault(i => i.Id == id);
            contact.IsStar = !contact.IsStar;

            Edit(contact);
        }

        public IList<Contact> ListStarredContacts()
        {
            return _db.Contacts.Where(s => s.IsStar == true).ToList();
        }

        public Contact GetContact(int id)
        {
            var contact = FindById(id);
            if (contact != null)
            {
                contact.OpenCountForFreequent++;
                Edit(contact);
            }
            return contact;
        }

        public IList<Contact> ListFreequentlyContacted()
        {
            return _db.Contacts.OrderByDescending(f => f.OpenCountForFreequent)
                               .Take(10).ToList();
        }

        public IList<Contact> Search(string key)
        {
            return _db.Contacts.Where(s => s.Name.Contains(key) || s.Email.Contains(key) || s.PhoneNumber.Contains(key)).ToList();
        }
    }
}
