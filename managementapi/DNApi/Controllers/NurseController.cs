using BusinessLogicLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DNApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseLogic _logic;
        public NurseController(INurseLogic logic)
        {
            _logic = logic;
        }

        //done
        [HttpGet("getAllNurse")]
        public IActionResult GetAll()
        {
            try
            {
                var res = _logic.GetAll();
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return BadRequest();
        }

        //done
        [HttpPost("AddNurse")]
        public IActionResult Add(DataLayer.Entities.Nurse nurse)
        {
            try
            {
                nurse.Id = Guid.NewGuid();
                string res = _logic.AddNurse(nurse);
                if (res != "1")
                {
                    return BadRequest();
                }
                else
                {
                    return Created("added", nurse);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return BadRequest();
        }

        [HttpGet("GetByEmail")]
        public IActionResult GetByEmail([FromQuery] string e)
        {
            try
            {
                var res = _logic.GetByEmail(e);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
    }
}
