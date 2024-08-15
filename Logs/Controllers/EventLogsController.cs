using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Logs.Data;
using Logs.Models;

[Route("api/[controller]")]
[ApiController]
public class EventLogsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventLogsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/EventLogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventLog>>> GetEventLogs()
    {
        return await _context.EventLogs.ToListAsync();
    }

    // GET: api/EventLogs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EventLog>> GetEventLog(int id)
    {
        var eventLog = await _context.EventLogs.FindAsync(id);

        if (eventLog == null)
        {
            return NotFound();
        }

        return eventLog;
    }

    // POST: api/EventLogs
    [HttpPost]
    public async Task<ActionResult<EventLog>> PostEventLog(EventLog eventLog)
    {
        _context.EventLogs.Add(eventLog);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEventLog), new { id = eventLog.Id }, eventLog);
    }

    // Nuevo método para filtrar eventos por TipoEvento y rango de Fechas
    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<EventLog>>> FilterEventLogs(string tipoEvento, DateTime? fechaInicio, DateTime? fechaFin)
    {
        var query = _context.EventLogs.AsQueryable();

        if (!string.IsNullOrEmpty(tipoEvento))
        {
            query = query.Where(e => e.TipoEvento == tipoEvento);
        }

        if (fechaInicio.HasValue)
        {
            query = query.Where(e => e.Fecha >= fechaInicio.Value);
        }

        if (fechaFin.HasValue)
        {
            query = query.Where(e => e.Fecha <= fechaFin.Value);
        }

        var filteredEvents = await query.ToListAsync();

        return Ok(filteredEvents);
    }
    // PUT: api/EventLogs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEventLog(int id, EventLog eventLog)
    {
        if (id != eventLog.Id)
        {
            return BadRequest();
        }

        _context.Entry(eventLog).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventLogExists(id))
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

    private bool EventLogExists(int id)
    {
        return _context.EventLogs.Any(e => e.Id == id);
    }

    // DELETE: api/EventLogs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventLog(int id)
    {
        var eventLog = await _context.EventLogs.FindAsync(id);
        if (eventLog == null)
        {
            return NotFound();
        }

        _context.EventLogs.Remove(eventLog);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}
