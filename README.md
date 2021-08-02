# TaskTracker
Project "TaskTracker" was created on ASP.NET Core platform with EF and Web API. The Project stores data in MS SQL DB

There are two cotrollers for two entity in Controller folder:
-TaskController.cs
-ProjectController.cs

These controllers only recive data from the client side and send it to the classes in Model level:
-TaskRepository.cs for Task entity
-ProjectRepository.cs for Project entity

These classes have all businnes logic and send/recive data from the DataContext.cs class, which send/recive it to DB.

Businnes logic classes also use general Priority.cs which contains an enum with values of priority (low,mid,high)

There are also 2 files: TaskStatus.cs and ProjectStatus.cs. They contain an enum for Task and Projects status
