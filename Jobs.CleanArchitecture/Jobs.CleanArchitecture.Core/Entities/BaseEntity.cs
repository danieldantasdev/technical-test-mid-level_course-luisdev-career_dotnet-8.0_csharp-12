using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jobs.CleanArchitecture.Core.Entities;

internal abstract class BaseEntity()
{
    [Key]
    [Column("id")]
    public uint Id { get; private set; }
}
