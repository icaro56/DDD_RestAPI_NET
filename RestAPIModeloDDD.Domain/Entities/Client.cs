﻿using System;

namespace RestAPIModeloDDD.Domain.Entities
{
    public class Client : Base
    {
        public string Name { get; set; }

        public string  LastName { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }
    }
}
