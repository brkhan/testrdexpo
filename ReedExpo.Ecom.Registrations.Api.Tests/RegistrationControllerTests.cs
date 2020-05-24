using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReedExpo.Ecom.Registrations.Controllers;
using ReedExpo.Ecom.Registrations.Models;
using ReedExpo.Ecom.Registrations.Services;

namespace ReedExpo.Ecom.Registrations.Api.Tests
{
    public class RegistrationControllerTests
    {
        [Test]
        public async Task AddRegistration_Calls_Service()
        {

            //Arrange
            var mockedService = new Mock<IRegistrationsService>();

            var underTest = new RegistrationsController(mockedService.Object);

            var request = new RegistrationRequest();

            //Act
            await underTest.AddRegistration(request);


            //Assert
            mockedService.Verify(a => a.AddRegistration(request), Times.Once);
        }



        [Test]
        public async Task AddRegistration_Returns_OK()
        {
            //Arrange
            var mockedService = new Mock<IRegistrationsService>();
            var serviceResponse = new RegistrationResponse()
            {
                RegistrationId = Guid.NewGuid().ToString()
            };

            var request = new RegistrationRequest();
            mockedService.Setup(a => a.AddRegistration(It.IsAny<RegistrationRequest>())).ReturnsAsync(serviceResponse);
            var underTest = new RegistrationsController(mockedService.Object);

            //Act
            var result = await underTest.AddRegistration(request);

            //Assert
            Assert.AreEqual(result.GetType(), typeof(OkObjectResult));

            
            var actualResponse = ((result as OkObjectResult).Value) as RegistrationResponse;
            Assert.AreEqual(actualResponse.RegistrationId, serviceResponse.RegistrationId);
        }
    }
}