using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Models.Accounts;

[Table("Tbl_Account")]
public class AccountEntity
{
    [Key]
    public int AccountId { get; set; }
    public string AccountNo { get; set; }
    public string CustomerNo { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public string Password { get; set; }

}
