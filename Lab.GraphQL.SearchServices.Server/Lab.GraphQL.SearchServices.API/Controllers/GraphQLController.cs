using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.GraphQL.SearchServices.App;
using Microsoft.AspNetCore.Mvc;

namespace Lab.GraphQL.SearchServices.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly GraphQueryExecuter _executer;

        public GraphQLController(GraphQueryExecuter exec)
        {
            _executer = exec;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await _executer.ExecuteQuery(query);

            var hasAnySuccess = result.Errors == null || result.Errors?.Count == 0;

            if (!hasAnySuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
