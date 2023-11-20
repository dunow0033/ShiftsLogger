using ShiftsUI;
using ShiftsUI.API;
using ShiftsUI.Controllers;

namespace PhoneBook;

class Program
{
	private static HttpClient apiClient = new()
	{
		BaseAddress = new Uri("https://localhost:7275/api/Shift/")
	};

	static async Task Main()
	{
		var apiRepo = new ShiftLoggerApiAccess(apiClient);
		var controller = new ShiftLoggerController(apiRepo);
		var shiftApp = new UserInterface(controller);

		await shiftApp.Run();
	}
}
