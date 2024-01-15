using Jobs.CleanArchitecture.Application.Commands.Jobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace Jobs.CleanArchitecture.Api.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post(CreateJobCommandInputModel createJobCommandInputModel)
        {
            var createdJobCommandViewModel = await _mediator.Send(createJobCommandInputModel);

            return CreatedAtAction(nameof(GetById), new { id = createdJobCommandViewModel.Id }, createdJobCommandViewModel);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<AnyType> jobs = [];
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var job = "";

            if (job is null)
            {
                return NotFound();
            }

            return Ok(job);
        }
    }
}
