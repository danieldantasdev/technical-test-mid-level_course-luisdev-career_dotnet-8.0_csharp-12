using Jobs.CleanArchitecture.Core.Entities;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetById;

public class GetByidJobQueryHandler(IJobRepository jobRepository) : IRequestHandler<GetByidJobQueryInputModel, GetByidJobQueryViewModel>
{
    private readonly IJobRepository _jobRepository = jobRepository;

    public async Task<GetByidJobQueryViewModel> Handle(GetByidJobQueryInputModel request, CancellationToken cancellationToken)
    {
        Job job = await _jobRepository.GetById(request.Id);

        return GetByidJobQueryViewModel.Create(job.Id, job.Title, job.Description, job.Location, job.Salary, job.IdStatus);
    }
}
