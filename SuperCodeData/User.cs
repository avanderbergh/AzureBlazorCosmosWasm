using System;
using System.Collections.Generic;

namespace SuperCodeData {
    public enum UserType {
        Prospect,
        Participant,
        Intern,
        Employee,
        Admin
    }

    public class User {
        public User () {
            Id = Guid.NewGuid ();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }

        public UserType Type { get; set; }
    }
}