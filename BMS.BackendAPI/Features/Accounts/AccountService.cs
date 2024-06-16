using BMS.Models.Accounts;
using BMS.Mappings;

namespace BMS.BackendAPI.Features.Accounts;

public class AccountService
{
    private readonly AccountRepository _accountRepo;

    public AccountService(AccountRepository accountRepo)
    {
        _accountRepo = accountRepo;
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

    public AccountDTO GetAccountByNo(string no)
    {
        AccountEntity account = _accountRepo.GetAccountByNo(no);
        if (account == null) return null;

        return account.ToDTO();
    }
}
