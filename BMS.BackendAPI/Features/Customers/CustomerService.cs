using BMS.Models.Customers;
using BMS.Mappings;
using BMS.Models.Accounts;

namespace BMS.WebAPI.Features.Customers;

public class CustomerService
{
    private readonly CustomerRepository _customerRepo;

    public CustomerService(CustomerRepository customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public int CreateCustomer(CustomerDTO dto)
    {
        return _customerRepo.CreateCustomer(dto.ToEntity());
    }

    public List<CustomerDTO> GetCustomers()
    {
        List<CustomerEntity> list = _customerRepo.GetCustomers();
        List<CustomerDTO> customerDTOs = list.Select(x => x.ToDTO()).ToList();
        return customerDTOs;
    }

    public CustomerDTO GetCustomer(int id)
    {
        CustomerEntity customer = _customerRepo.GetCustomer(id);
        if (customer == null) return null;

        return customer.ToDTO();
    }

    public int UpdateCustomer(int id, CustomerDTO customer)
    {
        return _customerRepo.UpdateCustomer(id, customer.ToEntity());
    }

    public int DeleteCustomer(int id)
    {
        return _customerRepo.DeleteCustomer(id);
    }

    public CusWithAccsDTO GetCustomerWithAccounts(string customerNo)
    {
        CustomerWithAccounts tmp = _customerRepo.GetCustomerWithAccount(customerNo);
        if (tmp == null) return null;

        CustomerDTO cus = tmp.Customer.ToDTO();
        List<AccountDTO> accs = tmp.Accounts.Select(x => x.ToDTO()).ToList();

        CusWithAccsDTO cusWithAccsDTO = new CusWithAccsDTO
        {
            CusDTO = cus,
            AccsDTO = accs
        };
        return cusWithAccsDTO;
    }
}
