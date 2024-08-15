using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logs.Models;
using Logs.Data;

namespace Logs.Pages
{
    public class CreateEventModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateEventModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventLog EventLog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Registra o depura los errores de validación
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            _context.EventLogs.Add(EventLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("/CreateEvent");
        }

    }
}

