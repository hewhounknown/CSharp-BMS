namespace BMS.Models.Customers;

public record CustomerRequest(string name, string email, string address, string phoneNumber)
{
    public CustomerDTO ToDTO()
    {
        return new CustomerDTO
        {
            Name = name,
            Email = email,
            Address = address,
            PhoneNumber = phoneNumber,
            CustomerNo = GenerateCode(name)
        };
    }

    private string GenerateCode(string name)
    {
        string prefix = name.Trim().Substring(0, 3).ToUpper();

        Random rdn = new Random();
        string code = prefix + rdn.Next(1000, 9999).ToString();

        return code;
    }
};