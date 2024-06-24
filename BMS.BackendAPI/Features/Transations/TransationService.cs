using BMS.BackendAPI.Features.Accounts;
using BMS.Mappings;
using BMS.Models.Accounts;
using BMS.Models.Transations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BMS.BackendAPI.Features.Transations;

public class TransationService
{
    private readonly TransationRepository _transationRepo;
    private readonly AccountService _accService;

    public TransationService(TransationRepository transationRepo, AccountService accService)
    {
        _transationRepo = transationRepo;
        _accService = accService;
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
                if (!string.IsNullOrEmpty(dto.ReceiverNo)) dto.ReceiverNo = null;

                amount = accountDTO.Balance + dto.Amount;
                result = _transationRepo.AddTransation(dto.ToEntity(), amount, accountNo, password);
                break;
            case EnumTransationType.Withdrawal:
                if (dto.Amount > accountDTO.Balance) throw new InvalidOperationException("Not enought balance for withdrawal.");

                if (!string.IsNullOrEmpty(dto.ReceiverNo)) dto.ReceiverNo = null;

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

    public TransationDTO GetTransation(int id)
    {
        TransationEntity transation = _transationRepo.GetTransation(id);
        return transation.ToDTO();
    }

    public List<TransationEntity> GetTransationsByAccNo(string accNo)
    {
        List<TransationEntity> transations = _transationRepo.GetTransationsByAccNo(accNo);
        return transations;
    }
}