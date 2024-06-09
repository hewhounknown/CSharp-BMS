using BMS.BackendAPI.Features.Accounts;
using BMS.Models.Accounts;
using BMS.Mappings;

namespace BMS.WebAPI.Features.Accounts;

public class AccountService
{
    private readonly AccountRepository _accountRepo;

    public AccountService()
    {
        _accountRepo = new AccountRepository();
    }

    public int CreateAccount(AccountDTO dto)
    {
        return _accountRepo.CreateAccount(dto.ToEntity());
    }

    public List<AccountDTO> GetAccounts()
    {
        List<AccountEntity> accounts = _accountRepo.GetAllAccounts();
        List<AccountDTO> accountDTOs = accounts.Select(x => x.ToDTO()).ToList();
        return accountDTOs;
    }

    public AccountDTO GetAccount(int id)
    {
        AccountEntity account = _accountRepo.GetAccount(id);
        if (account == null) return null;

        return account.ToDTO();
    }

    public int UpdateAccount(int id, AccountDTO dto)
    {
        return _accountRepo.UpdateAccount(id, dto.ToEntity());
    }

    public int DeleteAccount(int id)
    {
        return _accountRepo.DeleteAccount(id);
    }
}
