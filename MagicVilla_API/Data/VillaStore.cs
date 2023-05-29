using MagicVilla_API.Models.Dto;

namespace MagicVilla_API.Data
{
    public static class VillaStore
    {
        // Test list of data
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto { 
                Id              = 1,
                Name            = "Test 001",
                Occupants       = 4,
                SquareMeters    = 10,
            },
            new VillaDto
            {
                Id              = 2,
                Name            = "Test 002",
                Occupants       = 6,
                SquareMeters    =27,
            }
        };
    }
}
