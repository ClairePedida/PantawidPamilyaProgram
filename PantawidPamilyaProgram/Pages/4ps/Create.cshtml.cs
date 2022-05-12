using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PantawidPamilyaProgram.Data;
using PantawidPamilyaProgram.Models;

namespace PantawidPamilyaProgram.Pages._4ps
{
    public class CreateModel : PageModel
    {
        private readonly PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext _context;

        public CreateModel(PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pppp Pppp { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Pppp == null || Pppp == null)
            {
                return Page();
            }

            _context.Pppp.Add(Pppp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
