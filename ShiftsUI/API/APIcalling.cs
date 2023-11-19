using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

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

				//var shiftData = JObject.Parse(jsonResponse);
				//Dictionary<string, string> movieData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

				//Console.WriteLine(movies);

				foreach (var shiftData in shiftDataArray)
				{
					string EmployeeName = (string)shiftData["employeeName"];
					string StartOfShift = (string)shiftData["startOfShift"];
					string EndOfShift = (string)shiftData["endOfShift"];

					Console.WriteLine($"Employee Name: {EmployeeName}");
					Console.WriteLine($"\nStart of Shift:  {StartOfShift}");
					Console.WriteLine($"\nEnd of Shift:  {EndOfShift}");
					Console.WriteLine();
				}

				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("Press Any Key to continue......");
			}
		}
	}

	public static async void AddShift()
	{
		url = $"https://localhost:7275/api/Shift";

		HttpClient httpClient = new HttpClient();

		using (HttpResponseMessage response = await httpClient.PostAsync(url, ))
		{
			if (response.IsSuccessStatusCode)
			{
				string jsonResponse = await response.Content.ReadAsStringAsync();

				var shiftDataArray = JArray.Parse(jsonResponse);

				//var shiftData = JObject.Parse(jsonResponse);
				//Dictionary<string, string> movieData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

				//Console.WriteLine(movies);

				foreach (var shiftData in shiftDataArray)
				{
					string EmployeeName = (string)shiftData["employeeName"];
					string StartOfShift = (string)shiftData["startOfShift"];
					string EndOfShift = (string)shiftData["endOfShift"];

					Console.WriteLine($"Employee Name: {EmployeeName}");
					Console.WriteLine($"\nStart of Shift:  {StartOfShift}");
					Console.WriteLine($"\nEnd of Shift:  {EndOfShift}");
					Console.WriteLine();
				}

				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine("Press Any Key to continue......");
			}
		}
	}
}
