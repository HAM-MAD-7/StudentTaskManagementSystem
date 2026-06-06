Student Task Management System

Overview

Student Task Management System is a multi-user web application built with ASP.NET Core MVC and MySQL. The system enables users to manage student records efficiently through a secure and user-friendly interface.

The application implements full CRUD (Create, Read, Update, Delete) operations, authentication, authorization, server-side validation, and database integrity checks to ensure accurate and secure data management.

---

Features

User Authentication & Authorization

- Secure user registration and login
- Role-based authorization
- Protected routes and actions
- Session-based user access control

Student Management

- Create new student records
- View student details
- Update existing student information
- Delete student records

Data Validation

- Required field validation
- Email format validation
- Duplicate email prevention
- Duplicate student name prevention
- Server-side and client-side validation

User Interface

- Responsive HTML forms
- Structured data tables
- Clean and professional CSS styling
- User-friendly navigation
- Validation error messages

Database Management

- MySQL database integration
- Entity Framework Core ORM
- Database migrations support
- Secure database connectivity

---

Technology Stack

Backend

- ASP.NET Core MVC
- C#
- Entity Framework Core

Frontend

- HTML5
- CSS3
- Bootstrap

Database

- MySQL

Authentication

- ASP.NET Core Identity

Version Control

- Git
- GitHub

---

Project Architecture

The project follows the MVC (Model-View-Controller) architecture:

Models

Responsible for data structures, validation rules, and database entities.

Views

Provide the user interface using Razor Views, HTML, CSS, and Bootstrap.

Controllers

Handle requests, business logic, and communication between Views and Models.

---

Validation Rules

The system enforces the following validation rules:

- Student Name cannot be empty
- Email cannot be empty
- Email must follow a valid format
- Duplicate student names are not allowed
- Duplicate email addresses are not allowed

These rules help maintain data consistency and prevent duplicate records.

---

Installation

Clone Repository

git clone https://github.com/HAM-MAD-7/StudentTaskManagementSystem.git

Navigate to Project

cd StudentTaskManagementSystem

Restore Packages

dotnet restore

Update Database Connection

Configure your MySQL connection settings through environment variables or application configuration.

Apply Migrations

dotnet ef database update

Run Application

dotnet run

---

Security

- Authentication and authorization implemented
- Protected application endpoints
- Database credentials excluded from source control
- Environment variable support for production deployment
- Validation against duplicate records

---

Future Improvements

- Dashboard analytics
- Student search and filtering
- Pagination
- Audit logging
- Export to Excel/PDF
- Role management
- REST API integration

---

Learning Outcomes

This project demonstrates practical experience with:

- ASP.NET Core MVC
- Entity Framework Core
- MySQL Integration
- Authentication & Authorization
- CRUD Operations
- Validation Techniques
- Git & GitHub
- Clean UI Design
- Secure Configuration Management

---

Live Demo: https://studenttaskmanager.runasp.net

Author

Muhammad Hammad

Student Task Management System was developed as a portfolio project to demonstrate full-stack web development skills using ASP.NET Core MVC and MySQL.
