//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Grocery_Store.Models;
//using Grocery_Store.Entity;

//namespace Grocery_Store.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ValuesController : ControllerBase
//    {
//        private ILoggerManager _logger;

//        public ValuesController(ILoggerManager logger)
//        {
//            _logger = logger;
//        }


//    }
//    [HttpGet]
//    public IActionResult Get()
//    {
//        List<Product> prodList = new List<Product>();
//        _logger.LogInfo("Fetching all the Products from the storage");

//        var product = Entity.Product(); //simulation for the data base access

//        throw new Exception("Exception while fetching all the students from the storage.");

//        _logger.LogInfo($"Returning {students.Count} students.");

//        return Ok(students);
//    }
//}
