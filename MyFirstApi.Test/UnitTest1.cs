using AutoMapper;
using Moq;
using MyFirstAPI;
using MyFirstAPI.DTO;
using MyFirstAPI.Helpers;
using MyFirstAPI.Repositories;
using MyFirstAPI.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstApi.Test
{
    public class AppUsersServiceTests
    {
        AppUser fakeUser;
        List<AppUser> fakeAllUserList;

        [SetUp]
        public void Setup()
        {
            //one fake user
            fakeUser = new AppUser
            {
                CityofOrigin = "faketown",
                Gender = "fake",
                Name = "Fakey McFaker",
                Interests = "none",
                DateOfBirth = new System.DateTime(1920, 01, 01)
            };

            //list of fake users

            fakeAllUserList = new List<AppUser>
            {
               new AppUser
                {
                    CityofOrigin = "faketown",
                    Gender = "fake",
                    Name = "Fakey McFaker1",
                    Interests = "none",
                    DateOfBirth = new System.DateTime(1910, 01, 01)
                },
               new AppUser
                {
                    CityofOrigin = "faketown",
                    Gender = "fake",
                    Name = "Fakey McFaker2",
                    Interests = "none",
                    DateOfBirth = new System.DateTime(1920, 02, 02)
                },
               new AppUser
                {
                    CityofOrigin = "faketown",
                    Gender = "fake",
                    Name = "Fakey McFaker3",
                    Interests = "none",
                    DateOfBirth = new System.DateTime(1930, 03, 02)
                }
            };

        }

        [Test]
        public async Task WhenGetMemberAsyncCalled_UserIsMappedToMemberDtoAsync()
        {
            /*
             * 
             * UNIT TESTING WITH DEPENDENCY INJECTION & API
             * 
             * **/

            // - - - ARRANGE - - -

            //create mock version of Interface (to fake dependency injection)
            var mockRepo = new Mock<IAppUserRepository>();
            

            //Fake the return value of a Mock Dependency
            mockRepo.Setup(x => x.GetUser(It.IsAny<int>())).ReturnsAsync(fakeUser);

            //Initialize AutoMapper for Unit Tests (not faked/mocked)
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());

            //pass mocked interface to fake dependency injection
            var service = new AppUserService(mockRepo.Object, config.CreateMapper());


            // - - - ACT - - - 

            MemberDTO result = await service.GetMemberAsync(1);

            // - - - ASSERT - - -

            Assert.NotNull(result);
            Assert.AreEqual("faketown", result.City);
        }

        [Test]
        public async Task WhenGetUserIsCalled_ReturnCorrectUserAsync()
        {
            // - - - ARRANGE - - -
            
            var mockRepo = new Mock<IAppUserRepository>();
            mockRepo.Setup(x => x.GetUser(1)).ReturnsAsync(fakeUser);

            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());

            var service = new AppUserService(mockRepo.Object, config.CreateMapper());

            // - - - ACT - - - 
            AppUser result = await service.GetUser(1);

            // - - - ASSERT - - -
            Assert.NotNull(result);
            Assert.AreEqual("Fakey McFaker", result.Name);

        }

        [Test]
        public async Task WhenGetAllUsersIsCalled_ReturnAllUsersAsync()
        {
            // - - - ARRANGE - - -

            var mockRepo = new Mock<IAppUserRepository>();
            mockRepo.Setup(x => x.GetUsers()).ReturnsAsync(fakeAllUserList);

            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());

            var service = new AppUserService(mockRepo.Object, config.CreateMapper());

            // - - - ACT - - - 

            List<AppUser> result = await service.GetUsers();

            // - - - ASSERT - - -

            Assert.NotNull(result);
            Assert.AreEqual(result, fakeAllUserList);
        }

        

        
    }
}