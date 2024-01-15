using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetById;

public record GetByidJobQueryInputModel : IRequest<GetByidJobQueryViewModel>
{
   
}
