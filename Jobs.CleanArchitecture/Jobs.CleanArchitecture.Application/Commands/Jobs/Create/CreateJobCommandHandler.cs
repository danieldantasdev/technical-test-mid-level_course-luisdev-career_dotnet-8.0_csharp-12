using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.ViewModels;
using MediatR;
using System.Net;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Create;

public class CreateJobCommandHandler(IJobRepository jobRepository) : IRequestHandler<CreateJobCommandInputModel, GenericViewModel<CreateJobCommandViewModel>>
{
    private readonly IJobRepository _jobRepository = jobRepository;
    public async Task<GenericViewModel<CreateJobCommandViewModel>> Handle(CreateJobCommandInputModel request, CancellationToken cancellationToken)
    {
        try
        {
            int jobRepository = await _jobRepository.Post(CreateJobCommandInputModel.ToEntity(request));
            CreateJobCommandViewModel jobViewModel = CreateJobCommandViewModel.ToViewModel(jobRepository);

            if (jobRepository is 1)
            {
                return GenericViewModel<CreateJobCommandViewModel>.Create(HttpStatusCode.Created, "Jobs created successfully", null);
            }
            else if (jobRepository is 0)
            {
                return GenericViewModel<CreateJobCommandViewModel>.Create(HttpStatusCode.InternalServerError, "Error creating job", null);
            } else
            {
                return GenericViewModel<CreateJobCommandViewModel>.Create(HttpStatusCode.InternalServerError, "Error creating job", null);
            }
        }
        catch (Exception ex)
        {
            return GenericViewModel<CreateJobCommandViewModel>.Create(HttpStatusCode.InternalServerError, "Error creating job: " + ex.Message, null);
        }
    }
}
