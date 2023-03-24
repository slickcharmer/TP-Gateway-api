using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;

namespace AllergyServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {

        ILogic logic;

        public AllergyController(ILogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("GetAllergies")]   
        public IActionResult Get() 
        {
            var details = logic.GetAllergies();
            if(details!=null)
            {
            return Ok(details);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("AddAllergy")]
        public IActionResult Add([FromBody] Models.Allergy allergy)
        {
            try
            {
                allergy.AllergyId = Guid.NewGuid();
                var details = logic.AddAllergy(allergy);
                return Created("Add", details);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
