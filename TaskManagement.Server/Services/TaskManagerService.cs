using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TaskManagement.Server.Data;
using TaskManagement.Server.Interface;
using TaskManagement.Server.Models;

namespace TaskManagement.Server.Services
{
    public class TaskManagerService :ITaskManagerService
    {
        private readonly DBContextClass _context;

        public TaskManagerService(DBContextClass context)
        {
            _context = context;
        }


        public async Task<TaskModel> GetTaskById(int taskId, int userId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null && task.UserId == userId)
            {
                return task;           
            }
            return null;
        }

        public async Task<List<TaskModel>> GetAllTasks(int userId)
        {
            return await _context.Tasks.Include(y => y.UserRegistration).Where(t => t.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<TaskModel> AddTask(int userId, TaskModel task )
        {
            task.UserId = userId;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task UpdateTask(TaskModel task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(TaskModel task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }


    }
}
