using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adoptie_Caini.Models
{
    public class DogData
    {
        public IEnumerable<Dog> Dogs { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<DogColor> DogColors { get; set; }

    }
}
