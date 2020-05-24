using System.Threading.Tasks;
using ReedExpo.Ecom.Registrations.Models;

namespace ReedExpo.Ecom.Registrations.Services
{
    public interface IRegistrationsService
    {
        Task<RegistrationResponse> AddRegistration(RegistrationRequest request);

        Task<GetRegistrationResponse> GetRegistration(string registrationId);
    }
}