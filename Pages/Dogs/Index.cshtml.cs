using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Adoptie_Caini.Data;
using Adoptie_Caini.Models;

namespace Adoptie_Caini.Pages.Dogs
{
    public class IndexModel : PageModel
    {
        private readonly Adoptie_Caini.Data.Adoptie_CainiContext _context;

        public IndexModel(Adoptie_Caini.Data.Adoptie_CainiContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; }
        public DogData DogD { get; set; }
        public int DogID { get; set; }
        public int ColorID { get; set; }

        public async Task OnGetAsync(int? id, int? colorID)
        {
            DogD = new DogData();
            DogD.Dogs = await _context.Dog
             .Include(b => b.Breed)
             .Include(b => b.DogColors)
             .ThenInclude(b => b.Color)
             .AsNoTracking()
             .OrderBy(b => b.Breed)
             .ToListAsync();

            if (id != null)
            {
                DogID = id.Value;
                Dog dog = DogD.Dogs
                .Where(i => i.ID == id.Value).Single();
                DogD.Colors = dog.DogColors.Select(s => s.Color);
            }



        }
    }
}
