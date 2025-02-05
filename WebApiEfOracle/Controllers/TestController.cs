using Microsoft.AspNetCore.Mvc;
using ModelOracleDemo;

namespace WebApiEfOracle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        public ModelOracleDemo.Task task { get; set; }
        public TestController()
        {
            task= new ModelOracleDemo.Task
            {
                Id = 1,
                Name = "Test", 
                Description = "Description",
            };
        }
        [HttpGet]
        public ActionResult<ModelOracleDemo.Task> Index()
        {
            return task;
        }
    }
}
