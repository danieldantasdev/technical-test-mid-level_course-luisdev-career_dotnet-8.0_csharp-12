using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Status : BaseEntity
{
    [Column("name")]
    public StatusEnum Name { get; private set; }
    [Column("description")]
    public string Description { get; private set; }

    public Status()
    {
        Name = StatusEnum.Active;
        Description = string.Empty;
    }

    public Status(StatusEnum name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Status Create(StatusEnum name, string description)
    {
        return new Status
        {
            Description = description,
            Name = name,
        };
    }

    public static Status Update(StatusEnum name, string description)
    {
        return new Status
        {
            Description = description,
            Name = name,
        };
    }
}
