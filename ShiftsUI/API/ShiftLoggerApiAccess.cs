﻿using Spectre.Console;
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

	public async Task<Shift> GetShift(int id)
	{
		Shift? response = null;
		try
		{
			response = await _apiClient.GetFromJsonAsync<Shift>($"{id}");
		}
		catch (Exception ex)
		{
			AnsiConsole.WriteLine($"API Service isn't responding. - {ex.Message}");
		}

		return response;
	}

	public async Task<bool> UpdateShift(ShiftDto newShift)
	{
		try
		{
			using (HttpResponseMessage response = await _apiClient.PutAsJsonAsync($"{newShift.Id}", newShift))
			{
				if (!response.IsSuccessStatusCode)
				{
					return false;
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			AnsiConsole.WriteLine($"API Service isn't responding. - {ex.Message}, Press any key to return to Main Menu");
			return false;
		}
	}

	public async Task<bool> DeleteShift(int selectedShift)
	{
		try
		{
			using (HttpResponseMessage response = await _apiClient.DeleteAsync($"{selectedShift}"))
			{
				if (!response.IsSuccessStatusCode)
				{
					return false;
				}
			}

			return true;
		}
		catch (Exception ex)
		{
			AnsiConsole.WriteLine($"API Service isn't responding. - {ex.Message}");
			return false;
		}

	}
}
