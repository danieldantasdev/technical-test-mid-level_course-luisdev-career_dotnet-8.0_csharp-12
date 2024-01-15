namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Delete;

public record DeleteJobCommandViewModel
{
    public int Id { get; init; }

    public DeleteJobCommandViewModel(int id)
    {
        Id = id;
    }
}
