using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Log : BaseEntity
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

    public Log(TableEnum table, string createdBy, DateTime createdOn, string updateBy, DateTime updateOn, string deleteBy, DateTime deleteOn)
    {
        Table = table;
        CreatedBy = createdBy;
        CreatedOn = createdOn;
        UpdateBy = updateBy;
        UpdateOn = updateOn;
        DeleteBy = deleteBy;
        DeleteOn = deleteOn;
    }

    public static Log Create(string createdBy, DateTime createdOn)
    {
        return new Log
        {
            CreatedBy = createdBy,
            CreatedOn = createdOn
        };
    }

    public static Log Update(string? updateBy, DateTime? updateOn)
    {
        return new Log
        {
            UpdateBy = updateBy,
            UpdateOn = updateOn
        };
    }

    public static Log Delete(string? deleteBy, DateTime? deleteOn)
    {
        return new Log
        {
            DeleteBy = deleteBy,
            DeleteOn = deleteOn
        };
    }
}
