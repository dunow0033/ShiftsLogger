using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftsUI.API;

namespace ShiftsUI.Controllers;

internal class ShiftLoggerController
{
	private ShiftLoggerApiAccess _apiRepo;

	public ShiftLoggerController(ShiftLoggerApiAccess apiRepo)
	{
		_apiRepo = apiRepo;
	}

	public async Task<IEnumerable<Shift>> GetShifts()
	{
		return await _apiRepo.GetShifts();
	}
}
