import React from 'react';
import { TaskItem } from '../types';


interface Props {
task: TaskItem;
onToggle: (task: TaskItem) => void;
onDelete: (id: string) => void;
}


const TaskItemRow: React.FC<Props> = ({ task, onToggle, onDelete }) => {
return (
<li className="flex items-center justify-between bg-white p-2 rounded shadow mb-2">
<label className="flex items-center space-x-2">
<input
type="checkbox"
checked={task.isCompleted}
onChange={() => onToggle(task)}
/>
<span className={task.isCompleted ? 'line-through text-gray-500' : ''}>
{task.description}
</span>
</label>
<button
className="bg-red-500 text-white px-2 py-1 rounded hover:bg-red-600"
onClick={() => onDelete(task.id)}
>
Delete
</button>
</li>
);
};


export default TaskItemRow;
