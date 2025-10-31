# Assignment-Basic-Task-Manager
Backend + Frontend
Run the backend

1. Prerequisites
   - .NET 8 SDK installed (https://dotnet.microsoft.com/download)

2. Project structure
   - TaskManager.API.csproj
   - Program.cs
   - Controllers/TasksController.cs
   - Models/TaskItem.cs
   - Repositories/ITaskRepository.cs
   - Repositories/InMemoryTaskRepository.cs

3. Run
   - From the project folder (where TaskManager.API.csproj lives):
     ```bash
     dotnet restore
     dotnet run
     ```
   - By default the app will run on the Kestrel default port (e.g., https://localhost:7243 or similar). Check console output for the exact URL.

4. Test endpoints (examples)
   - Get all tasks:
     ```bash
     curl https://localhost:7243/api/tasks
     ```
   - Create a task:
     ```bash
     curl -X POST https://localhost:7243/api/tasks -H "Content-Type: application/json" -d '{"description":"Buy milk","isCompleted":false}'
     ```
   - Update a task (toggle complete):
     ```bash
     curl -X PUT https://localhost:7243/api/tasks/{id} -H "Content-Type: application/json" -d '{"id":"{id}","description":"Buy milk","isCompleted":true}'
     ```
   - Delete a task:
     ```bash
     curl -X DELETE https://localhost:7243/api/tasks/{id}
     ```

