using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Delete;

public record DeleteJobCommandInputModel : IRequest<DeleteJobCommandViewModel>
{
    public int Id { get; init; }

    public DeleteJobCommandInputModel(int id)
    {
        Id = id;
    }
}
