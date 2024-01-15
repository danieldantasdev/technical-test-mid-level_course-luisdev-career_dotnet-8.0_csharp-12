using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Job : BaseEntity
{
    [Column("title")]
    public string Title { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("location")]
    public string Location { get; set; }
    [Column("salary")]
    public decimal Salary { get; set; }
    [Column("id_status")]
    public int IdStatus { get; set; }

    public Job()
    {
        
    }

    public Job(string title, string description, string location, decimal salary, int idStatus)
    {
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
        IdStatus = idStatus;
    }

    public void Update(string title, string description, string location, decimal salary, int idStatus)
    {
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
        IdStatus = idStatus;
    }
}
