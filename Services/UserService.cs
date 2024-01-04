using EndPoint3.Database;
using EndPoint3.Models;
using EndPoint3.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EndPoint3.Services
{
    public class UserService : IUserService
    {
        public readonly IConfiguration _configuration;
        private readonly DataContext _context;
        public UserService(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<User>> AddUserAsync(AddUserDto user)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = Encoding.UTF8.GetBytes( user.Password ),
                Email = user.Email,
                Phone = user.Phone
            };
            var result = _context.Users.AddAsync(newUser);
            _context.SaveChanges();
            response.Data = result.Result.Entity;
            return response;
        }

        public async Task<ServiceResponse<List<User>>> GetUsers()
        {
            ServiceResponse<List<User>> response = new ServiceResponse<List<User>>();
            List<User> result = await _context.Users.ToListAsync();
            response.Data = result;
            return response;
        }

        public async Task<ServiceResponse<User>> UpdateUserAsync(UpdateUserDto user)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            User userFound = await _context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
             if (userFound != null)
            {
                userFound.FirstName = user.FirstName;
                userFound.LastName = user.LastName;
                userFound.Password = Encoding.UTF8.GetBytes( user.Password );
                userFound.Email = user.Email;
                userFound.Phone = user.Phone;
                _context.Users.Update(userFound);
                _context.SaveChanges();
                response.Data = userFound;
            }
            else
            {
                response.Success = false;
            }
            return response;
            
        }
        public async Task<ServiceResponse<User>>DeleteUserAsync(DeleteUserDto user)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            User userToDelete = await _context.Users.FirstOrDefaultAsync(u=>u.UserID == user.UserID);
            if(userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                response.Message = "User deleted successful";
                _context.SaveChanges();
            }
            else
            {
                response.Success=false;
            }
            return response;
        }
    }
    
}
