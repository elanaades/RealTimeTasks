using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeTasks.Data;

namespace RealTimeTasks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly string _connectionString;

        private IHubContext<TaskHub> _hub;

        public TaskController(IConfiguration configuration, IHubContext<TaskHub> hub)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
            _hub = hub;
        }

        [HttpPost]
        [Route("addtask")]
        public void AddTask(TaskItem task)
        {
            var repo = new TaskRepository(_connectionString);
            repo.AddTask(task);
            _hub.Clients.All.SendAsync("newTask", task);
        }

        [HttpGet]
        [Route("gettasks")]
        public List<TaskItem> GetTasks()
        {
            var repo = new TaskRepository(_connectionString);
            return repo.GetTasks();
        }

        [HttpPost]
        [Route("claim")]
        public void TaskClaim(TaskItem taskItem)
        {
            var taskRepo = new TaskRepository(_connectionString);
            var userRepo = new UserRepository(_connectionString);


            var user = userRepo.GetByEmail(User.Identity.Name);
            taskItem.UserId = user.Id;

            taskRepo.UpdateTask(taskItem);

            _hub.Clients.All.SendAsync("taskUpdate", taskRepo.GetTasks());
        }

        [HttpPost]
        [Route("done")]
        public void TaskDone(TaskItem taskItem)
        {
            var repo = new TaskRepository(_connectionString);
            taskItem.IsDone = true;
            repo.UpdateTask(taskItem);

            _hub.Clients.All.SendAsync("taskUpdate", repo.GetTasks());
        }
    }
}
