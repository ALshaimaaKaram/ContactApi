using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Models.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
	[EnableCors("CorsPolicy")]
    public class ContactController : ControllerBase
    {
		private readonly IContactRepository contactRepository;

		public ContactController(IContactRepository contactRepository)
		{
			this.contactRepository = contactRepository;
		}

		[HttpGet]
		public List<Contact.Models.Contact> ListAllContacts()
		{
			return contactRepository.List().ToList();
		}


		[HttpPost]
		public void AddContact(Contact.Models.Contact contact)
		{
			contactRepository.Add(contact);
		}


		[HttpPut]
		public void EditContact(Contact.Models.Contact contact)
		{
			contactRepository.Edit(contact);
		}


		[HttpDelete]
		public void DeleteContact(List<int> ids)
		{
			contactRepository.Delete(ids);
		}

		[HttpPost]
		public void Star(int id)
		{
			contactRepository.Star(id);
		}

		[HttpGet]
		public IList<Contact.Models.Contact> ListStarredContacts()
		{
			return contactRepository.ListStarredContacts();
		}

		[HttpGet]
		public Contact.Models.Contact GetContact(int id)
		{
			return contactRepository.GetContact(id);
		}

		[HttpGet]
		public IList<Contact.Models.Contact> ListFreequentlyContacted()
		{
			return contactRepository.ListFreequentlyContacted();
		}

		[HttpGet]
		public IList<Contact.Models.Contact> Search(string key)
		{
			return contactRepository.Search(key);
		}
	}
}