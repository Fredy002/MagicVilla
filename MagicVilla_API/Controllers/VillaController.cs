using AutoMapper;
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

        private readonly IMapper _mapper;

        public VillaController( ILogger<VillaController> logger, ApplicationDbContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }


        // Create the list of villas

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVilla()
        {
            _logger.LogInformation("Get the villas");

            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();

            // return Ok(VillaStore.villaList); // returns data from VillaStore, which is used as a mock database
            return Ok(_mapper.Map<IEnumerable<VillaDto>>(villaList)); // returns data from the database
        }


        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            if ( id==0 )
            {
                // error control -> id = 0
                _logger.LogInformation("Error getting villa with id " + id);
                return BadRequest();
            }

            // var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id); // returns data from VillaStore, which is used as a mock database
            var villa = await _db.Villas.FirstOrDefaultAsync(v => v.Id == id); // returns data from the database

            if ( villa == null)
            {
                // error control -> id does not exist
                return NotFound();
            }


            return Ok(_mapper.Map<VillaDto>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CreateVilla([FromBody] VillaCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // returns data from VillaStore, which is used as a mock database
            // if(VillaStore.villaList.FirstOrDefault(v=>v.Name.ToLower() == villaDto.Name.ToLower()) != null){ 

            // returns data from the database
            if (await _db.Villas.FirstOrDefaultAsync(v => v.Name.ToLower() == createDto.Name.ToLower()) != null) {
                ModelState.AddModelError("ExistingName", "The village with this name already exists!");
                return BadRequest(ModelState);
            }

            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            // returns data from VillaStore, which is used as a mock database
            /*
            villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);
            */


            // returns data from the database
            /*
            Villa model = new Villa()
            {
                Name            = createDto.Name,
                Description     = createDto.Description,
                Rate            = createDto.Rate,
                Occupants       = createDto.Occupants,
                SquareMeters    = createDto.SquareMeters,
                ImageURL        = createDto.ImageURL,
                Amenity         = createDto.Amenity
            };
            */

            Villa model = _mapper.Map<Villa>(createDto);

            await _db.Villas.AddAsync(model);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = model.Id}, model);
            
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            // Log capture

            // returns data from VillaStore, which is used as a mock database
            // var villa = VillaStore.villaList.FirstOrDefault(V => V.Id == id); 

            // returns data from the database
            var villa = await _db.Villas.FirstOrDefaultAsync(V => V.Id == id); 

            if(villa == null)
            {
                return NotFound();
            }

            // returns data from VillaStore, which is used as a mock database
            // VillaStore.villaList.Remove(villa); 

            // returns data from the database
            _db.Villas.Remove(villa); 
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDto updateDto)
        {
            if( updateDto == null || id != updateDto.Id)
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
            /*
            Villa model = new()
            {
                Id              = updateDto.Id,
                Name            = updateDto.Name,
                Description     = updateDto.Description,
                Rate            = updateDto.Rate,
                Occupants       = updateDto.Occupants,
                SquareMeters    = updateDto.SquareMeters,
                ImageURL        = updateDto.ImageURL,
                Amenity         = updateDto.Amenity
            };
            */

            Villa model = _mapper.Map<Villa>(updateDto);

            _db.Villas.Update(model);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

            // Log capture

            // returns data from VillaStore, which is used as a mock database
            // var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id); 

            // returns data from the database
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);
            
            /*
            VillaUpdateDto villaDto = new()
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
            */

            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);

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

            /*
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
            */

            Villa model = _mapper.Map<Villa>(villaDto);

            // returns data from the database
            _db.Villas.Update(model);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
