using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed internal class Log : BaseEntity
{
    [Column("table")]
    public TableEnum Table { get; private set; }
    [Column("created_by")]
    public string CreatedBy { get; private set; }
    [Column("created_on")]
    public DateTime CreatedOn { get; private set; }
    [Column("update_by")]
    public string? UpdateBy { get; private set; }
    [Column("update_on")]
    public DateTime? UpdateOn { get; private set; }
    [Column("delete_by")]
    public string? DeleteBy { get; private set; }
    [Column("delete_on")]
    public DateTime? DeleteOn { get; private set; }

    public Log()
    {
        Table = TableEnum.Empthy;
        CreatedBy = string.Empty;
        CreatedOn = DateTime.Now;
        UpdateBy = null;
        UpdateOn = null;
        DeleteBy = null;
        DeleteOn = null;
    }

    public void Create(string createdBy, DateTime createdOn)
    {
        CreatedBy = createdBy;
        CreatedOn = createdOn;
    }

    public void Update(string? updateBy, DateTime? updateOn)
    {
        UpdateBy = updateBy;
        UpdateOn = updateOn;
    }

    public void Delete(string? deleteBy, DateTime? deleteOn)
    {
        DeleteBy = deleteBy;
        DeleteOn = deleteOn;
    }
}
