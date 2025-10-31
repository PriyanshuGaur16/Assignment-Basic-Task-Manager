using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TaskManager.API.Models;


namespace TaskManager.API.Repositories
{
// Simple thread-safe in-memory storage using a List + lock
public class InMemoryTaskRepository : ITaskRepository
{
private readonly List<TaskItem> _items = new();
private readonly ReaderWriterLockSlim _lock = new();


public IEnumerable<TaskItem> GetAll()
{
_lock.EnterReadLock();
try { return _items.Select(i => new TaskItem { Id = i.Id, Description = i.Description, isCompleted = i.isCompleted }).ToList(); }
finally { _lock.ExitReadLock(); }
}


public TaskItem? Get(Guid id)
{
_lock.EnterReadLock();
try { return _items.FirstOrDefault(i => i.Id == id); }
finally { _lock.ExitReadLock(); }
}


public void Add(TaskItem item)
{
_lock.EnterWriteLock();
try { _items.Add(item); }
finally { _lock.ExitWriteLock(); }
}


public bool Update(TaskItem item)
{
_lock.EnterUpgradeableReadLock();
try
{
var existing = _items.FirstOrDefault(i => i.Id == item.Id);
if (existing == null) return false;


_lock.EnterWriteLock();
try
{
existing.Description = item.Description;
}
