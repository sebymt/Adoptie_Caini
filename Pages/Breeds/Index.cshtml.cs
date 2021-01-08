﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Adoptie_Caini.Data.Adoptie_CainiContext _context;

        public IndexModel(Adoptie_Caini.Data.Adoptie_CainiContext context)
        {
            _context = context;
        }

        public IList<Breed> Breed { get;set; }

        public async Task OnGetAsync()
        {
            Breed = await _context.Breed.ToListAsync();
        }
    }
}
