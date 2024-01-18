using Jobs.CleanArchitecture.Application.Commands.Jobs.Create;
using Jobs.CleanArchitecture.Application.Commands.Jobs.Delete;
using Jobs.CleanArchitecture.Application.Commands.Jobs.Update;
using Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;
using Jobs.CleanArchitecture.Application.Query.Jobs.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.CleanArchitecture.Api.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateJobCommandInputModel inputModel)
        {
            var createdJobCommandViewModel = await _mediator.Send(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = createdJobCommandViewModel.Id }, createdJobCommandViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _mediator.Send(new GetAllJobsQueryInputModel());
            return Ok(jobs);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByidJobQueryInputModel inputModel)
        {
            GetByidJobQueryInputModel getByidJobQueryInputModel = GetByidJobQueryInputModel.Create(inputModel.Id);

            var job = await _mediator.Send(getByidJobQueryInputModel);
           
            if (job is null)
            {
                return NotFound();
            }
           
            return Ok(job);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateJobCommandInputModel inputModel)
        {
            UpdateJobCommandInputModel updateJobCommandInputModel = UpdateJobCommandInputModel
                .Create
                (
                    id,
                    inputModel.Title,
                    inputModel.Description,
                    inputModel.Location,
                    inputModel.Salary,
                    inputModel.IdStatus
                );

            var result = await _mediator.Send(updateJobCommandInputModel);

            if (result is null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteJobCommandInputModel inputModel)
        {
            var result = await _mediator.Send(inputModel);

            if (result is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
