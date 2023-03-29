using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PatientFluentApi.Entities;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientLoginController : ControllerBase
    {
        ILogic logic;

        public PatientLoginController(ILogic logic)
        {
            this.logic = logic;
        }

        //done
        [HttpGet("Get")]
        public IActionResult Get([FromQuery] string email, [FromQuery] string password) 
        {
            try
            {
                var result = logic.GetPatient(email, password);
                if(result == "1") return Ok(result);
                else return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //done
        [HttpPost("Add")]
        public IActionResult Add([FromBody] PatientLogin patientLogin)
        {
            try
            {
                var patient = logic.AddPatient(patientLogin);
                if (patient != null) return CreatedAtAction("Add", patient);
                else return Ok(StatusCodes.Status302Found);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody] PatientLogin patientLogin)
        {
            try
            {
                var patient = logic.UpdatePatient(patientLogin);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //done
        [HttpDelete("Delete/{email}")]
        public IActionResult Delete([FromRoute] string email)
        {
            try
            {
                var patient = logic.DeletePatient(email);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
