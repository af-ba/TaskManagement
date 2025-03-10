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
            var userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name)?.Id;
            if(userId == null) {
                return BadRequest("this user does not has any tasks");
            }
            List<TaskModel> tasks = await _taskService.GetAllTasks(userId.Value);
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
            if (!IsValid(entityToAdd))
            {
                return BadRequest("Fields should be valid");
            }
            int userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name).Id;
            TaskModel addedEntity = await _taskService.AddTask(userId, entityToAdd);
            return CreatedAtAction("GetTask",new { id = addedEntity.Id }, addedEntity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id,TaskModel entityToUpdate)
        {
            int userId = _userService.GetRegisteredUserByEmail(this.User.Identity.Name).Id;
            if (!IsValid(entityToUpdate))
            {
                return BadRequest("Fields should be valid");
            }
            var task = await _taskService.GetTaskById(id, userId);
            if (task == null)
            {
                return NotFound();
            }
            task.Title = entityToUpdate.Title;
            task.Description = entityToUpdate.Description;
            task.IsCompleted = entityToUpdate.IsCompleted;
            task.DueDate = entityToUpdate.DueDate;
            await _taskService.UpdateTask(task);
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


        private bool IsValid(TaskModel task)
        {
            return !string.IsNullOrEmpty(task.Title) && task.DueDate != null;
        }
    }
}
