using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        ILogic _logic;
        public MedicationController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpPost("AddMedicalRecords")]
        public ActionResult Add([FromBody] Models.Patient_Medication r)
        {
            try
            {
                r.Id = Guid.NewGuid();
                var add = _logic.AddMedicalReport(r);
                return CreatedAtAction("Add", add);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("updatemedication/{Id}")]
        public ActionResult UpdateMedicalRecord([FromRoute] string Id, [FromBody] Models.Patient_Medication r)
        {
            try
            {
                if (Id != null)
                {
                    _logic.UpdateMedicalReport(Id, r);
                    return Ok(r);
                }
                else
                    return BadRequest($"something wrong with {Id}, please try again!");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
