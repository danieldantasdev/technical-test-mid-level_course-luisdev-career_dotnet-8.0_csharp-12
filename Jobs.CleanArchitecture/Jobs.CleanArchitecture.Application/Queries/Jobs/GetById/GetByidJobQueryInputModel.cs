using MediatR;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetById;

public record GetByidJobQueryInputModel : IRequest<GetByidJobQueryViewModel>
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
