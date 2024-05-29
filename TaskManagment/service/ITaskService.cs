using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.models;

namespace service
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetAllTasks();
        TaskModel CreateTask(string taskName, string taskDescription, bool taskStatus);
        void DeleteTask(int id);
    }
}