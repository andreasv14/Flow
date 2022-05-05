namespace Flow.ResourceManager.WebAPI.Controllers
{
    public class CompaniesController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<CompanyDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCompanies()
        {
            return Ok(await Mediator.Send(new GetCompaniesQuery()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
        public async Task<ActionResult> AddCompany([FromBody] CreateCompanyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCompany([FromBody] UpdateCompanyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoveCompany([FromBody] RemoveCompanyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}