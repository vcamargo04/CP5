using SorveteriaModel;
using SorveteriaModel.DTO;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;
using SorvetesRepository;
using SorvetesService;


namespace SorveteriaAPI.Controllers
{
    [Route("api/sorvetes")]
    [ApiController]
    [Tags("Sorvetes")]
    public class SorvetesController : ControllerBase
    {
        private readonly IRepository<Sorvete> _sorveteRepository;
        private readonly SorveteService _sorveteService;

        public SorvetesController(IRepository<Sorvete> sorveteRepository)
        {
            _sorveteRepository = sorveteRepository;
            _sorveteService = new SorveteService();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<SorveteResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(SorveteriaModel.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<SorveteResponse>>> GetAll()
        {
            List<Sorvete> sorvetes = await _sorveteRepository.GetAll();
            return Ok(_sorveteService.SorvetesToListResponse(sorvetes));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SorveteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(SorveteriaModel.ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido. O ID deve ser uma string hexadecimal de 24 caracteres.");
            }

            var sorvete = await _sorveteRepository.GetById(objectId);
            if (sorvete == null)
            {
                return NotFound();
            }

            return Ok(_sorveteService.SorveteToResponse(sorvete));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SorveteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(SorveteriaModel.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] SorveteRequest sorveteRequest)
        {
            Sorvete sorvete = _sorveteService.RequestToSorvete(sorveteRequest);

            if (sorvete == null)
            {
                return BadRequest();
            }

            await _sorveteRepository.Add(sorvete);
            var sorveteResponse = _sorveteService.SorveteToResponse(sorvete);

            return Ok(sorveteResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SorveteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(SorveteriaModel.ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(string id, [FromBody] SorveteRequest sorveteRequest)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido. O ID deve ser uma string hexadecimal de 24 caracteres.");
            }

            Sorvete sorvete = _sorveteService.RequestToSorvete(sorveteRequest);
            sorvete.Id = objectId;

            await _sorveteRepository.Update(objectId, sorvete);
            var sorveteResponse = _sorveteService.SorveteToResponse(sorvete);

            return Ok(sorveteResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(SorveteriaModel.ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido. O ID deve ser uma string hexadecimal de 24 caracteres.");
            }

            var sorvete = await _sorveteRepository.GetById(objectId);
            if (sorvete == null)
            {
                return NotFound();
            }

            await _sorveteRepository.Delete(objectId);
            return Ok();
        }
    }
}
