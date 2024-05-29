using api.Controllers;
using api.TransferModels;
using api.TransferModels.TaskModelDto;
using infrastructure.repositories;
using Newtonsoft.Json.Bson;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Legacy;
using service.services;

namespace YourTestProjectNamespace
{
    [TestFixture]
    public class TaskRepositoryTests
    {
        private TasksController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new TasksController(new TaskService(new TaskRepository(null!)));
        }

        [Test]
        public void GetAllTasks()
        {
            var result = _controller.GetAllTasks();

            Assert.That(result.MessageToClient, Is.EqualTo("Successfully got all the tasks!"));
        }
        [Test]
        public void GetAllTask_Exception()
        {
            _controller = new TasksController(new TaskService(null!));

            Assert.Throws<Exception>(() => _controller.GetAllTasks());
        }

        [Test]
        public void CreateTask()
        {
            //arrange
            var createTaskDto = new CreateTaskDto
            {
                TaskName = "TestTask",
                TaskDescription = "Test Description!",
                TaskStatus = false
            };

            //act
            var result = _controller.CreateTask(createTaskDto);

            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsInstanceOf<ResponseDto>(result);
            ClassicAssert.AreEqual("Succesfully created new task!", result.MessageToClient);
        }


        [Test]
        public void CreateHistory_Exception()
        {
            //arrange
            var createTaskDto = new CreateTaskDto
            {
                TaskName = "TestTask",
                TaskDescription = "Test Description!",
                TaskStatus = false
            };

            _controller = new TasksController(new TaskService(null!));

            //act and assert
            Assert.Throws<Exception>(() => _controller.CreateTask(createTaskDto));
        }

        [Test]
        public void DeleteTask()
        {
            // Arrange
            int taskId = 1;

            // Act
            var result = _controller.DeleteTask(taskId);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsInstanceOf<ResponseDto>(result);
            ClassicAssert.AreEqual($"Succesfully deleted task with id: {taskId}!", result.MessageToClient);
        }

        [Test]
        public void DeleteTask_Exception()
        {
            // Arrange
            int taskId = 1;

            _controller = new TasksController(new TaskService(null!));

            // Act and Assert
            Assert.Throws<Exception>(() => _controller.DeleteTask(taskId));
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

    }
}
