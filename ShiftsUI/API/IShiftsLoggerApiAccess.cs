using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftsUI.API;

internal interface IShiftsLoggerApiAccess
{
	public Task<IEnumerable<Shift>> GetShifts();
	public Task<Shift> GetShift(int id);
	public Task<bool> PostShift(ShiftDto shift);
	public Task<bool> DeleteShift(int selectedShift);
	public Task<bool> UpdateShift(ShiftDto newShift);
}
