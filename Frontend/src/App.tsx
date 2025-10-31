import React, { useEffect, useState } from 'react';
const handleAdd = async () => {
if (!newTask.trim()) return;
const added = await addTask(newTask);
setTasks(prev => [...prev, added]);
setNewTask('');
};


const handleToggle = async (task: TaskItem) => {
const updated = { ...task, isCompleted: !task.isCompleted };
await updateTask(updated);
setTasks(prev => prev.map(t => (t.id === updated.id ? updated : t)));
};


const handleDelete = async (id: string) => {
await deleteTask(id);
setTasks(prev => prev.filter(t => t.id !== id));
};


return (
<div className="min-h-screen bg-gray-100 flex flex-col items-center p-8">
<h1 className="text-3xl font-bold mb-6">Task Manager</h1>


<div className="flex space-x-2 mb-4">
<input
type="text"
placeholder="Enter a task..."
value={newTask}
onChange={(e) => setNewTask(e.target.value)}
className="border rounded p-2 w-64"
/>
<button
onClick={handleAdd}
className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
>
Add
</button>
</div>


<ul className="w-80">
{tasks.map(task => (
<TaskItemRow
key={task.id}
task={task}
onToggle={handleToggle}
onDelete={handleDelete}
/>
))}
</ul>
</div>
);
};


export default App;
