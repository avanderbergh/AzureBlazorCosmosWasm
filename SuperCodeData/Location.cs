using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SuperCodeData {
    [Owned]
    public class Location {
        public Location () {
            Id = Guid.NewGuid ();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}