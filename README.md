# Training Record Tracker

A CRUD web application for managing employee training records — create, view,
edit and delete records, with model-level validation and persistent storage.

## Stack
- C# 14 / .NET 10
- ASP.NET Core Razor Pages
- Entity Framework Core (code-first migrations)
- SQLite

## Features
- Full CRUD on training records (employee, course, completion date, score)
- Model-level validation: required fields, string length limits, score range 0–100
- EF Core migrations, so the database schema is versioned in source control
- DbContext registered through dependency injection

## Running locally
```bash
dotnet restore
dotnet ef database update
dotnet run
```
Then open `http://localhost:5216/TrainingRecords`.
