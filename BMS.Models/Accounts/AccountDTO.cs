
namespace BMS.Models.Accounts;

public class AccountDTO
{
    public string AccountNo { get; set; }
    public string CustomerNo { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public string Password { get; set; }
}
