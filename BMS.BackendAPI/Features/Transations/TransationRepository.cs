using BMS.BackendAPI.Queries;
using BMS.Models.Accounts;
using BMS.Models.Transations;
using BMS.Shared;
using BMS.Shared.Services;
using BMS.WebAPI.Queries;

namespace BMS.BackendAPI.Features.Transations;

public class TransationRepository
{
    private readonly DapperService _dapper;

    public TransationRepository(DapperService dapper)
    {
        _dapper = dapper;
    }

    public int AddTransation(TransationEntity transation, decimal balance, string accountNo, string password)
    {

        int updateResult = _dapper.Execute<AccountEntity>
            (
            AccountQuery.UpdateBalanceQuery, new
            {
                Balance = balance,
                AccountNo = accountNo,
                Password = password
            }
            );
        if (updateResult == 0) return 0;

        int transationResult = _dapper.Execute<TransationEntity>(TransationQuery.InsertQuery, transation);

        return transationResult;
    }

    public int UpdateReceiverAccount(string accountNo, decimal amount)
    {
        return _dapper.Execute<AccountEntity>(AccountQuery.ReceiveAmountQuery, new
        {
            AccountNo = accountNo,
            Balance = amount
        });
    }
    public List<TransationEntity> GetAllTransations()
    {
        List<TransationEntity> transations = _dapper.Query<TransationEntity>(TransationQuery.SelectAllQuery);
        return transations;
    }

    public TransationEntity GetTransation(int id)
    {
        TransationEntity transation = _dapper.QueryFirstOrDefault<TransationEntity>(TransationQuery.SelectQuery, new
        { TransationId = id });
        return transation;
    }

    public List<TransationEntity> GetTransationsByAccNo (string accNo)
    {
        List<TransationEntity> transations = _dapper.Query<TransationEntity>(TransationQuery.SelectQueryByAccNo, new
        { AccNo = accNo });
        return transations;
    }
}
