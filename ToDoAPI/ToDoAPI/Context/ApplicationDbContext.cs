

using Microsoft.EntityFrameworkCore;
using ToDoAPI.Model;

namespace ToDoAPI.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<ToDo> todos { get; set; }
	
	
	}

}