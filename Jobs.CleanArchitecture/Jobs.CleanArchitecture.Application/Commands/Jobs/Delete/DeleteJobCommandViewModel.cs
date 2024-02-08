namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Delete;

public record DeleteJobCommandViewModel
{
    public int Id { get; init; }

    public DeleteJobCommandViewModel()
    {
        Id = 0;
    }

    public DeleteJobCommandViewModel(int id)
    {
        Id = id;
    }

    public static DeleteJobCommandViewModel Create(int id)
    {
        return new DeleteJobCommandViewModel
        {
            Id = id
        };
    }

    public static DeleteJobCommandViewModel ToViewModel(int id)
    {
        return Create(id);
    }
}
