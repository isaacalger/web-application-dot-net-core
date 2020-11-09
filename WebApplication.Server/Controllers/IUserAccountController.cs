using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Server.DTOModels;

namespace WebApplication.Server.Controllers
{
    public interface IUserAccountController
    {
        ActionResult<IEnumerable<UserAccount>> GetUserAccounts();
        ActionResult<UserAccount> GetUserAccount(Guid id);
        IActionResult PutUserAccount(Guid id, UserAccount userAccount);
        ActionResult<UserAccount> PostUserAccount(RegisterUserAccountDto registerUserAccountDto);
        ActionResult<UserAccount> DeleteUserAccount(Guid id);

    }
}
