using FuncionalTest.Api.GraphQL;
using FuncionalTest.Api.GraphQL.Queries;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FuncionalTest.Api.V2.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/graphql")]
    public class AccountController : ControllerBase
    {
        private readonly AccountSchema _schema;

        public AccountController(AccountSchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            Inputs inputs = query.Variables.ToInputs();

            var schema = _schema;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}