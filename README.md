# 🚗 AutoDetailingStudio

> A car detailing management web application built with ASP.NET Core MVC, allowing customers to explore services, manage vehicles, and book appointments.

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-blue)
![EF Core](https://img.shields.io/badge/Entity_Framework-Core-green)
![SQL Server](https://img.shields.io/badge/Database-SQL_Server-red)

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Features](#features)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Future Improvements](#future-improvements)

---

## 📖 About the Project

**AutoDetailingStudio** is a web application developed as part of the ASP.NET Fundamentals course at SoftUni.

The project provides a platform for managing car detailing services, subscription plans, customer vehicles, and appointments.

The application includes authentication, role-based authorization, CRUD operations, and a layered architecture that separates business logic from the presentation layer.

Some additional features, such as customer subscription management, are planned for future development.

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| C# / .NET 8 | Backend development |
| ASP.NET Core MVC | Web application framework |
| Entity Framework Core | Database operations |
| SQL Server | Relational database |
| ASP.NET Core Identity | Authentication and authorization |
| Razor Views | Server-side rendering |
| Bootstrap / CSS | Responsive user interface |
| LINQ | Data querying |
| Git / GitHub | Version control |

---

## ✅ Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- Microsoft SQL Server
- JetBrains Rider, Visual Studio, or VS Code
- Entity Framework Core CLI tools
- Git

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone <https://github.com/USERNAME/AutoDetailingStudio.git>
cd AutoDetailingStudio
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Configure the database

Ensure SQL Server is running and configure the connection string in `appsettings.json` or `appsettings.Development.json`.

### 4. Apply migrations

```bash
dotnet ef database update --project AutoDetailingStudio.Data --startup-project AutoDetailingStudio.Web
```

### 5. Run the application

```bash
dotnet run --project AutoDetailingStudio.Web
```

Open the localhost address displayed in the terminal.

---

## 📁 Project Structure

```text
AutoDetailingStudio/
│
├── AutoDetailingStudio.Common/
├── AutoDetailingStudio.Data/
├── AutoDetailingStudio.Data.Models/
├── AutoDetailingStudio.Services.Core/
├── AutoDetailingStudio.Services.Data/
├── AutoDetailingStudio.ViewModels/
├── AutoDetailingStudio.Web/
│   ├── Areas/
│   ├── Controllers/
│   ├── Views/
│   ├── wwwroot/
│   └── Program.cs
│
└── AutoDetailingStudio.sln
```

The application follows a layered architecture using services, interfaces, DTOs, and ViewModels to separate responsibilities.

---

## ✨ Features

### Public Features

- Browse available detailing services.
- View service details and prices.
- Browse subscription plans and their details.
- Register and log in using ASP.NET Core Identity.

### Customer Features

- Add, view, edit, and remove personal vehicles.
- Book appointments for available services.
- View personal appointment history and details.
- Cancel pending appointments.

### Administrator Features

- Create, edit, and delete detailing services.
- Activate or deactivate services.
- Manage subscription plans through CRUD operations.
- View customer appointments.
- Change appointment statuses.
- Permanently delete cancelled or completed appointments.

### Technical Features

- Role-based authorization.
- Asynchronous database operations.
- Dependency Injection.
- Entity Framework Core migrations.
- DTO and ViewModel mapping.
- Server-side validation.
- Responsive interface using Bootstrap and custom CSS.

---

## 🔐 Demo Administrator Account

A demonstration administrator account is seeded for local testing.

| Field | Value |
|---|---|
| Email | `admin@autodetailingstudio.com` |
| Password | `AdminTest2026` |
| Role | `Admin` |

These credentials are intended for local testing only and should not be used in production.

---

## 🗄️ Database Setup

The application uses Entity Framework Core with a Code-First approach and Microsoft SQL Server.

Main entities include:

- `User`
- `Car`
- `Service`
- `Subscription`
- `Appointment`
- `UserSubscription`

Database migrations are used to create and update the database schema.

Initial data is seeded for services, subscription plans, and administrator access.

---
                                                                                              
## ⚙️ Configuration 
The application uses `appsettings.json` and `appsettings.Development.json` for configuration.

The main settings include:

- **ConnectionStrings** – SQL Server database connection settings.
- **Logging** – Application logging configuration.
- **Identity** – Authentication and password settings, where configured.

The database connection string must be configured for the local SQL Server instance before running migrations.

> **Security:** Do not commit production passwords, API keys, or other sensitive credentials. Use environment variables or .NET User Secrets for sensitive local settings.
---

## 🤝 Contributing

This project was developed for educational purposes as part of the SoftUni ASP.NET Fundamentals course.

Suggestions and feedback are welcome. Further development may include additional features and improvements.

---

## 📄 License

This project is intended for educational and demonstration purposes. No open-source license has been specified.

---

## 📬 Contact

For questions or feedback, please use the GitHub repository's Issues section.

---

*Built as part of the ASP.NET Fundamentals course at SoftUni.*




Database connections are configured using ASP.NET Core configuration files
