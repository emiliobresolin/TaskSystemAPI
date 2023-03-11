using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepositoty : IUserRepository
    {
        private readonly TaskSystemDBContext _DbContext;
        public UserRepositoty(TaskSystemDBContext taskSystemDBContext) 
        {
            _DbContext = taskSystemDBContext;
        }
        public async Task<UserModel> GetById(int id)
        {
            return await _DbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _DbContext.Users.ToListAsync();
        }
        public async Task<UserModel> AddUser(UserModel user)
        {
            await _DbContext.Users.AddAsync(user);
            await _DbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetById(id);
            if (userById == null)
            {
                throw new Exception($"User's id (#{id}) was not found!");
            }
            userById.Name = user.Name;
            userById.Email = user.Email;

            _DbContext.Users.Update(userById);
            await _DbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetById(id);
            if (userById == null)
            {
                throw new Exception($"User's id (#{id}) was not found!");
            }
            _DbContext.Users.Remove(userById);
            await _DbContext.SaveChangesAsync();
            return true;
        }


    }
}
