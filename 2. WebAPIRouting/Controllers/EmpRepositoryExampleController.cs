using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISampleProjectWIthVS2022.Models;
using WebAPISampleProjectWIthVS2022.Models.RepositoryPattren;

namespace WebAPISampleProjectWIthVS2022.Controllers
{
    [Route("api/[controller]")] //it will the base route for all the action methods in this controller and it is also called Route prefix
    [ApiController]
    public class EmpRepositoryExampleController : ControllerBase
    {
        private readonly IEmpRepository _empRepository;

        public EmpRepositoryExampleController(IEmpRepository empRepository)
        {
            _empRepository = empRepository;
        }

        //Retrive all emp
        [HttpGet("all-emps")]
        //[HttpGet("[action]")] --> Route token usage
        public IActionResult GetAllEmp()
        {
            var emps = _empRepository.GetAllEmp();
            return Ok(emps);
        }

        //Retrive emp by empno
        [HttpGet]
        [Route("{EmpNo:int:min(1000)}")] //Using route constrains eg => :int for only integer input for empno
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
        [HttpDelete("~/DeleteEmp/{EmpNo}")] //Placing the ~ will remove the route prefix
        public IActionResult DeleteEmp(int EmpNo)
        {
            if (!_empRepository.IsEmpExists(EmpNo))
            {
                return NotFound($"Emp with Id {EmpNo} is not found");
            }
            _empRepository.DeleteEmp(EmpNo);
            return Ok($"Emp with Id {EmpNo} is deleted successfully");
        }

        //Route data with single parameter

        //[HttpGet]
        //[Route("GetEmpDataById/{empid}")]
        [HttpGet("GetEmpDataById/{empid}")]
        public ActionResult<Emp> GetEmpDetailsByEmpId(int empid)
        {
            return _empRepository.GetEmpByEmpId(empid);
        }

        //Route data with multiple parameter
        //[HttpGet("GetEmpDataByEmpIdAndName/{empid}/{empname}")]
        [HttpGet("GetEmpDataByEmpIdAndName/EmpId/{empid:int:range(100,1000)}/EmpName/{empname:alpha:minlength(6):maxlength(10)}")]
        public ActionResult<Emp> GetEmpDetailsByEmpIdAndName(int empid, string empname)
        {
            return _empRepository.GetEmpByEmpIdOrName(empid,empname);
        }

        //Using query params

        [HttpGet("GetEmpDataById")]
        public ActionResult<Emp> GetEmpDetailsByEmpName([FromQuery]int empid)
        {
            return _empRepository.GetEmpByEmpIdOrName(empid, "empname");
        }

        [HttpGet("GetEmpDataByEmpIdAndNameUsingQueryParams")]
        public ActionResult<Emp> GetEmpDataByEmpIdAndNameUsingQueryParams([FromQuery] int empid, [FromQuery] string empname)
        {
            return _empRepository.GetEmpByEmpIdOrName(empid, empname);
        }

        //Using query strings with Model binding
        [HttpGet("InsertEmpDataUsingModelBinding")]
        public ActionResult<Emp> InsertEmpDataUsingModelBinding([FromQuery] Emp emp)
        {
             _empRepository.AddEmp(emp);

            return _empRepository.GetEmpByEmpId(emp.EmpNo);
        }

        //Reading Query string data from HttpContex

        [HttpGet("GetEmpDataUsingHttpContext")]
        public ActionResult<Emp> SearchEmp()
        {

            var empName = HttpContext.Request.Query["empName"].ToString();
            var empId = int.Parse(HttpContext.Request.Query["empid"].ToString());

            if (empName == "" || empName == null)
            {
                return BadRequest("EmpName is required");
            }
            if (empId == 0)
            {
                return BadRequest("EmpId is required");
            }

            return _empRepository.GetEmpByEmpIdOrName(empId, empName);
        }

        //Using Route data with Query strings 

        [HttpGet("GetTopEmp/{empid}")]
        public ActionResult<Emp> GetTopEmp([FromRoute]int empid, [FromQuery] string? empname)
        {
            return _empRepository.GetEmpByEmpIdOrName(empid, empname);
        }

        //Multiple URLs on single resource

        [HttpGet("GetAllEmp")]
        [HttpGet("AllEmployessData")]
        [HttpGet("GetEmployessData")]
        public ActionResult<IEnumerable<Emp>> GetEmpDataList()
        {
            return _empRepository.GetAllEmp().ToList();
        }

    }
}
