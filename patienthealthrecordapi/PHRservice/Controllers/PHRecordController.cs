using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PHRecordController : ControllerBase
    {
        ILogic _logic;
        public PHRecordController(ILogic logic)
        {
            _logic = logic;
        }


        /*[HttpGet("GetAllHealthRecords")]

        public ActionResult GetRecords()
        {
            try
            {
                var tara = _logic.GetHealthDetails();
                if (tara.Count() > 0)
                {
                    return Ok(tara);
                }
                else
                    return BadRequest($"There is no Records in database!");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        [HttpGet("GetHR/{id}")]
        public ActionResult GetById([FromRoute] string id)
        {
            try
            {
                var search = _logic.GetByHealthID(id);
                if (search.Count() > 0)
                    return Ok(search);
                else
                    return NotFound($"Records with HealthId {id} not available, please try with different Id");
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

        [HttpPost("AddPHRecords")]
        public ActionResult Add([FromBody] Models.Patient_Health_Record r)
        {
            try
            {
                r.Id = Guid.NewGuid();
                var add = _logic.AddHealthR(r);
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

        [HttpPut("updateHr/{Id}")]
        public ActionResult UpdateHealthRecord([FromRoute] string Id, [FromBody] Models.Patient_Health_Record r)
        {
            try
            {
                if (Id != null)
                {
                    _logic.UpdateHealthR(Id, r);
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
