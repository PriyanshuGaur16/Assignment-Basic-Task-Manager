using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManager.API.Models;
using TaskManager.API.Repositories;


namespace TaskManager.API.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
private readonly ITaskRepository _repo;
public TasksController(ITaskRepository repo) => _repo = repo;


// GET /api/tasks
[HttpGet]
public ActionResult<IEnumerable<TaskItem>> GetAll() => Ok(_repo.GetAll());


// GET /api/tasks/{id}
[HttpGet("{id}")]
public ActionResult<TaskItem> GetById(Guid id)
{
var item = _repo.Get(id);
if (item == null) return NotFound();
return Ok(item);
}


// POST /api/tasks
[HttpPost]
public ActionResult<TaskItem> Create([FromBody] TaskItem item)
{
// In case client did not send an Id
item.Id = Guid.NewGuid();
_repo.Add(item);
return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
}


// PUT /api/tasks/{id}
[HttpPut("{id}")]
public IActionResult Update(Guid id, [FromBody] TaskItem item)
{
if (id != item.Id) return BadRequest("Id in URL and body must match.");
var updated = _repo.Update(item);
if (!updated) return NotFound();
return NoContent();
}


// DELETE /api/tasks/{id}
[HttpDelete("{id}")]
public IActionResult Delete(Guid id)
{
var deleted = _repo.Delete(id);
if (!deleted) return NotFound();
return NoContent();
}
}
}
