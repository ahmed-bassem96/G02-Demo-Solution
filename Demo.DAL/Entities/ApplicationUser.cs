using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
	public class ApplicationUser:IdentityUser
	{
		public bool IsAgree { get; set; }

		public string Fname { get; set; }
		public string Lname { get; set; }
	}
}
