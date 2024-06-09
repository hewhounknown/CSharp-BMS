
using BMS.Models.Accounts;

namespace BMS.Mappings;

public static class AccountMapper
{
    public static AccountDTO ToDTO(this AccountEntity account)
    {
        return new AccountDTO
        {
            AccountNo = account.AccountNo,
            CustomerNo = account.CustomerNo,
            Balance = account.Balance,
            AccountType = account.AccountType,
            Password = account.Password,
        };
    }

    public static AccountEntity ToEntity(this AccountDTO dto)
    {
        return new AccountEntity
        {
            AccountNo = dto.AccountNo,
            CustomerNo = dto.CustomerNo,
            Balance = dto.Balance,
            AccountType = dto.AccountType,
            Password = dto.Password,
        };
    }
}
