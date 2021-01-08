using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Adoptie_Caini.Data;


namespace Adoptie_Caini.Models
{
    public class DogColorsPageModel : PageModel
    {
        public List<AssignedColorData> AssignedColorDataList;
        public void PopulateAssignedColorData(Adoptie_CainiContext context, Dog dog)
        {
            var allColors = context.Color;
            var dogColors = new HashSet<int>(dog.DogColors.Select(c => c.DogID));
            AssignedColorDataList = new List<AssignedColorData>();
            foreach (var col in allColors)
            {
                AssignedColorDataList.Add(new AssignedColorData
                {
                    ColorID = col.ID,
                    Name = col.ColorName,
                    Assigned = dogColors.Contains(col.ID)
                });
            }
        }
        public void UpdateDogColors(Adoptie_CainiContext context, string[] selectedColors, Dog dogToUpdate)
        {
            if (selectedColors == null)
            {
               dogToUpdate.DogColors = new List<DogColor>();
               return;
            }
            var selectedColorsHS = new HashSet<string>(selectedColors);
            var dogColors = new HashSet<int>(dogToUpdate.DogColors.Select(c => c.Color.ID));
            foreach (var col in context.Color)
            {
                if (selectedColorsHS.Contains(col.ID.ToString()))
                {
                    if (!dogColors.Contains(col.ID))
                    {
                        dogToUpdate.DogColors.Add(
                            new DogColor
                            {
                                DogID = dogToUpdate.ID,
                                ColorID = col.ID
                            });
                    }
                }
                else
                {
                    if (dogColors.Contains(col.ID))
                    {
                        DogColor courseToRemove = dogToUpdate.DogColors.SingleOrDefault(i => i.ColorID == col.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }





    }
}
