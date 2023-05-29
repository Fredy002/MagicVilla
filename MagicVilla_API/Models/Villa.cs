using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_API.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public double Rate { get; set; }

        [Required]
        public int Occupants { get; set; }

        [Required]
        public double SquareMeters { get; set; }

        public string ImageURL { get; set; }

        public string Amenity { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
