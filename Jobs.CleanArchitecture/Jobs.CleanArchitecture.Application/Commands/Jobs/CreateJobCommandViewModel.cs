namespace Jobs.CleanArchitecture.Application.Commands.Jobs;

public record CreateJobCommandViewModel
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string Location { get; init; }
    public decimal Salary { get; init; }
    public int IdStatus { get; init; }

    public CreateJobCommandViewModel(int id)
    {
        Id = id;
        Title = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Salary = decimal.Zero;
        IdStatus = int.MinValue;
    }
}
