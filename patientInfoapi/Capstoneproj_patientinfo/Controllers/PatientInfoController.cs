using BuisnessLogic;
using PIDataLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Capstoneproj_patientinfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInfoController : ControllerBase
    {
        ILogic logic;
        
        public PatientInfoController(ILogic logic)
        {
            this.logic = logic;
        }
        [HttpGet("GetallPatientInfo")]
        public IActionResult GetallPatientInfo()
        {
            try
            {
                var response = logic.GetallPatientinfos();
                return Ok(response);

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

        [HttpGet("GetPatientInfobyemail/{Email}")]
        public IActionResult GetPatientInfobyemail([FromRoute] string Email)
        {
            try
            {
                var response = logic.GetPatientDetailsByemail(Email);
                return Ok(response);

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

        [HttpGet("GetPatientInfobyId/{id}")]

        public IActionResult GetPatientInfobyId([FromRoute] Guid id)
        {
            try
            {
                var response = logic.GetPatientDetailsById(id);
                return Ok(response);

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

        [HttpPost("AddnewPatientinfo")]
        public IActionResult PostPatientInfo([FromBody] Patientinfo patientinfo)
        {
            try
            {
                patientinfo.PatId = Guid.NewGuid();
                string res = logic.AddnewPatientInfo(patientinfo);
                if(res == "1") return Created("Added", patientinfo);
                else return BadRequest(res);
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
        [HttpPut("UpdatePatientinfo")]
        public IActionResult UpdatepatientInfo( Guid Pat_id,[FromBody] Patientinfo patientinfo)
        {

            try
            {

               var response= logic.updatePatientinfos(Pat_id, patientinfo);
               return Created("Added", patientinfo);

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
