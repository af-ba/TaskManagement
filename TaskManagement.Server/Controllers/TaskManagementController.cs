using Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Server.Data;
using TaskManagement.Server.Interface;
using TaskManagement.Server.Models;

namespace TaskManagement.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TaskManagementController : ControllerBase
    {
        private readonly ITaskManagerService _taskService;
        private readonly IUserRegistrationService _userService;
        public TaskManagementController(ITaskManagerService taskService, IUserRegistrationService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
            int userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name).Id;
            List<TaskModel> tasks = await _taskService.GetAllTasks(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            int userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name).Id;
            TaskModel task = await _taskService.GetTaskById(id, userId);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> AddTask(TaskModel entityToAdd)
        {
            int userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name).Id;
            await _taskService.AddTask(userId, entityToAdd);
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(TaskModel entityToUpdate)
        {
            int userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name).Id;
            if (entityToUpdate.UserId != userId)
            {
                return BadRequest("only owners can update their tasks");
            }
            await _taskService.UpdateTask(entityToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            int userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name).Id;
            var task = await _taskService.GetTaskById(id, userId);
            if(task == null)
            {
                return NotFound();
            }
            await _taskService.DeleteTask(task);
            return NoContent();
        }
    }
}
