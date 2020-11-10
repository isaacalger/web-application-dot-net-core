using System;
using System.Linq;
using Autofac.Extras.Moq;
using Moq;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Core.Repositories;
using Xunit;

// ReSharper disable ConvertToUsingDeclaration
// This is a personal preference I think its easier to read Using blocks

namespace WebApplication.Tests.UnitTests.DataLayer
{
    public class UserAccountRepositoryTest
    {


        [Fact]
        public void GetAll_ShouldGetAllMockedUserAccounts()
        {
            using (var mockRepository = AutoMock.GetLoose())
            {
                //Arrange
                var expected = TestData.GetUserAccounts();

                mockRepository.Mock<IUserAccountRepository>()
                    .Setup(r => r.GetAll())
                    .Returns(expected);

                //Act
                var userAccountRepository = mockRepository.Create<IUserAccountRepository>();
                var actual = userAccountRepository.GetAll();

                //Assert
                Assert.True(expected.Count() == actual.Count());
            }

        }

        [Fact]
        public void Get_ShouldReturnCorrectRecord()
        {
            using (var mockRepository = AutoMock.GetLoose())
            {
                //Arrange
                var expected = TestData.GetUserAccounts();
                foreach (var userAccount in expected)
                {
                    mockRepository.Mock<IUserAccountRepository>()
                        .Setup(r => r.Get(userAccount.Guid))
                        .Returns(expected.Find(u => u.Guid == userAccount.Guid));

                    //Act
                    var userAccountRepository = mockRepository.Create<IUserAccountRepository>();
                    var actualUserAccount = userAccountRepository.Get(userAccount.Guid);

                    //Assert
                    Assert.True(userAccount.Email == actualUserAccount.Email);
                }
            }
        }

        [Theory]
        //TODO I dont like that this data is passed in like this.
        // Once I have a processor change this so I can add data with a processor then verify the results.
        [InlineData("20000000-0000-0000-0000-000000000001", "IsaacAlger@gmail.com", "IsaacAlger", "TestHash")]
        [InlineData("20000000-0000-0000-0000-000000000002", "IsaacAlger2@gmail.com", "IsaacAlger2", "TestHash2")]
        public void Add_ShouldAddTheExpectedRecord(Guid guid, string email, string username, string passwordHash)
        {
            using (var mockRepository = AutoMock.GetLoose())
            {
                //Arrange
                var expectedUserAccount = new UserAccount
                {
                    Guid = guid,
                    Email = email,
                    Username = username,
                    PasswordHash = passwordHash
                };

                mockRepository.Mock<IUserAccountRepository>()
                    .Setup(r => r.Add(expectedUserAccount));

                //Act
                var userAccountRepository = mockRepository.Create<IUserAccountRepository>();
                userAccountRepository.Add(expectedUserAccount);

                //Assert
                mockRepository.Mock<IUserAccountRepository>()
                    .Verify(r => r.Add(expectedUserAccount), Times.Exactly(1));
            }
        }

        [Fact]
        public void AddRange_ShouldAddAllExpectedRecords()
        {
            using (var mockRepository = AutoMock.GetLoose())
            {
                var expected = TestData.GetUserAccounts();

                mockRepository.Mock<IUserAccountRepository>()
                    .Setup(r => r.AddRange(expected));

                var userAccountRepository = mockRepository.Create<IUserAccountRepository>();
                userAccountRepository.AddRange(expected);

                mockRepository.Mock<IUserAccountRepository>()
                    .Verify(r => r.AddRange(expected), Times.Exactly(1));
            }
        }

        [Theory]
        [InlineData("20000000-0000-0000-0000-000000000001", "IsaacAlger@gmail.com", "IsaacAlger", "TestHash")]
        [InlineData("20000000-0000-0000-0000-000000000002", "IsaacAlger2@gmail.com", "IsaacAlger2", "TestHash2")]
        public void Remove_ShouldRemoveTheExpectedRecords(Guid guid, string email, string username, string passwordHash)
        {
            using (var mockRepository = AutoMock.GetLoose())
            {
                //Arrange
                var expectedUserAccount = new UserAccount
                {
                    Guid = guid,
                    Email = email,
                    Username = username,
                    PasswordHash = passwordHash
                };

                mockRepository.Mock<IUserAccountRepository>()
                    .Setup(r => r.Remove(expectedUserAccount));

                //Act
                var userAccountRepository = mockRepository.Create<IUserAccountRepository>();
                userAccountRepository.Remove(expectedUserAccount);

                //Assert
                mockRepository.Mock<IUserAccountRepository>()
                    .Verify(r => r.Remove(expectedUserAccount), Times.Exactly(1));
            }
        }

        [Fact]
        public void RemoveRange_ShouldRemoveAllExpectedRecords()
        {
            using (var mockRepository = AutoMock.GetLoose())
            {
                //Arrange
                var expected = TestData.GetUserAccounts();

                mockRepository.Mock<IUserAccountRepository>()
                    .Setup(r => r.RemoveRange(expected));

                //Act
                var userAccountRepository = mockRepository.Create<IUserAccountRepository>();
                userAccountRepository.RemoveRange(expected);

                //Assert
                mockRepository.Mock<IUserAccountRepository>()
                    .Verify(r => r.RemoveRange(expected), Times.Exactly(1));
            }
        }
    }
}
