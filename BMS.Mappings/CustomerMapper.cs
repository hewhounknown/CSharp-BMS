using BMS.Models.Customers;

namespace BMS.Mappings;

public static class CustomerMapper
{
    public static CustomerDTO ToDTO(this CustomerEntity customer)
    {
        return new CustomerDTO
        {
            Name = customer.Name,
            Email = customer.Email,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber,
            CustomerNo = customer.CustomerNo,
        };
    }

    public static CustomerEntity ToEntity(this CustomerDTO dto)
    {
        return new CustomerEntity
        {
            Name = dto.Name,
            Email = dto.Email,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            CustomerNo = dto.CustomerNo,
        };
    }
}
