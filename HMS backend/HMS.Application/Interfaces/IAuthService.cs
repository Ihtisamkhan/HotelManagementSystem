using HMS.Application.Dtos.Auth;


namespace HMS.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterOwnerAsync(RegisterOwnerdto dto);

        Task RegisterCustomerAsync(RegisterCustomerdto dto);

        Task<LoginResponsedto> LoginAsync(Logindto dto);

        Task CreateEmployeeAsync(CreateEmployeedto dto);

        Task UpdateEmployeeAsync(int id, UpdateEmployeedto dto);

        Task ChangePasswordAsync(int userId, ChangePassworddto dto);

        Task<IEnumerable<Employeedto>> GetEmployeesByRoleAsync(string role);

        Task<IEnumerable<UserListdto>> GetUsersByRoleAsync(string role);

    }
}
