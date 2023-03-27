using AuditLogic;
using AuditFluentApi.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditServiceController : ControllerBase
    {
        ILogic logic;

        public AuditServiceController(ILogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("GetAllAudits")]

        public IActionResult GetAll()
        {
            try
            {
                var audits = logic.GetAllAudits();
                if (audits != null)
                {
                    return Ok(audits);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPatientAudits/healthId")]

        public IActionResult Get([FromQuery] string healthId)
        {
            try
            {
                var audits = logic.GetPatientAudits(healthId);
                if (audits != null)
                {
                    return Ok(audits);
                }
                else
                {
                    return BadRequest($"No audits available for {healthId}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddAudit")]

        public IActionResult Add([FromBody] Audit audit)
        {
            if (audit is not null)
            {
                try
                {
                    var newAudit = logic.AddAudit(audit);
                    return CreatedAtAction("Add", newAudit);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Null body provided");
            }
        }

    }
}
