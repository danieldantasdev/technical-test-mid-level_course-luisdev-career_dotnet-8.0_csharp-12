namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Update;

public record UpdateJobCommandViewModel
{
    public int Id { get; init; }

    public UpdateJobCommandViewModel(int id)
    {
        Id = id;
    }
}
