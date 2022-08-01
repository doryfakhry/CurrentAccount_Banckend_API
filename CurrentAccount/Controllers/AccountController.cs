using CurrentAccount.Data;
using CurrentAccount.IRepository;
using CurrentAccount.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _appdbContext;
        public AccountController(IUnitOfWork unitOfWork, AppDbContext appdbContext)
        {
            _unitOfWork = unitOfWork;
            _appdbContext = appdbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            
            try
            {
                User user = await _unitOfWork.Users.Get(q => q.Id == account.Id, null, null);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,"User id not found");
                }

                Account createAccount = new Account();

                createAccount.UserId = user.Id;
                createAccount.initialcredit = account.initialcredit;

                await _unitOfWork.Accounts.Insert(createAccount);
                await _unitOfWork.Save();
                var results = CreatedAtRoute("GetAccount", new { id = createAccount.Id }, createAccount);
        
                var lastId = createAccount.Id;

                if (account.initialcredit != 0)
                {
                    Transaction tra = new Transaction();
                    tra.AccountId = lastId;
                    tra.Amount = account.initialcredit;
                    tra.TransactionDate = DateTime.Now;

                    await _unitOfWork.Transactions.Insert(tra);
                    await _unitOfWork.Save();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in posting Data!!");
                
            }
        }
    }
}
