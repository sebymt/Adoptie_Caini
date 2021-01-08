using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adoptie_Caini.Data;
using Adoptie_Caini.Models;

namespace Adoptie_Caini.Pages.Dogs
{
    public class EditModel : DogColorsPageModel
    {
        private readonly Adoptie_Caini.Data.Adoptie_CainiContext _context;

        public EditModel(Adoptie_Caini.Data.Adoptie_CainiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dog Dog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dog = await _context.Dog
             .Include(b => b.Breed)
             .Include(b => b.DogColors).ThenInclude(b => b.Color)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            if (Dog == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedColorData pentru o obtine informatiile necesare checkbox-urilor folosind clasa AssignedColorData

            PopulateAssignedColorData(_context, Dog);

            ViewData["BreedID"] = new SelectList(_context.Set<Breed>(), "ID", "BreedName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedColors)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dogToUpdate = await _context.Dog
             .Include(i => i.Breed)
             .Include(i => i.DogColors)
             .ThenInclude(i => i.Color)
             .FirstOrDefaultAsync(s => s.ID == id);

            if (dogToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Dog>(dogToUpdate, "Dog", i => i.Image, i => i.Country, i => i.Weight, i => i.DateOfBirth, i => i.Breed))
            {
                UpdateDogColors(_context, selectedColors, dogToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateDogColors pentru a aplica informatiile din checkboxuri la entitatea Dogs care
            //este editata
            UpdateDogColors(_context, selectedColors, dogToUpdate);
            PopulateAssignedColorData(_context, dogToUpdate);
            return Page();
        }
        /*
        private bool DogExists(int id)
        {
            return _context.Dog.Any(e => e.ID == id);
        } */
    }
}
