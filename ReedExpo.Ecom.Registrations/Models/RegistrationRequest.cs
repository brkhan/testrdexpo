using System;

namespace ReedExpo.Ecom.Registrations.Models
{
    public class RegistrationRequest
    {
        public Organisation Organisation { get; set; }

        public Person Person { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string Locale { get; set; }


    }
}