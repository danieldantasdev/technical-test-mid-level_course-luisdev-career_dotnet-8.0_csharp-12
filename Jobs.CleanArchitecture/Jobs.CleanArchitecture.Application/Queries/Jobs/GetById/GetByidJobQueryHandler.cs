using Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;
using Jobs.CleanArchitecture.Core.Entities;
using Jobs.CleanArchitecture.Core.Repositories.Interfaces.Entities;
using Jobs.CleanArchitecture.Core.ViewModels;
using MediatR;
using System.Net;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetById;

public class GetByidJobQueryHandler(IJobRepository jobRepository) : IRequestHandler<GetByidJobQueryInputModel, GenericViewModel<GetByidJobQueryViewModel>>
{
    private readonly IJobRepository _jobRepository = jobRepository;

    public async Task<GenericViewModel<GetByidJobQueryViewModel>> Handle(GetByidJobQueryInputModel request, CancellationToken cancellationToken)
    {
        try
        {
            Job jobRepository = await _jobRepository.GetById(request.Id);


            if (jobRepository is null)
            {
                return GenericViewModel<GetByidJobQueryViewModel>.Create(HttpStatusCode.NotFound, "Id not found!", null);

            }
            else
            {
                GetByidJobQueryViewModel jobViewModel = GetByidJobQueryViewModel.ToViewModel(jobRepository);
                return GenericViewModel<GetByidJobQueryViewModel>.Create(HttpStatusCode.OK, "Job retrieved successfully", jobViewModel);

            }
        }
        catch (Exception ex)
        {

            return GenericViewModel<GetByidJobQueryViewModel>.Create(HttpStatusCode.InternalServerError, "Error retrieving job: " + ex.Message, null);
        }
    }
}
