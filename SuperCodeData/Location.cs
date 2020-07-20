using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SuperCodeData {
    public class Location {
        public Location () {
            Id = Guid.NewGuid ();
            LocationId = Id.ToString();
        }

        public Guid Id { get; set; }
        public string LocationId { get; set; }

        public string Title { get; set; }

        public ICollection<User> Users { get; set; }
    }
}