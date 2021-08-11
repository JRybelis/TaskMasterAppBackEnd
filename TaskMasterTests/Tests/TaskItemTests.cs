using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using TaskMasterApp.Controllers;
using TaskMasterApp.Data;
using TaskMasterApp.Interfaces;
using TaskMasterApp.Mappings;
using TaskmasterCore.Dtos;
using TaskmasterCore.Models;
using Xunit;

namespace TaskMasterTests.Tests
{
    public class TaskItemTests
    {
        [Fact]
        public async Task ControllerGetsAllTasks()
        {
            //Arrange

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingsProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var autoFixture = new Fixture();
            var taskItem = autoFixture.Build<TaskItem>().With(ti => ti.Day, "Weekend").Create();

            var repository = new Mock<IRepository>();
            repository.Setup(r => r.GetAll()).ReturnsAsync(new List<TaskItem>()
            {
                new TaskItem()
                {
                    Reminder = true
                }
            });

            var tasksController = new TasksController(mapper, repository.Object);
            var taskItemDto = new TaskItemDto()
            {
                Text = "Some random task text",
                Day = "Weekday",
                Reminder = false
            };

            //Arrange end
            //Act

            await tasksController.Post(taskItemDto);
            var results = await tasksController.GetAll();

            //Assert
            results.Should().NotBeEmpty();
        }

        public static DbContextOptions<DataContext> GetInMemoryDbContextOptions(string dbName = "TestDb")
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return options;
        }
    }
}
