using System;

namespace ReedExpo.Ecom.Registrations.Models
{
    public class Registration
    {
        public Organisation Organisation { get; set; }

        public Person Person { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string Locale { get; set; }

        public string Id { get; set; }
    }
}