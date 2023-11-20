﻿using ShiftsUI.API;
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
					ListShifts();
					break;
				case "2":
					AddShift();
					break;
				case "3":
					UpdateShift();
					break;
				case "4":
					DeleteShift();
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

		private async void ListShifts()
		{
			List<Shift>? shifts = (await _controller.GetShifts()).ToList();

			Table table = new Table();
			table.Expand();
			table.AddColumns("Employee Name", "Start of Shift", "End of Shift");

			foreach (Shift shift in shifts)
			{
				table.AddRow($"{shift.EmployeeName}", $"{shift.StartOfShift}", $"{shift.EndOfShift}");
			}

			Console.Clear();
			AnsiConsole.Write(table);

			Console.WriteLine("\n\nPress Any Key to continue......");
			Console.ReadKey();
	}

		public static void AddShift()
		{
			APIcalling.AddShift();

			Console.ReadKey();
		}

		public static void UpdateShift()
		{
			//APIcalling.UpdateShift();

			Console.ReadKey();
		}

		public static void DeleteShift()
		{
			APIcalling.DeleteShift();

			Console.ReadKey();
		}
}
