using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jobs.CleanArchitecture.Core.Entities;

public abstract class BaseEntity
{
    [Key]
    [Column("id")]
    public int Id { get; init; }

    public BaseEntity()
    {
        Id = 0;
    }
}
