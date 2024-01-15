using Jobs.CleanArchitecture.Core.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs;

public record CreateJobCommandInputModel : IRequest<CreateJobCommandViewModel>
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string Location { get; init; }
    public decimal Salary { get; init; }
    public int IdStatus { get; init; }

    public CreateJobCommandInputModel(string title, string description, string location, decimal salary, int idStatus)
    {
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
        IdStatus = idStatus;
    }

    public Job ToEntity(CreateJobCommandInputModel createJobCommandInputModel)
    {
        return new Job
        {
            Description = createJobCommandInputModel.Description,
            Location = createJobCommandInputModel.Location,
            Salary = createJobCommandInputModel.Salary,
            Title = createJobCommandInputModel.Title,
            IdStatus = createJobCommandInputModel.IdStatus
        };
    }
}
