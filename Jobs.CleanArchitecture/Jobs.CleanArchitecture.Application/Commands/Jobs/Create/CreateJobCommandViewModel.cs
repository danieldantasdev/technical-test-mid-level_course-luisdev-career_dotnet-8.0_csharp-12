namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Create;

public record CreateJobCommandViewModel
{
    public int Id { get; init; }

    public CreateJobCommandViewModel()
    {
        Id = 0;
    }

    public CreateJobCommandViewModel(int id)
    {
        Id = id;
    }

    public static CreateJobCommandViewModel Create(int id)
    {
        return new CreateJobCommandViewModel
        {
            Id = id
        };
    }

    public static CreateJobCommandViewModel ToViewModel(int id)
    {
        return Create(id);
    }
}
