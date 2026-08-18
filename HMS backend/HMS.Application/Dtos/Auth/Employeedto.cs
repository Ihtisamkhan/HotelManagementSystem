using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Application.Dtos.Auth
{
    public class Employeedto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}