using System;

namespace ToDo_List_App.ViewModel
{
    public class TodoAddViewModel
    {
        public string WorkTodo { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class TodoUpdateViewModel
    {
        public string WorkTodo { get; set; }
        public bool IsCompleted { get; set; }
    }
}