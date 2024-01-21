using Jobs.CleanArchitecture.Application.Commands.Jobs.Create;
using Jobs.CleanArchitecture.Application.Commands.Jobs.Delete;
using Jobs.CleanArchitecture.Application.Commands.Jobs.Update;
using Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;
using Jobs.CleanArchitecture.Application.Query.Jobs.GetById;
using Jobs.CleanArchitecture.Core.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            GenericViewModel<CreateJobCommandViewModel> viewModel = await _mediator.Send(inputModel);

            switch (viewModel.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };

                case HttpStatusCode.Created:
                    {
                        return StatusCode((int)HttpStatusCode.Created, viewModel);
                    };

                default:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GenericViewModel<List<GetAllJobsQueryViewModel>> viewModel = await _mediator.Send(new GetAllJobsQueryInputModel());

            switch (viewModel.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };

                case HttpStatusCode.OK:
                    {
                        return StatusCode((int)HttpStatusCode.OK, viewModel);
                    };

                default:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByidJobQueryInputModel inputModel)

        {
            GetByidJobQueryInputModel getByidJobQueryInputModel = GetByidJobQueryInputModel.Create(inputModel.Id);
            GenericViewModel<GetByidJobQueryViewModel> viewModel = await _mediator.Send(getByidJobQueryInputModel);

            switch (viewModel.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    {

                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };

                case HttpStatusCode.OK:
                    {

                        return StatusCode((int)HttpStatusCode.OK, viewModel);
                    };
                case HttpStatusCode.NotFound:
                    {

                        return StatusCode((int)HttpStatusCode.NotFound, viewModel);
                    };
                default:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateJobCommandInputModel inputModel)
        {
            UpdateJobCommandInputModel updateJobCommandInputModel = UpdateJobCommandInputModel.Create(id, inputModel.Title, inputModel.Description, inputModel.Location, inputModel.Salary, inputModel.IdStatus);
            GenericViewModel<UpdateJobCommandViewModel> viewModel = await _mediator.Send(updateJobCommandInputModel);

            switch (viewModel.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };

                case HttpStatusCode.NoContent:
                    {
                        return StatusCode((int)HttpStatusCode.NoContent, viewModel);
                    };
                case HttpStatusCode.NotFound:
                    {
                        return StatusCode((int)HttpStatusCode.NotFound, viewModel);
                    };
                default:
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, viewModel);
                    };
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteJobCommandInputModel inputModel)
        {
            DeleteJobCommandInputModel deleteJobCommandInputModel = DeleteJobCommandInputModel.Create(inputModel.Id);

            var result = await _mediator.Send(deleteJobCommandInputModel);

            if (result is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
