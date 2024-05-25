using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //The form that the user will complete. It will ask the user's favorite animal,
    //how many they have owned if any and check if generally it is a good animal as a pet.
    public class Form
    {
        public int FormId { get; set; }
        //Name of the animal
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        //Number of that animal owned
        [Range(0, int.MaxValue)]
        public int Owned { get; set; }
        //Is this a good animal to have as a pet.
        public bool GoodPet { get; set; }
    }
}
