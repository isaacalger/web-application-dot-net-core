using System;
using System.ComponentModel.DataAnnotations;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication.Data.Core;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Server.DTOModels;

namespace WebApplication.Server.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        private ModelStateDictionary _modelState;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void RegisterUser(RegisterUserAccountDto model)
        {
            var validationResults = model.Validate(new ValidationContext(model));

            foreach (var validationResult in validationResults)
            { 
                _modelState = new ModelStateDictionary();
                var message = validationResult.ErrorMessage;
                var members = validationResult.MemberNames;
                // TODO Verify that this will work. I don't think this may be the correct key to be passing to this object
                _modelState.AddModelError(members.ToString(), message);
            }

            if (!_modelState.IsValid)
            {
                throw new ApiException(_modelState.Values);
            }

            var newUserAccount = new UserAccount {
                Email = model.Email,
                Username = model.Username,
                PasswordHash = model.Password.GetHashCode().ToString() //TODO Implement Actual Hasher
            };

            _unitOfWork.UserAccounts.Add(newUserAccount);
        }

        public void SendRegistrationEmail(string email)
        {
            throw new NotImplementedException("Configure an Email Service to handle Registration Requests.");
        }
    }
}