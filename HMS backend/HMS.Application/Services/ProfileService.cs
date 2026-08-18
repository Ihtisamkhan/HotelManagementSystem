using AutoMapper;
using HMS.Application.Dtos.Profile;
using HMS.Application.Interfaces;
using HMS.Application.Interfaces.Repositories;

namespace HMS.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public ProfileService(
            IProfileRepository profileRepository,
            IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<ProfileDto?> GetProfileAsync(int userId)
        {
            var user = await _profileRepository.GetByIdAsync(userId);

            if (user == null)
                return null;

            return _mapper.Map<ProfileDto>(user);
        }

        public async Task UpdateProfileAsync(int userId, UpdateProfileDto dto)
        {
            var user = await _profileRepository.GetByIdAsync(userId);

            if (user == null)
                throw new Exception("User not found.");

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            await _profileRepository.UpdateAsync(user);
            await _profileRepository.SaveChangesAsync();
        }
    }
}
