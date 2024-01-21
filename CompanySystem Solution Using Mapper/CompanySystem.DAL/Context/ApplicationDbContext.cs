using System;
using CompanySystem.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem.DAL.Context
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
		{
		}

		public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employee { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}

