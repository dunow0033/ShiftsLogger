using ShiftsUI.API;
using ShiftsUI.Controllers;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsUI;

internal class UserInterface
{
	private ShiftLoggerController _controller;

	public UserInterface(ShiftLoggerController controller)
	{
		_controller = controller;
	}

	public async Task Run()
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("Please enter your selection:  ");
			Console.WriteLine("1. List All Shifts");
			Console.WriteLine("2. Add A Shift");
			Console.WriteLine("3. Update A Shift");
			Console.WriteLine("4. Delete A Shift");
			Console.WriteLine("5. Exit\n\n");
			string selectedOption = Console.ReadLine();

			switch (selectedOption)
			{
				case "1":
					await ListShifts();
					Console.ReadKey();
					break;
				case "2":
					await AddShift();
					Console.ReadKey();
					break;
				case "3":
					await UpdateShift();
					Console.ReadKey();
					break;
				case "4":
					await DeleteShift();
					Console.ReadKey();
					break;
				case "5":
					Console.WriteLine("Thank you!!  Bye!!");
					Environment.Exit(1);
					break;
				default:
					Console.WriteLine("Invalid option!!  Please try again!!");
					Thread.Sleep(2000);
					break;
			}
		}
	}

		private async Task ListShifts()
		{
			Console.Clear();
			List<Shift>? shifts = (await _controller.GetShifts()).ToList();

			Table table = new Table();
			table.Expand();
			table.AddColumns("Employee Name", "Start of Shift", "End of Shift");

			foreach (Shift shift in shifts)
			{
				table.AddRow($"{shift.EmployeeName}", $"{shift.StartOfShift}", $"{shift.EndOfShift}");
			}
			
			AnsiConsole.Write(table);

			Console.WriteLine("\n\nPress Any Key to continue......");
	}

		public async Task AddShift()
		{
			Console.Clear();
			string startOfShift, endOfShift;

			string employeeName = AnsiConsole.Ask<string>("Enter the employee name:");
		
			startOfShift = AnsiConsole.Ask<string>("Enter the start of shift (MM/dd/yyyy HH:mm):");
			endOfShift = AnsiConsole.Ask<string>("Enter the end of shift (MM/dd/yyyy HH:mm):");

		ShiftDto newShift = new()
		{
			//Id = 0,
			EmployeeName = employeeName,
			StartOfShift = DateTime.Parse(startOfShift),
			EndOfShift = DateTime.Parse(endOfShift)
		};

		var result = await _controller.PostShift(newShift);

		if (result)
		{
			AnsiConsole.WriteLine("Your shift has been added.");
		}
		else
		{
			AnsiConsole.WriteLine("Your shift didn't get added correctly, try again!");
		}
		Console.WriteLine("Press any key to continue.");
	}

		public async Task UpdateShift()
		{
			//APIcalling.UpdateShift();
		}

		public async Task DeleteShift()
		{
			APIcalling.DeleteShift();

			Console.ReadKey();
		}
}
