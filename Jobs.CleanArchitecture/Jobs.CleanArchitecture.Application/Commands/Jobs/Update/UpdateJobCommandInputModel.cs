using Jobs.CleanArchitecture.Core.Entities;
using MediatR;

namespace Jobs.CleanArchitecture.Application.Commands.Jobs.Update;

public record UpdateJobCommandInputModel : IRequest<UpdateJobCommandViewModel>
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string Location { get; init; }
    public decimal Salary { get; init; }
    public int IdStatus { get; init; }

    public UpdateJobCommandInputModel()
    {
        Id = 0;
        Title = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Salary = 0;
        IdStatus = 0;
    }

    public UpdateJobCommandInputModel(int id, string title, string description, string location, decimal salary, int idStatus)
    {
        Id = id;
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
        IdStatus = idStatus;
    }

    public static UpdateJobCommandInputModel Create(int id, string title, string description, string location, decimal salary, int idStatus)
    {
        return new UpdateJobCommandInputModel
        {
            Id = id,
            Title = title,
            Description = description,
            Location = location,
            Salary = salary,
            IdStatus = idStatus
        };
    }

    public static Job ToEntity(UpdateJobCommandInputModel updateJobCommandInputModel)
    {
        return Job.Update(
        updateJobCommandInputModel.Title,
        updateJobCommandInputModel.Description,
        updateJobCommandInputModel.Location,
        updateJobCommandInputModel.Salary,
        updateJobCommandInputModel.IdStatus
        );
    }
}
