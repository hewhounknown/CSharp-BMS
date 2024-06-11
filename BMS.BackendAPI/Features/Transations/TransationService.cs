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

        string accountNo = transationRequest.accountNo;
        string password = transationRequest.password;

        AccountDTO accountDTO = _accService.GetAccountByNo(accountNo);

        if (accountDTO == null || accountDTO.Password != password) throw new InvalidOperationException("Incorrect password or no account");

        TransationDTO dto = transationRequest.ToDTO();

        decimal amount;
        switch (transationRequest.type)
        {
            case EnumTransationType.Deposite:
                amount = accountDTO.Balance + dto.Amount;
                result = _transationRepo.AddTransation(dto.ToEntity(), amount, accountNo, password);
                break;
            case EnumTransationType.Withdrawal:
                if (dto.Amount > accountDTO.Balance) throw new InvalidOperationException("Not enought balance for withdrawal.");

                amount = accountDTO.Balance - dto.Amount;
                result = _transationRepo.AddTransation(dto.ToEntity(), amount, accountNo, password);
                break;
            case EnumTransationType.Transfer:
                if(string.IsNullOrEmpty(transationRequest.receiverNo)) throw new InvalidOperationException("Require Receiver balance for Transfer.");

                string receiverNo = transationRequest.receiverNo;
                AccountDTO receiverDTO = _accService.GetAccountByNo(receiverNo);

                if (dto.Amount > accountDTO.Balance || receiverDTO == null) throw new InvalidOperationException("Not enought balance or no receiver account");

                amount = accountDTO.Balance - dto.Amount;
                int condition1 = _transationRepo.AddTransation(dto.ToEntity(), amount, accountNo, password);

                amount = receiverDTO.Balance + dto.Amount;
                int condition2 = _transationRepo.UpdateReceiverAccount(receiverNo, amount);

                result = 1;
                if(condition1 != condition2) result = 0;
                break;
            default:
                result = 0;
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