using Jobs.CleanArchitecture.Core.ViewModels;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetById;

public record GetByidJobQueryInputModel : IRequest<GenericViewModel<GetByidJobQueryViewModel>>
{
    public int Id { get; init; }

    public GetByidJobQueryInputModel()
    {
        Id = 0;
    }

    public static GetByidJobQueryInputModel Create(int id)
    {
        return new GetByidJobQueryInputModel
        {
            Id = id
        };
    }
}
