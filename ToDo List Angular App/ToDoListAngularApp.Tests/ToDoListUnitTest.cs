using ToDo_List_App.Service;
using System.Threading.Tasks;
using System;
using ToDo_List_App.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDo_List_App.ViewModel;
using System.Threading;
using Xunit;
using static System.Console;

namespace ToDoListAngularApp.Tests
{
    public class ToDoListControllerTest : IDisposable
    {
        private readonly TodoService _todoService;
        protected readonly TodoDbContext _context;
        public ToDoListControllerTest()
        {
            var options = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new TodoDbContext(options);

            _context.Database.EnsureCreated();

            // this.Initialize(_context);

            this._todoService = new TodoService();

        }

         

        [Fact]
        public async Task Add_New_Item_Should_Return_An_Inserted_Id()
        {

            var controller = new ToDoListController(this._todoService);
 
            var result = await controller.AddTodo(new TodoAddViewModel
            {
                WorkTodo = "Item1",
                IsCompleted = false
            }); 
 
            Assert.IsType<OkObjectResult>(result);
            //Assert.That(result, Is.InstanceOf<OkObjectResult>());
 
            //Assert.AreEqual(result, BadRequest());
        }

        //[Fact]
        public async Task Cant_Add_An_Empty_Item()
        {
           await Task.Factory.StartNew( () =>  {
                // TODO 
                WriteLine("TODO");
                }
            );
        }

        //[Fact]
        public async Task Add_New_Item_Should_Return_Integer_Value()
        {

        }

        //[Fact]
        public async Task Add_New_Item_Should_Return_Integer_Value()
        {

        }

        //[Fact]
        public async Task Add_New_Item_Should_Return_Integer_Value()
        {

        }

        //[Fact]
        public async Task Add_New_Item_Should_Return_Integer_Value()
        {

        }

        //[Fact]
        public async Task Add_New_Item_Should_Return_Integer_Value()
        {

        }


        public void Initialize(TodoDbContext context)
        {
            if (context.Todos.Any())
            {
                return;
            }

            
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}