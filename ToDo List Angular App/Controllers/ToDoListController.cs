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
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            // Note: If you don't need to return to the calling thread, use .ConfigureAwait(false)
           return await _todoService.GetAll().ConfigureAwait(false);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddTodo([FromBody] TodoAddViewModel todo)
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
 
                return Ok(await _todoService.Add(mappedViewModel).ConfigureAwait(false));
            }
            return BadRequest();
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteTodo(int Id)
        {
            if(Id != 0)
            { 
                return Ok(await _todoService.Delete(Id).ConfigureAwait(false));
            }
            return BadRequest();
        }


        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> UpdateTodo(int Id,[FromBody] TodoUpdateViewModel todo)
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

                return Ok(await _todoService.Update(Id,mappedViewModel).ConfigureAwait(false));
            }
            return BadRequest();
        }

        [HttpPut("[action]/{Id}/{Completed}")]
        public async Task<IActionResult> MarkCompleted(int Id,bool Completed)
        {
            if(Id != 0)
            { 
                return Ok(await _todoService.MarkCompleted(Id, Completed).ConfigureAwait(false));
            }
            return BadRequest();
        }
    }
}