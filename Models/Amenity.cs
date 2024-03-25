using System.ComponentModel.DataAnnotations;


namespace ApiVilla.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string VillaName { get; set; }

        public string Description { get; set; }



    }
}
