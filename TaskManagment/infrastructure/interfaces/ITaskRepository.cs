using infrastructure.models;

namespace infrastructure.interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAllTasks();
        TaskModel GetTaskById(int id);
        TaskModel CreateTask(TaskModel task);
        TaskModel UpdateTask(TaskModel task);
        void DeleteTask(int id);
        

    }
}