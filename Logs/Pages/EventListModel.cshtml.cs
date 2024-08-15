using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Logs.Data;
using Logs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Logs.Pages
{
    public class EventListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EventListModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EventLog> Eventos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterTipoEvento { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? FilterFechaInicio { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? FilterFechaFin { get; set; }

        public SelectList TipoEventoOptions => new SelectList(new[] { "Api", "Formulario" });

        public async Task OnGetAsync()
        {
            var query = _context.EventLogs.AsQueryable();

            if (!string.IsNullOrEmpty(FilterTipoEvento))
            {
                query = query.Where(e => e.TipoEvento == FilterTipoEvento);
            }

            if (FilterFechaInicio.HasValue)
            {
                query = query.Where(e => e.Fecha >= FilterFechaInicio.Value);
            }

            if (FilterFechaFin.HasValue)
            {
                query = query.Where(e => e.Fecha <= FilterFechaFin.Value);
            }

            Eventos = await query.ToListAsync();
        }
    }
}
