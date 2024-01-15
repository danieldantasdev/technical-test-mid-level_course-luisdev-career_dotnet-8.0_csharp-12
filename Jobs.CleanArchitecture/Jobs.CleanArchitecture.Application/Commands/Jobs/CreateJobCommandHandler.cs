using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs;

public class CreateJobCommandHandler(IJobRepository jobRepository) : IRequestHandler<CreateJobCommandInputModel, CreateJobCommandViewModel>
{
    private readonly IJobRepository _jobRepository = jobRepository;
    public async Task<CreateJobCommandViewModel> Handle(CreateJobCommandInputModel request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.Post(request.ToEntity(request));
        return new CreateJobCommandViewModel(job);
    }
}
