using System.Text.Json.Serialization;

internal record class Shift(
	[property: JsonPropertyName("id")] int Id,
	[property: JsonPropertyName("employeeName")] string EmployeeName,
	[property: JsonPropertyName("startOfShift")] DateTime StartOfShift,
	[property: JsonPropertyName("endOfShift")] DateTime EndOfShift
	//[property: JsonPropertyName("duration")] TimeSpan Duration);
);

public class ShiftDto
{
	public int Id { get; set; }
	public string EmployeeName { get; set; }
	public DateTime StartOfShift { get; set; }
	public DateTime EndOfShift { get; set; }
}
