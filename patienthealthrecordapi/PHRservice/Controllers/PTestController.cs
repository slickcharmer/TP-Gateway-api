using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PTestController : ControllerBase
    {
        ILogic _logic;
        public PTestController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpPost("AddTestRecords")]
        public ActionResult Add([FromBody] Models.Patient_Test r)
        {
            try
            {
                r.Id = Guid.NewGuid();
                var add = _logic.AddTestReport(r);
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

        [HttpPut("modifyTest/{Id}")]
        public ActionResult UpdateTestRecord([FromRoute] string Id, [FromBody] Models.Patient_Test r)
        {
            try
            {
                if (Id != null)
                {
                    _logic.UpdatePatientTest(Id, r);
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
