using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using infrastructure.interfaces;
using infrastructure.models;
using Npgsql;

namespace infrastructure.repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public TaskRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }


        public IEnumerable<TaskModel> GetAllTasks()
        {
            using var conn = _dataSource.OpenConnection();

            return conn.Query<TaskModel>(@$"SELECT
            id as {nameof(TaskModel.Id)},
            date_created as {nameof(TaskModel.DateCreated)},
            task as {nameof(TaskModel.TaskName)},
            task_description as {nameof(TaskModel.TaskDescription)},
            task_status as {nameof(TaskModel.TaskStatus)}
            FROM public.tasks;
            ");
        }

        public TaskModel GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
        public TaskModel CreateTask(TaskModel task)
        {
            using var conn = _dataSource.OpenConnection();

            return conn.QueryFirst<TaskModel>($@"INSERT INTO public.tasks
                                            (date_created, task, task_description, task_status)
                                            VALUES (@dateCreated, @taskName, @taskDescription, @taskStatus)
                                            RETURNING *", new {dateCreated = task.DateCreated, taskName = task.TaskName,
                                                            taskDescription = task.TaskDescription, taskStatus = task.TaskStatus});
        }
        public TaskModel UpdateTask(TaskModel task)
        {
            throw new NotImplementedException();
        }
        public void DeleteTask(int id)
        {
            using var conn = _dataSource.OpenConnection();

            conn.Execute($@"DELETE FROM public.tasks WHERE id=@id;", new {id});
        }
    }
}