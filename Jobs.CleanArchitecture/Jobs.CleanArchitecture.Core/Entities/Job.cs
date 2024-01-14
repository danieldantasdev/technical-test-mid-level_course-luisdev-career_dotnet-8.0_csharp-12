using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed internal class Job(string title, string description, string location, decimal salary) : BaseEntity
{
    [Column("title")]
    public string Title { get; private set; } = title;
    [Column("description")]
    public string Description { get; private set; } = description;
    [Column("location")]
    public string Location { get; private set; } = location;
    [Column("salary")]
    public decimal Salary { get; private set; } = salary;

    public void Update(string title, string description, string location, decimal salary)
    {
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
    }
}
