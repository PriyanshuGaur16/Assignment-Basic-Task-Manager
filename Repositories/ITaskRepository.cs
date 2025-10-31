using System;
using System.Collections.Generic;
using TaskManager.API.Models;


namespace TaskManager.API.Repositories
{
public interface ITaskRepository
{
IEnumerable<TaskItem> GetAll();
TaskItem? Get(Guid id);
void Add(TaskItem item);
bool Update(TaskItem item);
bool Delete(Guid id);
}
}
