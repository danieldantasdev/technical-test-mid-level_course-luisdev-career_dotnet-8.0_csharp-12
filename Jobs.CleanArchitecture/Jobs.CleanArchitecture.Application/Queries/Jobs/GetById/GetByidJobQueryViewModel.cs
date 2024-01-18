using Jobs.CleanArchitecture.Core.Entities;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetById;

public record GetByidJobQueryViewModel
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string Location { get; init; }
    public decimal Salary { get; init; }
    public int IdStatus { get; init; }

    public GetByidJobQueryViewModel()
    {
        Id = 0;
        Title = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Salary = 0;
        IdStatus = 0;
    }

    public static GetByidJobQueryViewModel Create(int id, string title, string description, string location, decimal salary, int idStatus)
    {
        return new GetByidJobQueryViewModel
        {
            Id = id,
            Title = title,
            Description = description,
            Location = location,
            Salary = salary,
            IdStatus = idStatus
        };
    }

    public static GetByidJobQueryViewModel ToViewModel(Job job)
    {
        return Create(
               job.Id,
               job.Title,
               job.Description,
               job.Location,
               job.Salary,
               job.IdStatus
               );
    }
}
