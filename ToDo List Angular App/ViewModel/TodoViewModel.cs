using System;
public class TodoAddViewModel
{
    public string WorkTodo { get; set; }
    public bool IsCompleted {get; set;}
    public DateTime CreatedOn { get; set;}
}

public class TodoUpdateViewModel
{
    public string WorkTodo {get; set;}
    public bool IsCompleted { get; set; }
}