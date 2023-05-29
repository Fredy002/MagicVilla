using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {

        // Logger dependency injection

        private readonly ILogger<VillaController> _logger;

        private readonly ApplicationDbContext _db;

        public VillaController( ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        // Create the list of villas

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVilla()
        {
            _logger.LogInformation("Get the villas");
            // return Ok(VillaStore.villaList); // returns data from VillaStore, which is used as a mock database
            return Ok(_db.Villas.ToList()); // returns data from the database
        }


        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if ( id==0 )
            {
                // error control -> id = 0
                _logger.LogInformation("Error getting villa with id " + id);
                return BadRequest();
            }

            // var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id); // returns data from VillaStore, which is used as a mock database
            var villa = _db.Villas.FirstOrDefault(v => v.Id == id); // returns data from the database

            if ( villa == null)
            {
                // error control -> id does not exist
                return NotFound();
            }


            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // returns data from VillaStore, which is used as a mock database
            // if(VillaStore.villaList.FirstOrDefault(v=>v.Name.ToLower() == villaDto.Name.ToLower()) != null){ 

            // returns data from the database
            if (_db.Villas.FirstOrDefault(v => v.Name.ToLower() == villaDto.Name.ToLower()) != null) {  
                ModelState.AddModelError("ExistingName", "The village with this name already exists!");
                return BadRequest(ModelState);
            }

            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }
            if (villaDto.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            // returns data from VillaStore, which is used as a mock database
            /*
            villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);
            */ 

            // returns data from the database
            Villa model = new Villa()
            {
                Name            = villaDto.Name,
                Description     = villaDto.Description,
                Rate            = villaDto.Rate,
                Occupants       = villaDto.Occupants,
                SquareMeters    = villaDto.SquareMeters,
                ImageURL        = villaDto.ImageURL,
                Amenity         = villaDto.Amenity
            };

            _db.Villas.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = villaDto.Id}, villaDto);
            
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            // Log capture

            // returns data from VillaStore, which is used as a mock database
            // var villa = VillaStore.villaList.FirstOrDefault(V => V.Id == id); 

            // returns data from the database
            var villa = _db.Villas.FirstOrDefault(V => V.Id == id); 

            if(villa == null)
            {
                return NotFound();
            }

            // returns data from VillaStore, which is used as a mock database
            // VillaStore.villaList.Remove(villa); 

            // returns data from the database
            _db.Villas.Remove(villa); 
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if( villaDto == null || id != villaDto.Id)
            {
                return BadRequest();
            }

            // Log capture

            // returns data from VillaStore, which is used as a mock database
            /*
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            villa.Name          = villaDto.Name;
            villa.Occupants     = villaDto.Occupants;
            villa.SquareMeters  = villaDto.SquareMeters;
            */ 

            // returns data from the database
            Villa model = new()
            {
                Id              = villaDto.Id,
                Name            = villaDto.Name,
                Description     = villaDto.Description,
                Rate            = villaDto.Rate,
                Occupants       = villaDto.Occupants,
                SquareMeters    = villaDto.SquareMeters,
                ImageURL        = villaDto.ImageURL,
                Amenity         = villaDto.Amenity
            };

            _db.Villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            // Log capture

            // returns data from VillaStore, which is used as a mock database
            // var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id); 

            // returns data from the database
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            VillaDto villaDto = new()
            {
                Id              = villa.Id,
                Name            = villa.Name,
                Description     = villa.Description,
                Rate            = villa.Rate,
                Occupants       = villa.Occupants,
                SquareMeters    = villa.SquareMeters,
                ImageURL        = villa.ImageURL,
                Amenity         = villa.Amenity
            };

            if (villa == null)
            {
                return BadRequest();
            };

            // returns data from VillaStore, which is used as a mock database
            // patchDto.ApplyTo(villa, ModelState); 

            // returns data from the database
            patchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            Villa model = new()
            {
                Id              = villaDto.Id,
                Name            = villaDto.Name,
                Description     = villaDto.Description,
                Rate            = villaDto.Rate,
                Occupants       = villaDto.Occupants,
                SquareMeters    = villaDto.SquareMeters,
                ImageURL        = villaDto.ImageURL,
                Amenity         = villaDto.Amenity
            };
               
            // returns data from the database
            _db.Villas.Update(model);
            _db.SaveChanges(); 

            return NoContent();
        }
    }
}
