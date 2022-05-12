using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PantawidPamilyaProgram.Data;
using PantawidPamilyaProgram.Models;

namespace PantawidPamilyaProgram.Pages._4ps
{
    public class DeleteModel : PageModel
    {
        private readonly PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext _context;

        public DeleteModel(PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Pppp Pppp { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pppp == null)
            {
                return NotFound();
            }

            var pppp = await _context.Pppp.FirstOrDefaultAsync(m => m.Id == id);

            if (pppp == null)
            {
                return NotFound();
            }
            else 
            {
                Pppp = pppp;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pppp == null)
            {
                return NotFound();
            }
            var pppp = await _context.Pppp.FindAsync(id);

            if (pppp != null)
            {
                Pppp = pppp;
                _context.Pppp.Remove(Pppp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
