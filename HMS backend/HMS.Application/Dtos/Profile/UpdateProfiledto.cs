namespace HMS.Application.Dtos.Profile
{
    public class UpdateProfileDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }
    }
}
