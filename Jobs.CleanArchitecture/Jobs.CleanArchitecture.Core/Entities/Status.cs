using Jobs.CleanArchitecture.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed internal class Status(StatusEnum name, string description) : BaseEntity
{
    [Column("name")]
    public StatusEnum Name { get; private set; } = name;
    [Column("description")]
    public string Description { get; private set; } = description;
}
