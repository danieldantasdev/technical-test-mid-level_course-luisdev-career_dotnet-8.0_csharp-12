using Jobs.CleanArchitecture.Core.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Create;

public record CreateJobCommandInputModel : IRequest<CreateJobCommandViewModel>
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string Location { get; init; }
    public decimal Salary { get; init; }
    public int IdStatus { get; init; }

    public CreateJobCommandInputModel()
    {
        Title = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Salary = decimal.Zero;
        IdStatus = int.MinValue;
    }

    public CreateJobCommandInputModel(string title, string description, string location, decimal salary, int idStatus)
    {
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
        IdStatus = idStatus;
    }

    public static Job ToEntity(CreateJobCommandInputModel createJobCommandInputModel)
    {
        return Job.Create(
         createJobCommandInputModel.Title,
         createJobCommandInputModel.Description,
         createJobCommandInputModel.Location,
         createJobCommandInputModel.Salary,
         createJobCommandInputModel.IdStatus
         );
    }
}
