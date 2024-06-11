using BMS.Models.Transations;

namespace BMS.Mappings;

public static class TransationMapper
{
    public static TransationDTO ToDTO(this TransationEntity transation)
    {
        return new TransationDTO
        {
            TransationDate = transation.TransationDate,
            Amount = transation.Amount,
            TransationType = transation.TransationType,
            ReceiverNo = transation.ReceiverNo,
            AccountNo = transation.AccountNo,
        };
    }

    public static TransationEntity ToEntity(this TransationDTO dto)
    {
        return new TransationEntity
        {
            TransationDate = dto.TransationDate,
            Amount = dto.Amount,
            TransationType = dto.TransationType,
            ReceiverNo = dto.ReceiverNo,
            AccountNo = dto.AccountNo,
        };
    }
}
