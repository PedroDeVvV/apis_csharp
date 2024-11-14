using MyTasks.Models;

namespace MyTasks.Repositories.Interfaces
{
    public interface IUserRepository
    {
        //get 
        Task<List<UserModel>> GetAllUsers();
        //get by param
        Task<UserModel> GetUserById(int id);
        //post
        Task<UserModel> AddUser(UserModel user);
        //patch
        Task<UserModel> UpdateUser(UserModel user, int id);
        //delete
        Task<bool> DeleteUser(int id);
    }
}
