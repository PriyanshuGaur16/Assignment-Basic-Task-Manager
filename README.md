# Assignment-Basic-Task-Manager
Backend + Frontend

A simple full-stack **Task Manager** application built using **.NET 8 (C#)** for the backend and **React + TypeScript** for the frontend.  
This project demonstrates essential full-stack development skills such as REST API design, state management, and frontend-backend integration.

---

## 🎯 Objective

The goal of this project is to create a basic task management system that allows users to:
- View all tasks
- Add a new task
- Mark a task as completed or uncompleted
- Delete a task

This project uses **in-memory storage** — meaning data resets when the backend restarts (no database integration yet).

---

## 🏗️ Tech Stack

### 🔹 Backend
- **Language:** C#  
- **Framework:** .NET 8 Web API  
- **Storage:** In-memory list  
- **Pattern:** RESTful API

### 🔹 Frontend
- **Language:** TypeScript  
- **Library:** React  
- **Styling:** Tailwind CSS 
- **HTTP Client:** Axios  

---

## ⚙️ Features

| Feature | Description |
|----------|-------------|
| ➕ Add Task | Add a new task with a description |
| ✅ Toggle Status | Mark a task as completed/uncompleted |
| 🗑️ Delete Task | Remove a task from the list |
| 📋 View Tasks | See all tasks fetched from backend |
| ⚡ Live Sync | Updates instantly via REST API |

---

## 📂 Project Structure

```
TaskManager/
│
├── backend/
│   ├── Controllers/
│   │   └── TasksController.cs
│   ├── Models/
│   │   └── TaskItem.cs
│   ├── Repositories/
│   │   ├── ITaskRepository.cs
│   │   └── InMemoryTaskRepository.cs
│   ├── Program.cs
│   └── TaskManager.API.csproj
│
└── frontend/
    ├── src/
    │   ├── api.ts
    │   ├── types.ts
    │   ├── App.tsx
    │   ├── TaskItemRow.tsx
    │   └── index.css
    ├── package.json
    └── tsconfig.json
```

---

## 🚀 Setup & Run Instructions

### 🧩 1. Run Backend (C# .NET 8)
```bash
cd backend
dotnet run
```
By default, the backend runs on:
```
https://localhost:7243
```

**Test API endpoints**  
```bash
GET     /api/tasks
POST    /api/tasks
PUT     /api/tasks/{id}
DELETE  /api/tasks/{id}
```

Example using `curl`:
```bash
curl -X POST https://localhost:7243/api/tasks      -H "Content-Type: application/json"      -d '{"description":"Learn .NET","isCompleted":false}'
```

---

### 🖥️ 2. Run Frontend (React + TypeScript)
```bash
cd frontend
npm install
npm start
```
Runs on:
```
http://localhost:5173
```
(If using Create React App: http://localhost:3000)

---

### 🌐 3. Configure CORS (if needed)
Ensure your backend allows requests from the frontend:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

app.UseCors("AllowFrontend");
```

---


