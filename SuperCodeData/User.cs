using System;
using System.Collections.Generic;

namespace SuperCodeData {
    public class User {
        public User () {
            Id = Guid.NewGuid ();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}