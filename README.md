# 🐾 PawCare — Veterinary Clinic Management System

[![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?logo=dotnet&logoColor=white)](https://learn.microsoft.com/aspnet/core/mvc/overview)
[![C#](https://img.shields.io/badge/C%23-C%23-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Entity Framework Core](https://img.shields.io/badge/Entity_Framework-Core-512BD4)](https://learn.microsoft.com/ef/core/)
[![SQL Server](https://img.shields.io/badge/Database-SQL_Server-CC2927?logo=microsoftsqlserver&logoColor=white)](https://learn.microsoft.com/sql/sql-server/)
[![Bootstrap](https://img.shields.io/badge/UI-Bootstrap_5-7952B3?logo=bootstrap&logoColor=white)](https://getbootstrap.com/)

## 📖 Overview

**PawCare** is an ASP.NET Core MVC web application for managing pets and veterinary appointments. It gives pet owners one place to maintain their pets' profiles, request appointments, and review appointment information.

The project addresses the need for a simple, organized way to manage pet records and veterinary visits without relying on scattered notes or manual scheduling.

**Repository:** https://github.com/Marinel10/PawCare

## 🎯 Target users and access

| User | Access |
| --- | --- |
| Guest | Public pages; registration and login |
| Authenticated pet owner | Manage their own pets and appointments |

Authorization checks are enforced in application logic: users must not be able to edit another owner's pet or appointment by changing an ID in the URL.



## ✨ Core features

### Pet management
- View pets belonging to the signed-in user.
- Add and edit pet profiles.
- View pet details.
- Soft-delete pets to preserve related records.
- Store information such as name, species, breed, gender, birth date, and image URL.

### Appointment management
- Book an appointment for one of the signed-in user's pets.
- View an appointment list and appointment details.
- Edit eligible appointments.
- Cancel eligible appointments.
- Validate appointment start and end times.
- Prevent access to appointments belonging to other users.

### Authentication
- Register, sign in, and sign out with ASP.NET Core Identity.
- Protect pet and appointment management routes with authorization.

> Feature availability depends on the current branch and implementation. Verify the relevant controllers, services, and views before submission.

## 🛠️ Technology stack

| Layer | Technology |
| --- | --- |
| Backend | C#, ASP.NET Core MVC |
| Data access | Entity Framework Core |
| Database | Microsoft SQL Server / SQL Server LocalDB |
| Authentication | ASP.NET Core Identity |
| Frontend | Razor Views, HTML, CSS, Bootstrap 5 |
| Version control | Git and GitHub |

Check the project's `.csproj` files for the **exact .NET version** and NuGet package versions used in your checkout.

## 🏗️ Project structure

```text
PawCare/
├── PawCareApp/    # Web entry point, controllers, views, configuration
│   ├── Controllers/
│   ├── Views/
│   │   ├── Pets/
│   │   └── Appointments/
│   └── Program.cs
├── PawCare.Data/            # EF Core DbContext and entities
├── PawCare.Services.Core/    # Business services and contracts
├── PawCare.Services.Data/   # Request/response DTOs
├── PawCare.ViewModels/       # MVC input and display models
├──PawCare.GCommon /        # Validation constants and application constatns
└── README.md
```

The MVC controllers handle HTTP requests and map between view models and service DTOs. Services contain business rules and data access logic. Entity Framework Core persists data to SQL Server.

## 🗃️ Data model

The following diagram illustrates the **main relationships** relevant to pet and appointment management. It is a simplified diagram, not a complete representation of every database table.

```mermaid
erDiagram
    IdentityUser ||--o{ Pet : owns
    Species ||--o{ Pet : categorizes
    Breed |o--o{ Pet : describes
    Pet ||--o{ Appointment : has
    Appointment ||--o{ AppointmentProcedure : includes
    Procedure ||--o{ AppointmentProcedure : includes

    IdentityUser {
        string Id PK
    }
    Pet {
        int Id PK
        string OwnerId FK
        string Name
        bool IsDeleted
    }
    Species {
        int Id PK
    }
    Breed {
        int Id PK
    }
    Appointment {
        int Id PK
        int PetId FK
        datetime StartTime
        datetime EndTime
        datetime CreatedOn
        string Reason
        enum Status
    }
    AppointmentProcedure {
        int AppointmentId FK
        int ProcedureId FK
    }
    Procedure {
        int Id PK
        string Name
        string? Description
        decimal Price 
    }
```

For a full UML/entity diagram, [PlantUML](https://plantuml.com/) can also be used. Update the diagram whenever the database schema changes.

## 🚀 Installation and setup

### Prerequisites

- Git
- The .NET SDK version required by the project's `.csproj` files
- SQL Server or SQL Server LocalDB
- Visual Studio with ASP.NET and web development support, or another .NET-compatible IDE
- EF Core CLI tools if running migrations from the terminal

### 1. Clone the repository

```bash
git clone https://github.com/Marinel10/PawCare.git
cd PawCare
```

### 2. Configure the database connection

Keep local connection strings and credentials out of Git.

**Recommended: .NET User Secrets** (run from the web project's directory):

```bash
cd PawCareApp
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\MSSQLLocalDB;Database=PawCareDb;Trusted_Connection=True;TrustServerCertificate=True"
```

The connection string above is an **example for Windows LocalDB**. Replace the server name, database name, and authentication options to match your SQL Server instance. If your application uses a connection-string key other than `DefaultConnection`, use that exact key instead.

Alternatively, use an ignored `appsettings.Development.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb);Database=PawCareDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Ensure `Program.cs` reads the same key through `builder.Configuration.GetConnectionString("DefaultConnection")` (or the name configured by your project).

### 3. Restore dependencies

From the repository root:

```bash
dotnet restore
```

### 4. Apply database migrations

Run the EF Core migrations for the DbContext used by the application. If the project uses `PawCareDbContext` in `PawCare.Data`, a typical command from the repository root is:

```bash
dotnet ef database update --project PawCare.Data --startup-project PawCareApp --context PawCareDbContext
```

If the solution has a separate Identity DbContext or additional migrations, apply those migrations too using the relevant context and migration project. Confirm actual context names in the source code.

### 5. Run the application

```bash
dotnet run --project PawCareApp
```

Open the local HTTPS or HTTP address printed in the terminal. The port depends on your launch settings.

## 🧭 How to use

1. Open the application and register an account, or sign in.
2. Navigate to the pets section and create a pet profile.
3. Open the appointments section and book a visit for your pet.
4. Review the appointment list and open the details page.
5. Edit or cancel an appointment when its status allows the action.

The application must validate ownership on the server, even if action buttons are hidden in the UI.

## 🧪 Build and testing

Build the solution:

```bash
dotnet build
```

If the repository includes automated test projects, run:

```bash
dotnet test
```

### Manual verification checklist

- [ ] Registration and login work.
- [ ] Anonymous users cannot access protected pet/appointment pages.
- [ ] A signed-in user can create, view, and edit their own pets.
- [ ] Soft-deleted pets do not appear in the active pets list.
- [ ] A user can book an appointment only for a pet they own.
- [ ] An appointment cannot end before it starts.
- [ ] A user cannot view or modify another user's appointment by changing its URL ID.
- [ ] Cancelled appointments cannot be edited or cancelled again.
- [ ] Database migrations apply successfully on a clean local database.

These are **verification steps**, not a claim that automated tests already exist or that every check has passed.

## 🔐 Configuration and Git security

Use `.gitignore` for local-only files, build output, and IDE-generated files. Typical entries include:

```gitignore
**/bin/
**/obj/
.vs/
.vscode/
*.user
**/appsettings.Development.json
**/serviceDependencies.local.json
**/secrets.json
```

Do **not** ignore all `appsettings.json` files by default: a safe, non-secret configuration file can be committed. Never commit real database passwords, API keys, or production secrets.

If a secret was previously committed, removing the file from the latest commit does **not** remove it from Git history. Rotate exposed credentials.

## 🌱 Development workflow

Development is organized through feature branches, incremental commits, and GitHub pull requests.

Example workflow:

```bash
git switch main
git pull origin main
git switch -c feature/my-feature
# Make and review changes
git add .
git commit -m "Implement my feature"
git push -u origin feature/my-feature
```

Open a pull request to `main`, review the changes, and merge when ready. Do not commit local secrets or generated build output.

## 🔮 Possible future improvements

- Veterinarian and administrator roles, if required by the final project scope.
- Appointment availability and overlap detection.
- Notifications and reminders.
- Automated unit and integration tests.
- More detailed medical records and procedure history.

These items are **in prograss**, not compleated features.

