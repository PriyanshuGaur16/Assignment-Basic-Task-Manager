import axios from 'axios';
import { TaskItem } from './types';


const API_BASE = 'https://localhost:7243/api/tasks'; // Adjust port if needed


export const getTasks = async (): Promise<TaskItem[]> => {
const response = await axios.get(API_BASE);
return response.data;
};


export const addTask = async (description: string): Promise<TaskItem> => {
const response = await axios.post(API_BASE, { description, isCompleted: false });
return response.data;
};


export const updateTask = async (task: TaskItem): Promise<void> => {
await axios.put(`${API_BASE}/${task.id}`, task);
};


export const deleteTask = async (id: string): Promise<void> => {
await axios.delete(`${API_BASE}/${id}`);
};
