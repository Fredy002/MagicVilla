﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.Dto
{
    public class NumberVillaUpdateDto
    {
        [Required]
        public int VillaNumber { get; set; }

        [Required]
        public int VillaId { get; set; }

        public string SpecialDetail { get; set; }
    }
}
