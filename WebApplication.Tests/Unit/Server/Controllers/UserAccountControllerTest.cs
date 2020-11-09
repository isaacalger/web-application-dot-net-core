using System;
using System.Linq;
using Autofac.Extras.Moq;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Core.Repositories;
using WebApplication.Server.Controllers.V1;
using Xunit;
// ReSharper disable ConvertToUsingDeclaration

namespace WebApplication.Tests.Unit.Server.Controllers
{
    public class UserAccountControllerTest
    {
        [Fact]
        public void GetUserAccount_ShouldRetrieveAllTestUserAccounts()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                var expected = TestData.GetUserAccounts();

                mock.Mock<IUserAccountRepository>()
                    .Setup(r => r.GetAll())
                    .Returns(expected);

                var userAccountsController = mock.Create<UserAccountsController>();
                
                // Act
                var results = userAccountsController.GetUserAccounts();

                // Assert
                var actual = results.Value;
                Assert.True(expected.Count() == actual.Count());
            }
        }

        [Fact]
        public void AddUserAccount_ShouldAddUserAccount()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                var newTestGuid = Guid.NewGuid();
                var userAccount = new UserAccount()
                {
                    Guid = newTestGuid,
                    Email = "NewUser@gmail.com",
                    PasswordHash = "MyPassword".GetHashCode().ToString()
                };

                mock.Mock<IUserAccountRepository>()
                    .Setup(r => r.Add(userAccount));

                mock.Mock<IUserAccountRepository>()
                    .Setup(r => r.Get(newTestGuid)).Returns(userAccount);

                var userAccountsController = mock.Create<UserAccountsController>();

                // Act
                var results = userAccountsController.GetUserAccount(newTestGuid);

                // Assert
                var actual = results.Value;
                Assert.True(userAccount.Email == actual.Email);
            }
        }
    }
}
