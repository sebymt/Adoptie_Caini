﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adoptie_Caini.Data;
using Adoptie_Caini.Models;

namespace Adoptie_Caini.Pages.Breeds
{
    public class EditModel : PageModel
    {
        private readonly Adoptie_Caini.Data.Adoptie_CainiContext _context;

        public EditModel(Adoptie_Caini.Data.Adoptie_CainiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Breed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BreedExists(Breed.ID))
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

        private bool BreedExists(int id)
        {
            return _context.Breed.Any(e => e.ID == id);
        }
    }
}
