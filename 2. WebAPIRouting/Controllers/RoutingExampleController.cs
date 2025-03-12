using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPISampleProjectWIthVS2022.Controllers
{
    //[Route("api/[controller]")] --> to make the difference between attributed and convention based routing
    [ApiController]
    public class RoutingExampleController : ControllerBase
    {

        [HttpGet("{id}")]
        public string GetCourse(int id)
        {
            return "Hello from the RoutingExampleController!";
        }

        [Route("Course/All")]
        [HttpGet]
        public string GetAllCourseInformation()
        {
            return "1.Java, 2.NET 3.Python ";
        }

        [Route("Course/ById/{courseId}")]
        [HttpGet]
        public string GetCourseDetailsById(int courseId)
        {
           if(courseId == 1)
            {
                return "Java";
            }
            else if (courseId == 2)
            {
                return ".NET";
            }
            else if (courseId == 3)
            {
                return "Python";
            }
            else
            {
                return "Invalid Course Id";
            }
        }

    }
}
