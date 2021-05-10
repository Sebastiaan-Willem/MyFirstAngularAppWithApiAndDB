using AutoMapper;
using Moq;
using MyFirstAPI;
using MyFirstAPI.DTO;
using MyFirstAPI.Helpers;
using MyFirstAPI.Repositories;
using MyFirstAPI.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyFirstApi.Test
{
    public class AppUsersServiceTests
    {
        [SetUp]
        public void Setup()
        {
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

            AppUser fakeUser = new AppUser
            {
                CityofOrigin = "faketown",
                Gender = "fake",
                Name = "Fakey McFaker",
                Interests = "none",
                DateOfBirth = new System.DateTime(1920, 01, 01)
            };

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
    }
}