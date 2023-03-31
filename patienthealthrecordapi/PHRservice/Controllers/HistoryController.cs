using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PHRservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        ILogic _logic;
        public HistoryController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpGet("GetAllHR/{id}")]
        public IActionResult GetHR([FromRoute] string id)
        {
            var res = _logic.GetAllHR(id);
            return Ok(res);
        }

        [HttpGet("GetAllBR/{id}")]
        public IActionResult GetBR([FromRoute] string id)
        {
            var res = _logic.GetAllBR(id);
            return Ok(res);
        }
        [HttpGet("GetTR/{id}/{AID}")]
        public IActionResult GetTR([FromRoute] string id, [FromRoute] string AID)
        {
            var res = _logic.GetTRByAID(id, AID);
            return Ok(res);
        }
        [HttpGet("GetMR/{id}/{AID}")]
        public IActionResult Get([FromRoute] string id, [FromRoute] string AID)
        {
            var res = _logic.GetMRByAID(id, AID);
            return Ok(res);
        }
        [HttpGet("GetAR/{id}/{AID}")]
        public IActionResult GetAR([FromRoute] string id, [FromRoute] string AID)
        {
            var res = _logic.GetARByAID(id, AID);
            return Ok(res);
        }
    }
}
