using Microsoft.EntityFrameworkCore;
using MyTasks.Data;
using MyTasks.Models;
using MyTasks.Repositories.Interfaces;

namespace MyTasks.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }

        //add user
        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        //get all users
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        //get user by id
        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        //update user
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userToUpdate = await GetUserById(id);

            if (userToUpdate == null)
            {
                throw new Exception($"User from ID: {id} not found in database");
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();

            return userToUpdate;
        }

        //delete user by id
        public async Task<bool> DeleteUser(int id)
        {
            UserModel userToUpdate = await GetUserById(id);

            if (userToUpdate == null)
            {
                throw new Exception($"User from ID: {id} not found in database");
            }
            _dbContext.Users.Remove(userToUpdate);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
