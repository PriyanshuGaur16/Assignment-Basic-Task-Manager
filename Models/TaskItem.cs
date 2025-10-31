using System;


namespace TaskManager.API.Models
{
public class TaskItem
{
public Guid Id { get; set; }
public string Description { get; set; } = string.Empty;
public bool isCompleted { get; set; }
}
}
