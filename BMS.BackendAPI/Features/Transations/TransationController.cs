using BMS.Models.Transations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.BackendAPI.Features.Transations
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransationController : ControllerBase
    {
        private readonly TransationService _transationService;

        public TransationController()
        {
            _transationService = new TransationService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<TransationDTO> transations = _transationService.GetAllTransations();
                return Ok(transations);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(TransationRequest request)
        {
            try
            {
                int result = _transationService.AddTransation(request);

                string msg = result > 0 ? "transation success" : "failed";
                return Ok(msg);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
