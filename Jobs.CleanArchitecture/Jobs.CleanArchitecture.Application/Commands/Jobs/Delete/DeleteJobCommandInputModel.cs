using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Delete;

public record DeleteJobCommandInputModel : IRequest<DeleteJobCommandViewModel>
{
    public int Id { get; init; }

    public DeleteJobCommandInputModel()
    {
        Id = 0;
    }

    public DeleteJobCommandInputModel(int id)
    {
        Id = id;
    }

    public static DeleteJobCommandInputModel Create(int id)
    {
        return new DeleteJobCommandInputModel
        {
            Id = id
        };
    }
}
