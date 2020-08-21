using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Models;
using Contact.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IContactRepository contactRepository;

		public ValuesController(IContactRepository contactRepository)
		{
			this.contactRepository = contactRepository;
		}

		[HttpGet]
		public List<Contact.Models.Contact> GetAllContacts()
		{
			return contactRepository.List().ToList();
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
