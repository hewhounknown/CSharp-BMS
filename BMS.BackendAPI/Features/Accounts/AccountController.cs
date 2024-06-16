using BMS.Models.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.BackendAPI.Features.Accounts;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            List<AccountDTO> accounts = _accountService.GetAccounts();
            return Ok(accounts);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            AccountDTO account = FindAccount(id);
            if (account == null) return NotFound("no ACC found");

            return Ok(account);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Create(AccountRequest acc)
    {
        try
        {
            if (!acc.IsStrongPassword()) return BadRequest("pls make strong password");

            int result = _accountService.CreateAccount(acc.ToDTO());

            string msg = result > 0 ? "created success" : "failed";
            return Ok(msg);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, AccountRequest acc)
    {
        try
        {
            AccountDTO isExist = FindAccount(id);
            if (isExist == null) return NotFound("no ACC found");

            AccountDTO dto = acc.ToDTO();
            if (acc.accountType.ToString() == isExist.AccountType)
            {
                dto.AccountNo = isExist.AccountNo;
            }

            int result = _accountService.UpdateAccount(id, dto);

            string msg = result > 0 ? "updated success" : "failed";
            return Ok(msg);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            int result = _accountService.DeleteAccount(id);

            string msg = result > 0 ? "deleted success" : "failed";
            return Ok(msg);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    private AccountDTO FindAccount(int id)
    {
        return _accountService.GetAccount(id);
    }
}
