using BMS.Models.Accounts;
using BMS.Shared;
using BMS.Shared.Services;
using BMS.WebAPI.Queries;

namespace BMS.BackendAPI.Features.Accounts;

public class AccountRepository
{
    private readonly DapperService _dapper;

    public AccountRepository(DapperService dapper)
    {
        _dapper = dapper;
    }

    public int CreateAccount(AccountEntity account)
    {
        int result = _dapper.Execute<AccountEntity>(AccountQuery.InsertQuery, account);
        return result;
    }

    public List<AccountEntity> GetAllAccounts()
    {
        List<AccountEntity> accounts = _dapper.Query<AccountEntity>(AccountQuery.SelectAllQuery);
        return accounts;
    }

    public AccountEntity GetAccount(int id)
    {
        AccountEntity account = _dapper.QueryFirstOrDefault<AccountEntity>(AccountQuery.SelectQuery, new { AccountId = id });
        return account;
    }

    public int UpdateAccount(int id, AccountEntity account)
    {
        account.AccountId = id;
        int result = _dapper.Execute<AccountEntity>(AccountQuery.UpdateQuery, account);
        return result;
    }

    public int DeleteAccount(int id)
    {
        int result = _dapper.Execute<AccountEntity>(AccountQuery.DeleteQuery, new { AccountId = id });
        return result;
    }

    public AccountEntity GetAccountByNo(string no)
    {
        AccountEntity account = _dapper.QueryFirstOrDefault<AccountEntity>(AccountQuery.SelectQueryByNo, new { AccountNo = no });
        return account;
    }
}
