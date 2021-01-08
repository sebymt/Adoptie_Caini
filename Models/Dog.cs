using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adoptie_Caini.Models
{
    public class Dog
    {
        public int ID { get; set; }
        [Display(Name = "Imagine")]
        public string Image { get; set; }
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Acest câmp poate să conțină doar litere și spații."), 
        Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Țara de proveniență")]
        public string Country { get; set; }
        [Range(0.1, 150)]
        [Display(Name = "Greutate (kg)")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Weight { get; set; }
        [Display(Name = "Data Nașterii")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int BreedID { get; set; }
        public Breed Breed { get; set; }  //navigation property
        [Display(Name = "Culoare")]
        public ICollection<DogColor> DogColors { get; set; }

    }
}
