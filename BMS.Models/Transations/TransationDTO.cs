namespace BMS.Models.Transations;

public class TransationDTO
{
    public string TransationDate { get; set; }
    public decimal Amount { get; set;}
    public string TransationType { get; set; }
    public string? ReceiverNo { get; set; }
    public string AccountNo { get; set; }
}
