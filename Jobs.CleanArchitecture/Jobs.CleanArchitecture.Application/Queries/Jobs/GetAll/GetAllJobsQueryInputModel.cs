using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;

public record GetAllJobsQueryInputModel : IRequest<List<GetAllJobsQueryViewModel>>
{
   
}
