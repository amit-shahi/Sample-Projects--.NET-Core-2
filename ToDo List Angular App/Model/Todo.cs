using System;
using System.ComponentModel.DataAnnotations;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public string WorkTodo { get; set; }
    public bool IsCompleted {get; set;}
    public DateTime CreatedOn { get; set;}
}