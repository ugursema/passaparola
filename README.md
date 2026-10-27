# 🧩 Passaparola Game

A Windows Forms word quiz application developed in C# inspired by the popular TV game show Passaparola.

## 📌 About the Project

Passaparola is a desktop trivia application where users answer sequential questions pulled dynamically from a SQL Server database. The game tracks the user's progress, evaluates answers in real-time, updates dynamic score counters (Correct, Incorrect, Blank), and gives visual color feedback based on response accuracy.

The project was developed to practice C# Windows Forms programming, SQL Server data reading with `SqlDataReader`, event handling, and UI state feedback.

## ✨ Features

- **Sequential Question Fetching:** Pulls question texts and correct answers dynamically from the database based on the active question ID.
- **Answer Validation:** Compares user input against stored answers with case-insensitive and whitespace-trimmed evaluation.
- **Real-Time Score Tracking:** Automatically updates live counters for Correct (`Dogru`), Incorrect (`Yanlis`), and Blank (`Bos`) responses.
- **Visual Feedback:** Changes answer button background colors dynamically:
  - 🟢 **Green:** Correct answer
  - 🔴 **Red:** Incorrect answer
  - 🟡 **Yellow:** Left blank / Empty input
- **Game Completion Handling:** Detects when questions run out and notifies the user.
- **Exception Handling:** Wraps database connections in `try-catch` blocks to catch runtime connection errors smoothly.

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET Framework (Windows Forms)
- **Database:** Microsoft SQL Server
- **Data Access:** ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`)

## 🗄️ Database

The application connects to SQL Server (`SU_Project` database) and retrieves questions from the `Sorular` table.

### Table Structure (`Sorular`):

| Column Name | Data Type | Description |
| :--- | :--- | :--- |
| `Id` | `INT` | Question order ID (Primary Key) |
| `SoruMetni` | `NVARCHAR/TEXT` | The question prompt text |
| `Cevap` | `NVARCHAR` | The correct answer string |

**Note:** Update the connection string inside `Form1.cs` (`Data Source=...`) to match your local SQL Server instance before running the project.

## 🚀 Getting Started

1. Clone or download this repository.
2. Open the solution in **Visual Studio**.
3. Create the `SU_Project` database and the `Sorular` table in your local SQL Server.
4. Insert sample question records with incremental `Id` values (1, 2, 3...).
5. Update the connection string in `Form1.cs` to match your SQL Server environment.
6. Build and run the application (`F5`).

## 🎯 Learning Objectives

This project helped practice:

- Managing application state and counters in
