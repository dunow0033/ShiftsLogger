using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsUI;

internal class Validator
{
	internal static bool ValidateDateTime(string shiftDate)
	{
		bool dateValid = false;

		if (DateTime.TryParseExact(shiftDate, "MM/dd/yyyy HH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out _))
		{
			dateValid = true;
		}

		return dateValid;
	}

	internal static bool AreDatesValid(DateTime startDate, DateTime endDate)
	{
		if (startDate < endDate)
		{
			return true;
		}
		else
		{
			AnsiConsole.WriteLine("End of shift can't be before start of shift");
			return false;
		}
	}
}
