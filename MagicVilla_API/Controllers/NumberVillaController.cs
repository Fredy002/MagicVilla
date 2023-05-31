using AutoMapper;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repositorie.IRepositorie;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberVillaController : ControllerBase
    {

        // Logger dependency injection

        private readonly ILogger<NumberVillaController> _logger;

        private readonly IVillaRepositorie _villaRepo;

        private readonly INumberVillaRepositorie _numberRepo;

        private readonly IMapper _mapper;

        protected APIResponse _response;


        public NumberVillaController(ILogger<NumberVillaController> logger, IVillaRepositorie villaRepo, INumberVillaRepositorie numberRepo, IMapper mapper)
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _numberRepo = numberRepo;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetNumberVillas()
        {
            try
            {
                _logger.LogInformation("Get the number of villas");

                IEnumerable<NumberVilla> numbervillaList = await _numberRepo.GetAll();

                _response.Result = _mapper.Map<IEnumerable<VillaDto>>(numbervillaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("id:int", Name = "GetNumberVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetNumberVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogInformation("Error getting villa with id " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var numbervilla = await _numberRepo.Get(v => v.VillaNumber == id);
                if (numbervilla == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<NumberVillaDto>(numbervilla);
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateNumberVilla([FromBody] NumberVillaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _numberRepo.Get(v => v.VillaNumber == createDto.VillaNumber) != null)
                {
                    ModelState.AddModelError("ExistingName", "The villa with this number already exists!");
                    return BadRequest(ModelState);
                }

                if (await _villaRepo.Get(v => v.Id == createDto.VillaId) == null)
                {
                    ModelState.AddModelError("ForeignCode", "The id of the villa does not exist!");
                    return BadRequest(ModelState);
                }

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                NumberVilla model = _mapper.Map<NumberVilla>(createDto);

                model.DateCreated = DateTime.Now;
                model.DateUpdated = DateTime.Now;

                await _numberRepo.Create(model);
                _response.Result = model;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetNumberVilla", new { id = model.VillaNumber }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNumberVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var numbervilla = await _numberRepo.Get(V => V.VillaNumber == id);

                if (numbervilla == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _numberRepo.Remove(numbervilla);

                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return BadRequest(_response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNumberVilla(int id, [FromBody] NumberVillaUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.VillaNumber)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (await _villaRepo.Get(V => V.Id == updateDto.VillaId) == null)
            {
                ModelState.AddModelError("ForeignCode", "The id of the villa does not exist!");
                return BadRequest(ModelState);
            }

            NumberVilla model = _mapper.Map<NumberVilla>(updateDto);

            await _numberRepo.Update(model);

            _response.StatusCode = HttpStatusCode.NoContent;

            return Ok(_response);
        }
    }
}
