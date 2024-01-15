using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Job : BaseEntity
{
    [Column("title")]
    public string Title { get; private init; }
    [Column("description")]
    public string Description { get; private init; }
    [Column("location")]
    public string Location { get; private init; }
    [Column("salary")]
    public decimal Salary { get; private init; }
    [Column("id_status")]
    public int IdStatus { get; private init; }

    public Job()
    {
        Title = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Salary = decimal.Zero;
        IdStatus = 0;
    }

    public Job(string title, string description, string location, decimal salary, int idStatus)
    {
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
        IdStatus = idStatus;
    }

    public static Job Create(string title, string description, string location, decimal salary, int idStatus)
    {
        return new Job
        {
            Title = title,
            Description = description,
            Location = location,
            Salary = salary,
            IdStatus = idStatus
        };
    }

    public static Job Update(string title, string description, string location, decimal salary, int idStatus)
    {
        return new Job
        {
            Title = title,
            Description = description,
            Location = location,
            Salary = salary,
            IdStatus = idStatus
        };
    }
}
