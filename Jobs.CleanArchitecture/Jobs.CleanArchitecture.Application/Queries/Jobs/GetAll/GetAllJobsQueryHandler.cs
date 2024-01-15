using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;

public class GetAllJobsQueryHandler(IJobRepository jobRepository) : IRequestHandler<GetAllJobsQueryInputModel, List<GetAllJobsQueryViewModel>>
{
    private readonly IJobRepository _jobRepository = jobRepository;

    public async Task<List<GetAllJobsQueryViewModel>> Handle(GetAllJobsQueryInputModel request, CancellationToken cancellationToken)
    {
        List<GetAllJobsQueryViewModel> jobs = [];

        var jobsRepository = await _jobRepository.GetAll();
        foreach (var job in jobsRepository)
        {
            jobs.Add(GetAllJobsQueryViewModel.ToViewModel(job));

        }

        return jobs;

    }
}
