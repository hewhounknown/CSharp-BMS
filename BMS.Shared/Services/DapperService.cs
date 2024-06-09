using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BMS.Shared.Services;

public class DapperService
{
    private readonly string _connectionString;

    public DapperService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<T> Query<T>(string query, object? parameter = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        List<T> list = db.Query<T>(query, parameter).ToList();
        return list;
    }

    public T QueryFirstOrDefault<T>(string query, object? parameter = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        T item = db.QueryFirstOrDefault<T>(query, parameter)!;
        return item;
    }

    public int Execute<T>(string sql, object? parameter = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        int result = db.Execute(sql, parameter);
        return result;
    }
}