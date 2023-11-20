using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Spectre.Console;

namespace ShiftsUI.API;

class APIcalling
{
	private static string url = null;
	private static Uri uri;
	private static HttpClient httpClient = new HttpClient();

	public static async void GetShifts()
	{
		url = $"https://localhost:7275/api/Shift";

		HttpClient httpClient = new HttpClient();

		using (HttpResponseMessage response = await httpClient.GetAsync(url))
		{
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();

				var shiftDataArray = JArray.Parse(jsonResponse);

				Table table = new Table();
				table.Expand();
				table.AddColumns("Employee Name", "Start of Shift", "End of Shift");

				foreach (var shiftData in shiftDataArray)
				{
					string EmployeeName = (string)shiftData["employeeName"];
					string StartOfShift = (string)shiftData["startOfShift"];
					string EndOfShift = (string)shiftData["endOfShift"];

					table.AddRow($"{EmployeeName}", $"{StartOfShift}", $"{EndOfShift}");
				}

				Console.Clear();
				AnsiConsole.Write(table);

				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("Press Any Key to continue......");
			}
		}
	}

	public static async Task<bool> AddShift()
	{
		string startOfShift, endOfShift;

		string employeeName = AnsiConsole.Ask<string>("Enter the employee name:");

		startOfShift = AnsiConsole.Ask<string>("Enter the start of shift:");

		endOfShift = AnsiConsole.Ask<string>("Enter the end of shift:");

		ShiftDto newShift = new()
		{
			//Id = 0,
			EmployeeName = employeeName,
			StartOfShift = DateTime.Parse(startOfShift),
			EndOfShift = DateTime.Parse(endOfShift)
		};

		url = $"https://localhost:7275/api/Shift";

		var json = JsonSerializer.Serialize(newShift);

		var content = new StringContent(json, Encoding.UTF8, "application/json");

		HttpClient httpClient = new HttpClient();

		try
		{
			using (HttpResponseMessage response = await httpClient.PostAsync(url, content))
			{
				if (response.IsSuccessStatusCode)
				{
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("Press Any Key to continue......");
					return true;
				}
				else
				{
					Console.WriteLine();
					Console.WriteLine();
					Console.WriteLine("Press Any Key to continue......");
					return false;
				}
			}
		}
		catch (Exception ex)
		{
			AnsiConsole.WriteLine($"API Service isn't responding. - {ex.Message}");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Press Any Key to continue......");
			return false;
		}
	}

	public static async void DeleteShift()
	{
		AnsiConsole.Clear();
		Console.WriteLine("Select which Shift to Remove");

		url = $"https://localhost:7275/api/Shift";

		HttpClient httpClient = new HttpClient();

		string selectedShift = "";

		using (HttpResponseMessage response = await httpClient.GetAsync(url))
		{
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();

				var shiftDataArray = JArray.Parse(jsonResponse);

				Table table = new Table();
				table.Expand();
				table.AddColumns("Id", "Employee Name", "Start of Shift", "End of Shift");

				foreach (var shiftData in shiftDataArray)
				{
					int Id = (int)shiftData["id"];
					string EmployeeName = (string)shiftData["employeeName"];
					string StartOfShift = (string)shiftData["startOfShift"];
					string EndOfShift = (string)shiftData["endOfShift"];

					table.AddRow($"{Id}", $"{EmployeeName}", $"{StartOfShift}", $"{EndOfShift}");
				}

				AnsiConsole.Write(table);
			}
		}

				selectedShift = AnsiConsole.Ask<string>("Enter the ID of the Shift you want to remove:");

				using (HttpResponseMessage deleteResponse = await httpClient.DeleteAsync(selectedShift))
				{
					if (deleteResponse.IsSuccessStatusCode)
					{
						AnsiConsole.WriteLine("Your selected Shift was deleted");
						Console.WriteLine();
						Console.WriteLine();
						Console.WriteLine("Press Any Key to continue......");
					}
					else
					{
						AnsiConsole.WriteLine("Couldn't delete shift");
						Console.WriteLine();
						Console.WriteLine();
						Console.WriteLine("Press Any Key to continue......");
					}
				}
			
		
	}
}
