using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Models
{
	public class Contact
	{
		public Contact()
		{
			IsStar = false;
			OpenCountForFreequent = 0;
		}

		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string NickName { get; set; }
		[Phone]	
		public string PhoneNumber { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		public string Company { get; set; }
		public string JobTitle { get; set; }
		public DateTime? Birthday { get; set; }
		public string Address { get; set; }
		public string Notes { get; set; }
		public bool IsStar { get; set; }
		public int OpenCountForFreequent { get; set; }
	}
}
