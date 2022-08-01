using CurrentAccount.IRepository;
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
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {            
            var result = await _unitOfWork.Users.Get(q => q.Id == id, "AccountList", "AccountList.TransactionList");
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllUsers()
        {

            var result = await _unitOfWork.Users.GetAll();

            return Ok(result);

        }
    }
}
