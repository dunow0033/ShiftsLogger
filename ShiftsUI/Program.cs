using ShiftsUI.API;

namespace PhoneBook;

internal class Program
{
	static void Main()
	{
		bool closeApp = false;

		while (closeApp == false)
		{
			Console.Clear();
			Console.WriteLine("Please enter your selection:  ");
			Console.WriteLine("1. List All Shifts");
			Console.WriteLine("3. Add A Shift");
			Console.WriteLine("4. Update A Shift");
			Console.WriteLine("5. Delete A Shift");
			Console.WriteLine("6. Exit\n");
			string selectedOption = Console.ReadLine();

			switch (selectedOption)
			{
				case "1":
					ListShifts();
					break;
				case "2":
					AddShift();
					break;
				//case "4":
				//	UpdateShift();
				//	break;
				//case "5":
				//	DeleteShift();
				//	break;
				case "6":
					Console.WriteLine("Thank you!!  Bye!!");
					Environment.Exit(1);
					break;
				default:
					Console.WriteLine("Invalid option!!  Please try again!!");
					Thread.Sleep(2000);
					Main();
					break;
			}
		}
	}

	public static void ListShifts()
	{
		APIcalling.GetShifts();
		
		Console.ReadKey();
	}

	public static void AddShift()
	{
		APIcalling.AddShift();

		Console.ReadKey();
	}
}
