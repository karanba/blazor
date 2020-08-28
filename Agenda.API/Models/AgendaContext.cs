using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.API.Models
{
	public class AgendaContext : DbContext
	{
		public AgendaContext(DbContextOptions<AgendaContext> options)
			: base(options)
		{

		}

		public DbSet<Customer> Customers { get; set; }
	}
}
