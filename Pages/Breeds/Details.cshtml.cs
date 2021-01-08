using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Adoptie_Caini.Data;
using Adoptie_Caini.Models;

namespace Adoptie_Caini.Pages.Breeds
{
    public class DetailsModel : PageModel
    {
        private readonly Adoptie_Caini.Data.Adoptie_CainiContext _context;

        public DetailsModel(Adoptie_Caini.Data.Adoptie_CainiContext context)
        {
            _context = context;
        }

        public Breed Breed { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Breed = await _context.Breed.FirstOrDefaultAsync(m => m.ID == id);

            if (Breed == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
