using TaskManagement.Server.DTOs;
using TaskManagement.Server.Models;

namespace TaskManagement.Server.Interface
{
    public interface ITaskManagerService
    {
        Task<TaskModel> GetTaskById(int id, int userId);
        Task<List<TaskModel>> GetAllTasks(int userId);
        Task AddTask(int userId, TaskModel entity);
        Task UpdateTask(TaskModel entity);
        Task DeleteTask(TaskModel task);
    }
}
