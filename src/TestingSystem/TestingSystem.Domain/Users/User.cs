using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Male { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
