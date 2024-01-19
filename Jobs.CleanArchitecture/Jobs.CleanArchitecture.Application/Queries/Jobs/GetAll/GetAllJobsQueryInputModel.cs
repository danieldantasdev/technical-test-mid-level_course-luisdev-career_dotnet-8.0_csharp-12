using Jobs.CleanArchitecture.Core.ViewModels;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;

public record GetAllJobsQueryInputModel : IRequest<GenericViewModel<List<GetAllJobsQueryViewModel>>>
{
   
}
