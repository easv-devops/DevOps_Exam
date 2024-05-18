using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.models;
using infrastructure.repositories;

namespace service.services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;

        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            try
            {
                return _repository.GetAllTasks();
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not get all tasks due to this {ex}!");
            }
        }
        public TaskModel CreateTask(string taskName, string taskDescription, bool taskStatus)
        {
            var taskToCreate = new TaskModel
            {
                DateCreated = DateTime.UtcNow,
                TaskName = taskName,
                TaskDescription = taskDescription,
                TaskStatus = taskStatus
            };

            try
            {
                return _repository.CreateTask(taskToCreate);
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not create task:  due to this error {ex}!");
            }
        }
        public void DeleteTask(int id)
        {
            try
            {
                _repository.DeleteTask(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Could not delete task with id: {id} due to this exception {ex}!");
            }
        }
    }
}