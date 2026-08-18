namespace HMS.Application.Dtos.Profile
{
    public class ProfileDto
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
