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
#pragma warning disable CS8618
#pragma warning disable CS8604
    public class IndexModel : PageModel
    {
        private readonly PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext _context;

        public IndexModel(PantawidPamilyaProgram.Data.PantawidPamilyaProgramContext context)
        {
            _context = context;
        }

        public IList<Pppp> Pppp { get;set; } = default!;
        [BindProperty (SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Address { get; set; }
        [BindProperty (SupportsGet = true)]
        public string PersonelAddress { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> ppppQuery = from m in _context.Pppp
                                           orderby m.Address
                                           select m.Address;

            var pppp = from m in _context.Pppp
                      select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                pppp = pppp.Where(s => s.Name.Contains(SearchString));

            }
            if (!string.IsNullOrEmpty(PersonelAddress))
            {
                pppp = pppp.Where(x => x.Address == PersonelAddress);

            }
            Address = new SelectList(await ppppQuery.Distinct().ToListAsync());
            Pppp = await pppp.ToListAsync();
        }

        

#pragma warning restore CS8618
#pragma warning restore CS8604
    }
}
