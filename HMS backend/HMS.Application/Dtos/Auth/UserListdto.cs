using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Application.Dtos.Auth
{
    public class UserListdto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = "";

        public string Username { get; set; } = "";

        public string Email { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public bool IsActive { get; set; }
    }
}
