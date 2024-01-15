using System.ComponentModel.DataAnnotations.Schema;

namespace Jobs.CleanArchitecture.Core.Entities;

sealed public class Subscribe(int idUser, int idjob, DateTime date) : BaseEntity
{
    [Column("id_user")]
    public int IdUser { get; private set; } = idUser;
    [Column("id_job")]
    public int IdJob { get; private set; } = idjob;
    [Column("date")]
    public DateTime Date { get; private set; } = date;
}
