using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using ReedExpo.Ecom.Registrations.Models;
using ReedExpo.Ecom.Registrations.Services;

namespace ReedExpo.Ecom.Registrations.Api.Tests
{
    public class RegistrationServiceTests
    {

        [Test]
        public async Task Add_Returns_SavedRecordId()
        {
            // Arrange
            var mockedStore = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());
            var underTest = new RegistrationsService(mockedStore);

            // Act
            var createdRecord = await underTest.AddRegistration(new RegistrationRequest()
            {
                Locale = "en-GB"
            });

            //Assert
            Assert.IsNotNull(createdRecord.RegistrationId);
        }

        [Test]
        public async Task Get_Returns_SavedRecord()
        {
            // Arrange
            var mockedStore = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());
            var underTest = new RegistrationsService(mockedStore);

            var createdRecord = await underTest.AddRegistration(new RegistrationRequest()
            {
                Locale = "en-GB"
            });


            //Act
            var savedRecord = await underTest.GetRegistration(createdRecord.RegistrationId);


            //Assert
            Assert.AreEqual(savedRecord.Id, createdRecord.RegistrationId);

        }

        [Test]
        public async Task Get_Returns_Null_WhenNoRecordFound()
        {
            // Arrange
            var mockedStore = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());
            var underTest = new RegistrationsService(mockedStore);

            //Act
            var result = await underTest.GetRegistration(Guid.NewGuid().ToString());


            //Assert
            Assert.AreEqual(result, null);

        }
    }
}