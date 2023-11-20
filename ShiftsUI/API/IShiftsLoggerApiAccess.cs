using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsUI.API;

internal interface IShiftsLoggerApiAccess
{
	public Task<IEnumerable<Shift>> GetShifts();
}
