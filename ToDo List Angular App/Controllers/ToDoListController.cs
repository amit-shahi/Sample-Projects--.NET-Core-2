using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using AutoMapper;

namespace ToDo_List_App.Controllers
{
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private readonly TodoService _todoService;
        private readonly IMapper _mapper;
        public ToDoListController(TodoService todoService, IMapper mapper)
        {
            this._todoService = todoService;
            this._mapper = mapper;
        }

        [HttpGet("[action]")]
        public IEnumerable<Todo> GetTodos()
        {
           return _todoService.GetAll();
        }

        [HttpPost("[action]")]
        public IActionResult AddTodo([FromBody] TodoAddViewModel todo)
        {
            if(todo != null)
            { 
                // NOTE: Used AutoMapper for Object-to-Object mapping instead of old school viewModel 
                // var vm = new Todo  
                // {  
                //     WorkTodo = todo.WorkTodo,
                //     IsCompleted = todo.IsCompleted
                // }; 
                var mappedViewModel = _mapper.Map<Todo>(todo); 
 
                return Ok(_todoService.Add(mappedViewModel));
            }
            return BadRequest();
        }

        [HttpDelete("[action]/{Id}")]
        public IActionResult DeleteTodo(int Id)
        {
            if(Id != 0)
            { 
                return Ok(_todoService.Delete(Id));
            }
            return BadRequest();
        }


        [HttpPut("[action]/{Id}")]
        public IActionResult UpdateTodo(int Id,[FromBody] TodoUpdateViewModel todo)
        {
            if(Id != 0 && todo != null)
            { 
                // NOTE: Used AutoMapper for Object-to-Object mapping instead of old school viewModel 
                // var vm = new Todo  
                // {  
                //     WorkTodo = todo.WorkTodo,
                //     IsCompleted = todo.IsCompleted
                // }; 

                var mappedViewModel = _mapper.Map<Todo>(todo);

                return Ok(_todoService.Update(Id,mappedViewModel));
            }
            return BadRequest();
        }

        [HttpPut("[action]/{Id}/{Completed}")]
        public IActionResult MarkCompleted(int Id,bool Completed)
        {
            if(Id != 0)
            { 
                return Ok(_todoService.MarkCompleted(Id, Completed));
            }
            return BadRequest();
        }
    }
}