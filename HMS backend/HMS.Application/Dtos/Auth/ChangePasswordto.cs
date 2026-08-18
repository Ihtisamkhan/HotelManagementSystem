using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Application.Dtos.Auth
{
    public class ChangePassworddto
    {
        public string CurrentPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
