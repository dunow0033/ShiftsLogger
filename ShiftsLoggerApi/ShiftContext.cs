using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerAPI;

public class ShiftContext : DbContext
{
	public DbSet<Shift> Shifts { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Integrated Security=true;Database=ShiftsLogger;Trusted_Connection=True;TrustServerCertificate=True;");
	}
}