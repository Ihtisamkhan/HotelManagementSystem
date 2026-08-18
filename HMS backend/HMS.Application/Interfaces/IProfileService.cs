using HMS.Application.Dtos.Profile;

namespace HMS.Application.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileDto?> GetProfileAsync(int userId);

        Task UpdateProfileAsync(int userId, UpdateProfileDto dto);
    }
}
