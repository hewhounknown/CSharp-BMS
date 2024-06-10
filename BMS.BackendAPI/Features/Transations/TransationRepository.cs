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

    public TransationRepository()
    {
        _dapper = new DapperService(DBConnection.ConnectionBuilder.ConnectionString);
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

        int result = _dapper.Execute<TransationEntity>(TransationQuery.InsertQuery, transation);
        return result;
    }

    public List<TransationEntity> GetAllTransations()
    {
        List<TransationEntity> transations = _dapper.Query<TransationEntity>(TransationQuery.SelectAllQuery);
        return transations;
    }
}
