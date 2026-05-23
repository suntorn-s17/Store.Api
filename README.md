# Store.Api

REST API สำหรับจัดการระบบร้านค้าอย่างง่าย พัฒนาด้วย ASP.NET Core

---

## Features

- JWT Authentication
- Role Authorization
- Global Exception Middleware
- AutoMapper
- Entity Framework Core
- Serilog Logging

---

## Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- JWT
- AutoMapper
- Serilog

---

## Architecture

```text
Client
    ↓
Controllers
    ↓
Services
    ↓
Entity Framework Core
    ↓
SQL Server
```

---

## Installation

Clone repository

```bash
git clone https://github.com/yourusername/Store.Api.git
```

Move to project

```bash
cd Store.Api
```

Restore packages

```bash
dotnet restore
```

Apply migrations

```bash
dotnet ef database update
```

Run project

```bash
dotnet run
```

---

## Environment Setup

Create:

```text
appsettings.Development.json
```

Update the following values:

- ConnectionStrings:DefaultConnection
- Jwt:Key
- Jwt:Issuer
- Jwt:Audience

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  },

  "Jwt": {
    "Key": "YOUR_SECRET_KEY",
    "Issuer": "StoreApi",
    "Audience": "StoreApiUsers"
  },

  "Serilog": {
    "MinimumLevel": {
      "Default": "Information"
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "Logs/log-.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  }
}
```

---

## API Documentation

Run the application and open Swagger:

```text
https://localhost:{port}/swagger
```

Swagger UI provides all endpoints, request bodies, and response schemas.

---

## Project Structure

```text
Store.Api
│
├── Controllers
├── DTOs
├── Entities
├── Exceptions
├── Mapping
├── Migrations
├── Models
├── Services
└── Program.cs
```
