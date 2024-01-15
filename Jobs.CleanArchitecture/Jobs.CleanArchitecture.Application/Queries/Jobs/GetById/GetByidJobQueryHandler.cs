using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetById;

public class GetByidJobQueryHandler : IRequestHandler<GetByidJobQueryInputModel, GetByidJobQueryViewModel>
{
    public async Task<GetByidJobQueryViewModel> Handle(GetByidJobQueryInputModel request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
