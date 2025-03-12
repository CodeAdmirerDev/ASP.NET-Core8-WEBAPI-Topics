using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISampleProjectWIthVS2022.Models;

namespace WebAPISampleProjectWIthVS2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {

        // In-memory data to store employee details
        private static List<Emp> _empList = new List<Emp>
        {
            new Emp { EmpNo = 1, EmpName = "Shiva", Job = "Manager", Salary = 3000 },
            new Emp { EmpNo = 2, EmpName = "Rama", Job = "Clerk", Salary = 800 },
            new Emp { EmpNo = 3, EmpName = "Krishna", Job = "Salesman", Salary = 1600 }
        };


        // GET: api/Emp
        [HttpGet]
        public ActionResult<IEnumerable<Emp>> GetEmpList()
        {
            if (_empList==null)
            {
                return NotFound();
            }
            return Ok(_empList);
        }

        // GET: api/Emp/5
        [HttpGet("{id}")]
        public ActionResult<Emp> GetEmp(int id)
        {
            var emp = _empList.FirstOrDefault(e => e.EmpNo == id);

            if (emp == null)
            {
                return NotFound(new { Message = $"Emp with Id{id} is not found" });
            }

            return Ok(emp);
        }

        // POST: api/Emp
        [HttpPost]
        public ActionResult PostEmp([FromBody]Emp emp)
        {
            if (emp == null)
            {
                return BadRequest(new { Message = "Employee object should not be empty or null" });
            }
            emp.EmpNo = _empList.Max(e => e.EmpNo) + 1;

            _empList.Add(emp);
            return CreatedAtAction("GetEmp", new { id = emp.EmpNo }, emp);
        }

        // PUT: api/Emp/5
        [HttpPut("{id}")]
        public ActionResult PutEmp(int id, [FromBody] Emp emp)
        {
            if (emp == null || emp.EmpNo != id)
            {
                return BadRequest( new { Message="Id mismatch between route and body" });
            }

            var existingEmp = _empList.FirstOrDefault(e => e.EmpNo == id);

            if (existingEmp == null)
            {
                return NotFound(new {Message= $"Emp with ID {id} is not found."});
            }
            _empList.Remove(existingEmp);
            // Update the existing emp data
            existingEmp.EmpName = emp.EmpName;
            existingEmp.Job = emp.Job;
            existingEmp.Salary = emp.Salary;

            _empList.Add(existingEmp);

            return Ok(new { Message = $"Emp with ID {id} data is updated." });
        }

        // DELETE: api/Emp/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmp(int id)
        {
            var emp = _empList.FirstOrDefault(e => e.EmpNo == id);

            if (emp == null)
            {
                return NotFound(new { Message = $"Emp with ID {id} is not found." });
            }

            _empList.Remove(emp);

            return Ok(new { Message = $"Emp with ID {id} is deleted." });
        }






    }
}
