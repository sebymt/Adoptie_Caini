using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Adoptie_Caini.Data;
using Adoptie_Caini.Models;

namespace Adoptie_Caini.Pages.Dogs
{
    public class CreateModel : DogColorsPageModel
    {
        private readonly Adoptie_Caini.Data.Adoptie_CainiContext _context;

        public CreateModel(Adoptie_Caini.Data.Adoptie_CainiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BreedID"] = new SelectList(_context.Set<Breed>(), "ID", "BreedName");

            var dog = new Dog();
            dog.DogColors = new List<DogColor>();
            PopulateAssignedColorData(_context, dog);

            return Page();
        }

        [BindProperty]
        public Dog Dog { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedColors)
        {
            var newDog = new Dog();
            if (selectedColors != null)
            {
                newDog.DogColors = new List<DogColor>();
                foreach (var col in selectedColors)
                {
                    var colToAdd = new DogColor
                    {
                        ColorID = int.Parse(col)
                    };
                    newDog.DogColors.Add(colToAdd);
                }
            }

            if (await TryUpdateModelAsync<Dog>(newDog, "Dog", i => i.Image, i => i.Country, i => i.Weight, i => i.DateOfBirth, i => i.BreedID))
            {
                _context.Dog.Add(newDog);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedColorData(_context, newDog);
            return Page();
        }
    }
}
