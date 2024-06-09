using BMS.Models.Accounts;
using BMS.Models.Customers;
using BMS.Shared;
using BMS.Shared.Services;
using BMS.WebAPI.Queries;


namespace BMS.WebAPI.Features.Customers;

public class CustomerRepository
{
    private readonly DapperService _dapper;

    public CustomerRepository()
    {
        _dapper = new DapperService(DBConnection.ConnectionBuilder.ConnectionString);
    }

    public int CreateCustomer(CustomerEntity customer)
    {
        int result = _dapper.Execute<CustomerEntity>(CustomerQuery.InsertQuery, customer);
        return result;
    }

    public List<CustomerEntity> GetCustomers()
    {
        List<CustomerEntity> customers = _dapper.Query<CustomerEntity>(CustomerQuery.SelectAllQuery);
        return customers;
    }

    public CustomerEntity GetCustomer(int id)
    {
        CustomerEntity customer = _dapper.QueryFirstOrDefault<CustomerEntity>(CustomerQuery.SelectQuery, new { CustomerId = id });
        return customer;
    }

    public int UpdateCustomer(int id, CustomerEntity customer)
    {
        customer.CustomerId = id;
        int result = _dapper.Execute<CustomerEntity>(CustomerQuery.UpdateQuery, customer);
        return result;
    }

    public int DeleteCustomer(int id)
    {
        int result = _dapper.Execute<CustomerEntity>(CustomerQuery.DeleteQuery, new { CustomerId = id });
        return result;
    }

    public CustomerWithAccounts GetCustomerWithAccount(string customerNo)
    {
        CustomerEntity customer = _dapper.QueryFirstOrDefault<CustomerEntity>
            (
                CustomerQuery.SelectQueryWithAccount, new { CustomerNo = customerNo }
            );

        List<AccountEntity> accounts = _dapper.Query<AccountEntity>
            (
                AccountQuery.SelectQueryWithCustomer, new { CustomerNo = customerNo }
            );

        CustomerWithAccounts response = new CustomerWithAccounts
        {
            Customer = customer,
            Accounts = accounts
        };

        return response;
    }
}
