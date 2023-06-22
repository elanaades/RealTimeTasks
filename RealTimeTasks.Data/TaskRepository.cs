using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeTasks.Data
{
    public class TaskRepository
    {
        private readonly string _connectionString;

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddTask(TaskItem task)
        {
            using var context = new TaskDataContext(_connectionString);
            context.TaskItems.Add(task);
            context.SaveChanges();
        }

        public List<TaskItem> GetTasks()
        {
            using var context = new TaskDataContext(_connectionString);
            return context.TaskItems
                .Include(t => t.User)
                .Where(t => t.IsDone == null)
                .ToList();
        }

        public void UpdateTask(TaskItem taskItem)
        {
            using var context = new TaskDataContext(_connectionString);
            context.TaskItems.Update(taskItem);
            context.SaveChanges();
        }
    }
}
