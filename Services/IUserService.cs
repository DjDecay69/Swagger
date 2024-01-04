using EndPoint3.Models;

namespace EndPoint3.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetUsers();
        Task<ServiceResponse<User>>AddUserAsync(AddUserDto user);

        Task<ServiceResponse<User>>UpdateUserAsync(UpdateUserDto user);
        Task<ServiceResponse<User>> DeleteUserAsync(DeleteUserDto user);
    }
}
