using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PantawidPamilyaProgram.Data;
using PantawidPamilyaProgram.Models;

namespace PantawidPamilyaProgram.Pages._4ps
{
    public class EditModel : PageModel
    {
        private readonly PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext _context;

        public EditModel(PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext context)
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

            var pppp =  await _context.Pppp.FirstOrDefaultAsync(m => m.Id == id);
            if (pppp == null)
            {
                return NotFound();
            }
            Pppp = pppp;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pppp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PpppExists(Pppp.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PpppExists(int id)
        {
          return (_context.Pppp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
