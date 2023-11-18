using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsLoggerApi.Models;

public class Shift
{
	public int Id { get; set; }
	public string? EmployeeName { get; set; }

	[Required(ErrorMessage = "The startOfShift field is required.")]
	[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM-dd-yyyy HH:mm}")]
	public DateTime StartOfShift { get; set; }

	[Required(ErrorMessage = "The endOfShift field is required.")]
	[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM-dd-yyyy HH:mm}")]
	public DateTime EndOfShift { get; set; }
	//public TimeSpan Duration => EndOfShift - StartOfShift;
}
