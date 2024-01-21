using Jobs.CleanArchitecture.Core.Entities;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.ViewModels;
using MediatR;
using System.Net;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;

public class GetAllJobsQueryHandler(IJobRepository jobRepository) : IRequestHandler<GetAllJobsQueryInputModel, GenericViewModel<List<GetAllJobsQueryViewModel>>>
{
    private readonly IJobRepository _jobRepository = jobRepository;

    public async Task<GenericViewModel<List<GetAllJobsQueryViewModel>>> Handle(GetAllJobsQueryInputModel request, CancellationToken cancellationToken)
    {
        try
        {
            List<GetAllJobsQueryViewModel> jobsViewModel = [];

            List<Job> jobsRepository = await _jobRepository.GetAll();

            foreach (var jobRepository in jobsRepository)
            {
                jobsViewModel.Add(GetAllJobsQueryViewModel.ToViewModel(jobRepository));
            }    

            return GenericViewModel<List<GetAllJobsQueryViewModel>>.Create(HttpStatusCode.OK, "Jobs retrieved successfully", jobsViewModel);
        }
        catch (Exception ex)
        {
            return GenericViewModel<List<GetAllJobsQueryViewModel>>.Create(HttpStatusCode.InternalServerError, "Error retrieving jobs: " + ex.Message, null);
        }

    }
}
