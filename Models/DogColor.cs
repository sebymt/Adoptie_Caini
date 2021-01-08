using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adoptie_Caini.Models
{
    public class DogColor
    {
        public int ID { get; set; }
        public int DogID { get; set; }
        public Dog Dog { get; set; }
        public int ColorID { get; set; }
        public Color Color { get; set; }

    }
}
