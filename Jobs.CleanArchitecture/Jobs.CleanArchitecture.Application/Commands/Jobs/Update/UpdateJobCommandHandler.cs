using Jobs.CleanArchitecture.Application.Commands.Jobs.Update;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Create;

public class UpdateJobCommandHandler(IJobRepository jobRepository) : IRequestHandler<UpdateJobCommandInputModel, UpdateJobCommandViewModel>
{
    private readonly IJobRepository _jobRepository = jobRepository;
    public async Task<UpdateJobCommandViewModel> Handle(UpdateJobCommandInputModel request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.Update(request.ToEntity(request));
        return new UpdateJobCommandViewModel(job);
    }
}
