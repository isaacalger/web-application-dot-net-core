using System;
using System.Collections.Generic;
using System.Linq;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Core;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Core.Repositories;
using WebApplication.Server.DTOModels;

namespace WebApplication.Server.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserAccountsController : ControllerBase, IUserAccountController
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserAccountsController(IUserAccountRepository userAccountRepository, IUnitOfWork unitOfWork)
        {
            _userAccountRepository = userAccountRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/UserAccounts
        [HttpGet]
        public ActionResult<IEnumerable<UserAccount>> GetUserAccounts()
        {
            return _userAccountRepository.GetAll().ToList();
        }

        // GET: api/UserAccounts/5
        [HttpGet("{id}")]
        public ActionResult<UserAccount> GetUserAccount(Guid id)
        {
            var userAccount = _userAccountRepository.Get(id);

            if (userAccount == null)
            {
                return NotFound();
            }

            return userAccount;
        }

        // PUT: api/UserAccounts/5
        [HttpPut("{id}")]
        public IActionResult PutUserAccount(Guid id, UserAccount userAccount)
        {
            if (UserAccountExists(id) == null)
            {
                return BadRequest();
            }

            // TODO Implement Changed State in UnitOfWork
            // EFCore Call for DBStateChange _dbContext.Entry(employee).State = EntityState.Modified;

            throw new NotImplementedException("Not Implemented Completely");
        }

        // POST: api/UserAccounts
        [HttpPost]
        public ActionResult<UserAccount> PostUserAccount(RegisterUserAccountDto registerUserAccountDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.AllErrors());
            }

            var userAccountGuid = Guid.NewGuid();
            var userAccount = new UserAccount
            {
                Guid = userAccountGuid,
                Email = registerUserAccountDto.Email,
                PasswordHash = registerUserAccountDto.Password.GetHashCode().ToString() // TODO Add Actual Hashing Algorithm
            };

            _userAccountRepository.Add(userAccount);
            _unitOfWork.Commit();

            return CreatedAtAction("GetUserAccount", new { id = userAccountGuid}, userAccount);
        }

        // DELETE: api/UserAccounts/5
        [HttpDelete("{id}")]
        public ActionResult<UserAccount> DeleteUserAccount(Guid id)
        {
            var userAccount = _userAccountRepository.Get(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _userAccountRepository.Remove(userAccount);
            _unitOfWork.Commit();

            return userAccount;
        }

        private UserAccount UserAccountExists(Guid id)
        {
            return _unitOfWork.UserAccounts.FirstOrDefault(u => u.Guid == id);
        }
    }
}
