using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Models.Transations;

[Table("Tbl_Transation")]
public class TransationEntity
{
    [Key]
    public int TransationId { get; set; }
    public string TransationDate { get; set; }
    public decimal Amount { get; set; }
    public string TransationType { get; set; }
    public string? ReceiverNo { get; set; }
    public string AccountNo { get; set; }
}
