using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.TransferModels;
using api.TransferModels.TaskModelDto;
using Microsoft.AspNetCore.Mvc;
using service;
using service.services;

namespace api.Controllers
{
    [ApiController]
    public class TasksController : Controller
    {
        private readonly TaskService _service;
        public TasksController(TaskService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route ("/tasks")]
        public ResponseDto GetAllTasks()
        {
            return new ResponseDto()
            {
                MessageToClient = "Successfully got all the tasks!",
                ResponseData = _service.GetAllTasks()
            };
        }

        [HttpPost]
        [Route ("/createTask")]
        public ResponseDto CreateTask([FromBody] CreateTaskDto dto)
        {
            return new ResponseDto()
            {
                MessageToClient = "Succesfully created new task!",
                ResponseData = _service.CreateTask(dto.TaskName, dto.TaskDescription, dto.TaskStatus)
            };

        }

        [HttpDelete]
        [Route ("/deleteTask")]
        public ResponseDto DeleteTask([FromBody] int id)
        {
            _service.DeleteTask(id);

            return new ResponseDto()
            {
                MessageToClient = $"Succesfully deleted task with id: {id}!"
                
            };
        }
    }
}