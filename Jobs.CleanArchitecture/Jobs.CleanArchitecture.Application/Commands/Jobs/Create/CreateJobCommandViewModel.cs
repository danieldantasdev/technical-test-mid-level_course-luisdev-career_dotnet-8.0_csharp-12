namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Create;

public record CreateJobCommandViewModel
{
    public int Id { get; init; }

    public CreateJobCommandViewModel(int id)
    {
        Id = id;
    }
}
