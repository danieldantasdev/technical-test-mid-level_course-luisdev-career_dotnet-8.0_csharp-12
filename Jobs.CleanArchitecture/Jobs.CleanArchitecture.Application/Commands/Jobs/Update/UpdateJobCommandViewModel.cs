namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Update;

public record UpdateJobCommandViewModel
{
    public int Id { get; init; }

    public UpdateJobCommandViewModel()
    {
        Id = 0;
    }

    public UpdateJobCommandViewModel(int id)
    {
        Id = id;
    }

    public static UpdateJobCommandViewModel Create(int id)
    {
        return new UpdateJobCommandViewModel
        {
            Id = id
        };
    }

    public static UpdateJobCommandViewModel ToViewModel(int id)
    {
        return Create(id);
    }
}
