using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Delete;

public class DeleteJobCommandHandler(IJobRepository jobRepository) : IRequestHandler<DeleteJobCommandInputModel, DeleteJobCommandViewModel>
{
    private readonly IJobRepository _jobRepository = jobRepository;
    public async Task<DeleteJobCommandViewModel> Handle(DeleteJobCommandInputModel request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.Delete(request.Id);
        return new DeleteJobCommandViewModel(job);
    }
}
