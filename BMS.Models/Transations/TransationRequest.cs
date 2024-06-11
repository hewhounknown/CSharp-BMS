namespace BMS.Models.Transations;

public record TransationRequest(decimal amount, EnumTransationType type, string? receiverNo, string accountNo, string password)
{
    public TransationDTO ToDTO()
    {
        return new TransationDTO
        {
            TransationDate = dateTime,
            Amount = amount,
            TransationType = transationTypeString,
            ReceiverNo = receiverNo ?? null,
            AccountNo = accountNo
        };
    }

    private string dateTime => DateTime.Now.ToString(format: "dd-MM-yyyy h:m:s");
    private string transationTypeString => type.ToString();
}

public enum EnumTransationType
{
    Deposite,
    Withdrawal,
    Transfer
}
