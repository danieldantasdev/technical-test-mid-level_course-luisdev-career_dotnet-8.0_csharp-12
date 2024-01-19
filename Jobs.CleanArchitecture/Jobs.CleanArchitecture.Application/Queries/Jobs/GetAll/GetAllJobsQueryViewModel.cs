using Jobs.CleanArchitecture.Core.Entities;

namespace Jobs.CleanArchitecture.Application.Query.Jobs.GetAll;

public class GetAllJobsQueryViewModel
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string Location { get; init; }
    public decimal Salary { get; init; }
    public int IdStatus { get; init; }

    public GetAllJobsQueryViewModel()
    {
        Id = 0;
        Title = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Salary = 0;
        IdStatus = 0;
    }

    public static GetAllJobsQueryViewModel Create(int id, string title, string description, string location, decimal salary, int idStatus)
    {
        return new GetAllJobsQueryViewModel
        {
            Id = id,
            Title = title,
            Description = description,
            Location = location,
            Salary = salary,
            IdStatus = idStatus
        };
    }

    public static GetAllJobsQueryViewModel ToViewModel(Job job)
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
