using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApi.Models;
using ShiftsLoggerAPI;

namespace ShiftsLoggerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftController : ControllerBase
{
	private readonly ShiftContext _context;

	public ShiftController(ShiftContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Shift>>> GetShifts()
	{
		if (_context.Shifts == null)
		{
			return NotFound();
		}

		return await _context.Shifts.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Shift>> GetShift(int id)
	{
		if(_context.Shifts == null) 
		{
			return NotFound();
		}
		var shift = await _context.Shifts.FindAsync(id);

		if (shift == null)
		{
			return NotFound();
		}

		return shift;
	}

	[HttpPost]
	public async Task<ActionResult<Shift>> AddShift(Shift shift)
	{
		var newShift = new Shift
		{
			EmployeeName = shift.EmployeeName,
			StartOfShift = shift.StartOfShift,
			EndOfShift = shift.EndOfShift,
		};

		_context.Shifts.Add(newShift);
		await _context.SaveChangesAsync();

		return CreatedAtAction(nameof(AddShift), new { id = shift.Id }, newShift);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutShift(int id, Shift shift)
	{
		if (id != shift.Id)
		{
			return BadRequest();
		}

		_context.Entry(shift).State = EntityState.Modified;

		//if (newShift == null)
		//{
		//	return NotFound();
		//}

		//newShift.EmployeeName = shift.EmployeeName;
		//newShift.StartOfShift = shift.StartOfShift;
		//newShift.EndOfShift = shift.EndOfShift;

		try
		{
			await _context.SaveChangesAsync();
		}
		catch (DbUpdateConcurrencyException)
		{
			if (!ShiftExists(id))
			{
				return NotFound();
			}
			else
			{
				throw;
			}
		}

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteShift(int id)
	{
		var shift = await _context.Shifts.FindAsync(id);
		if(shift == null)
		{
			return NotFound();
		}

		_context.Shifts.Remove(shift);
		await _context.SaveChangesAsync();

		return NoContent();
	}

	private bool ShiftExists(int id)
	{
		return _context.Shifts.Any(e => e.Id == id);
	}
}
