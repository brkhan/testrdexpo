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
            var mockedService = new Mock<IRegistrationsService>();

            var underTest = new RegistrationsController(mockedService.Object);

            var request = new RegistrationRequest();

            await underTest.AddRegistration(request);

            mockedService.Verify(a => a.AddRegistration(request), Times.Once);
        }

    }
}