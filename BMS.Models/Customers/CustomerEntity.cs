using BMS.Models.Accounts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMS.Models.Customers;

[Table("Tbl_Customer")]
public class CustomerEntity
{
    [Key]
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string CustomerNo { get; set; }
}

public class CustomerWithAccounts
{
    public CustomerEntity Customer { get; set; }
    public List<AccountEntity> Accounts { get; set; }
}