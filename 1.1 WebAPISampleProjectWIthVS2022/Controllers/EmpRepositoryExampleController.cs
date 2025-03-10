using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISampleProjectWIthVS2022.Models;
using WebAPISampleProjectWIthVS2022.Models.RepositoryPattren;

namespace WebAPISampleProjectWIthVS2022.Controllers
{
    [Route("api/[controller]")] //it will the base route for all the action methods in this controller
    [ApiController]
    public class EmpRepositoryExampleController : ControllerBase
    {
        private readonly IEmpRepository _empRepository;

        public EmpRepositoryExampleController(IEmpRepository empRepository)
        {
            _empRepository = empRepository;
        }

        //Retrive all emp
        [HttpGet]
        public IActionResult GetAllEmp()
        {
            var emps = _empRepository.GetAllEmp();
            return Ok(emps);
        }

        //Retrive emp by empno
        [HttpGet]
        [Route("{EmpNo}")]
        public IActionResult GetEmpByEmpNo(int EmpNo)
        {
            var emp = _empRepository.GetEmpByEmpId(EmpNo);
            if (emp == null)
            {
                return NotFound($"Emp with Id {EmpNo} is not found");
            }
            return Ok(emp);
        }

        //Add new emp
        [HttpPost]
        public IActionResult AddEmp([FromBody] Emp emp)
        {
            if (emp == null)
            {
                return BadRequest("Emp object should not be null");
            }
            _empRepository.AddEmp(emp);
            return CreatedAtAction("GetEmpByEmpNo", new { EmpNo = emp.EmpNo }, emp);
        }

        //Update emp
        [HttpPut]
        public IActionResult UpdateEmp([FromBody] Emp emp)
        {
            if (emp == null)
            {
                return BadRequest("Emp object should not be null");
            }
            _empRepository.UpdateEmp(emp);
            return Ok($"Emp with Id {emp.EmpNo} is updated successfully");
        }

        //Delete emp
        [HttpDelete]
        [Route("{EmpNo}")]
        public IActionResult DeleteEmp(int EmpNo)
        {
            if (!_empRepository.IsEmpExists(EmpNo))
            {
                return NotFound($"Emp with Id {EmpNo} is not found");
            }
            _empRepository.DeleteEmp(EmpNo);
            return Ok($"Emp with Id {EmpNo} is deleted successfully");
        }



    }
}
