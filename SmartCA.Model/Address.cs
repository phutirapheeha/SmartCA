using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Model
{
    public class Address
    {
        private string street;
        private string city;
        private string state;
        private string postalCode;

        public Address(string street, string city, string state, string postalCode)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
        }

        public string Street { get { return this.street; } }
        public string City { get { return this.city; } }
        public string State { get { return this.state; } }
        public string PostalCode { get { return this.postalCode; } }

        private void Validate()
        {
            if (string.IsNullOrEmpty(this.street) ||
                string.IsNullOrEmpty(this.city) ||
                string.IsNullOrEmpty(this.state) ||
                string.IsNullOrEmpty(this.PostalCode))
                throw new InvalidOperationException("Invalid address.");
        }
    }
}
