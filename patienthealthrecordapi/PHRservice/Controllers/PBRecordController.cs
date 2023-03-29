using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PBRecordController : ControllerBase
    {
        private readonly ILogic _logic;
        public PBRecordController(ILogic logic)
        {
            _logic = logic;
        }

        /*[HttpGet("GetAllBasicRecords")]

        public ActionResult GetRecords()
        {
            try
            {
                var tara = _logic.GetBasicDetail();
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

        [HttpGet("GetPRBy/{id}")]
        public ActionResult GetById([FromRoute] string id)
        {
            try
            {
                var search = _logic.GetById(id);
                if (search.Count() > 0)
                    return Ok(search);
                else
                    return NotFound(search);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("AddPBRecords")]
        public ActionResult Add([FromBody] Models.Patient_Basic_Record r)
        {
            try
            {
                r.Id = Guid.NewGuid();
                var add = _logic.AddBasicR(r);
                return CreatedAtAction("Add", add);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("modify/{Id}")]
        public ActionResult UpdateBasicRecord([FromRoute] string Id, [FromBody] Models.Patient_Basic_Record r)
        {
            try
            {
                if (Id != null)
                {
                    _logic.UpdateBR(Id, r);
                    return Ok(r);
                }
                else
                    return BadRequest(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
