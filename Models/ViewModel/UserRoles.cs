﻿namespace COMP2139_Assignment1.Models.ViewModel
{
    public class UserRoles
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
