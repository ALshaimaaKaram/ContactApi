using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Models.Repositories
{
	public interface IContactRepository: IGenericRepository<Contact>
	{
		void Star(int id);
		IList<Contact> ListStarredContacts();
		Contact GetContact(int id);
		IList<Contact> ListFreequentlyContacted();
		IList<Contact> Search(string key);
	}
}
