using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }


        public string Description { get; set; }

        [Required]
        public double Rate { get; set; }

        [Required]
        public int Occupants { get; set; }

        [Required]
        public double SquareMeters { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public string Amenity { get; set; }

    }
}
