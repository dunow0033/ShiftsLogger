using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShiftsUI.API;

internal class ShiftLoggerApiAccess : IShiftsLoggerApiAccess
{ 
	private readonly HttpClient _apiClient;

	public ShiftLoggerApiAccess(HttpClient apiClient)
	{
		_apiClient = apiClient;
	}

	public async Task<IEnumerable<Shift>> GetShifts()
	{
		List<Shift>? response = new List<Shift>();

		try
		{
			response = await _apiClient.GetFromJsonAsync<List<Shift>>("");
		}
		catch (Exception ex)
		{
			AnsiConsole.WriteLine($"API Service isn't responding. - {ex.Message}");
		}

		return response;
	}

	public async Task<bool> PostShift(ShiftDto shift)
	{
		var json = JsonSerializer.Serialize(shift);

		var content = new StringContent(json, Encoding.UTF8, "application/json");

		try
		{
			using (HttpResponseMessage response = await _apiClient.PostAsync("", content))
			{
				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		catch (Exception ex)
		{
			AnsiConsole.WriteLine($"API Service isn't responding. - {ex.Message}");
			return false;
		}
	}
}
