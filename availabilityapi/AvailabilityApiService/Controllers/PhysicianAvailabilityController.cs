using FluentApi;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using Microsoft.Data.SqlClient;
using FluentApi.Entities;

namespace AvailabilityApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicianAvailabilityController : ControllerBase
    {
        ILogic logic;
        public PhysicianAvailabilityController(ILogic logic) 
        {
            this.logic = logic;
        }

        //done
        [HttpGet("GetSchedule")]
        public IActionResult Get([FromQuery] string day)
        {
            try
            {
                var schedule = logic.GetSchedule(day);
                if (schedule != null)
                    return Ok(schedule);
                else
                    return BadRequest("No schedules found");
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

        //done
        [HttpPost("AddSchedule")]
        public IActionResult Add([FromBody] DoctorSchedule doctorSchedule)
        {
            try
            {
                logic.AddSchedule(doctorSchedule);
                return CreatedAtAction("Add", doctorSchedule);
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //done
        [HttpPut("UpdateAllSchedules")]
        public IActionResult UpdateAll([FromQuery] int day, [FromBody] IEnumerable<DoctorSchedule> doctorSchedules)
        {
            try
            {
                if (doctorSchedules != null)
                {
                    logic.UpdateAllDoctors(day, doctorSchedules);
                    return Ok(doctorSchedules);
                }
                else
                    return BadRequest("Null data couldn't be updated");
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
