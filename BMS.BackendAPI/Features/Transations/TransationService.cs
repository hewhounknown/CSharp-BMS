using BMS.Mappings;
using BMS.Models.Accounts;
using BMS.Models.Transations;
using BMS.WebAPI.Features.Accounts;

namespace BMS.BackendAPI.Features.Transations;

public class TransationService
{
    private readonly TransationRepository _transationRepo;
    private readonly AccountService _accService;

    public TransationService()
    {
        _transationRepo = new TransationRepository();
        _accService = new AccountService();
    }

    public int AddTransation(TransationRequest transationRequest)
    {
        int result = 0;

        string accountNo = transationRequest.receiverNo;
        string password = transationRequest.password;

        AccountDTO accountDTO =  _accService.GetAccountByNo(accountNo);

        if (accountDTO == null || accountDTO.Password != password) return 0;

        TransationDTO dto = transationRequest.ToDTO();

        switch (transationRequest.type)
        {
            case EnumTransationType.Deposite:
                decimal amount = accountDTO.Balance + dto.Amount;
                result = _transationRepo.AddTransation(dto.ToEntity(), amount, accountNo, password);
                break;
            case EnumTransationType.Withdrawal:
                //
                break;
            case EnumTransationType.Transfer:
                //
                break;
            default:
                break;
        }

        return result;
    }

    public List<TransationDTO> GetAllTransations()
    {
        List<TransationEntity> transations = _transationRepo.GetAllTransations();
        return transations.Select(x => x.ToDTO()).ToList();
    }
}