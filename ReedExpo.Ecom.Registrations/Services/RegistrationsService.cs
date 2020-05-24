using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using ReedExpo.Ecom.Registrations.Models;

namespace ReedExpo.Ecom.Registrations.Services
{
    public class RegistrationsService : IRegistrationsService
    {
        private readonly IMemoryCache _memoryCache;

        public RegistrationsService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<RegistrationResponse> AddRegistration(RegistrationRequest request)
        {
            var guid = Guid.NewGuid();

            var registration = new Registration();
            registration.Id = guid.ToString();
            registration.Locale = request.Locale;
            registration.Organisation = request.Organisation;
            registration.Person = request.Person;
            registration.RegistrationDate = request.RegistrationDate;
            //  _memoryCache.Set(registration.Id, registration);
            var savedEntry = await _memoryCache.GetOrCreateAsync(registration.Id, entry => Task.FromResult(registration));

            var response = new RegistrationResponse {RegistrationId = savedEntry.Id};

            return response;
            
        }

        public async Task<GetRegistrationResponse> GetRegistration(string registrationId)
        {
            if (!_memoryCache.TryGetValue(registrationId, out Registration registration))
                return await Task.FromResult<GetRegistrationResponse>(null);

            var response = new GetRegistrationResponse
            {
                Id = registration.Id,
                Locale = registration.Locale,
                Organisation = registration.Organisation,
                Person = registration.Person,
                RegistrationDate = registration.RegistrationDate
            };

            return await Task.FromResult(response);

        }
    }
}