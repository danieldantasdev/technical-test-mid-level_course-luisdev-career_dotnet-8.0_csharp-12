using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Subscribe(uint idUser, uint idjob, DateTime date) : BaseEntity
{
    [Column("id_user")]
    public uint IdUser { get; private set; } = idUser;
    [Column("id_job")]
    public uint IdJob { get; private set; } = idjob;
    [Column("date")]
    public DateTime Date { get; private set; } = date;
}
