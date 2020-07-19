using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SuperCodeData {
    [Owned]
    public class Address {
        public Address () {
            Id = Guid.NewGuid ();
        }

        public Guid Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }
    }
}