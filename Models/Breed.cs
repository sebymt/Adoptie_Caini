using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adoptie_Caini.Models
{
    public class Breed
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Acest câmp poate să conțină doar litere și spații."), Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Rasă")]
        public string BreedName { get; set; }
        public ICollection<Dog> Dogs { get; set; } //navigation property
    }
}
