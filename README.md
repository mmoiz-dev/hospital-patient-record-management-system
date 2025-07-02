# Hospital Patient Record Management System

A Windows Forms application for managing hospital patient records, appointments, and medications. Built with C# and .NET, this project demonstrates CRUD operations, database integration, and user-friendly form-based interfaces.

## 🏥 Features

- **Patient Management**: Add, view, edit, and delete patient records.
- **Appointment Scheduling**: Manage appointments for patients with detailed forms.
- **Medication Tracking**: Record and update patient medications.
- **Live Data Updates**: All changes are reflected instantly in the UI.
- **Database Integration**: Uses SQLite with Entity Framework Core for persistent storage.

## 🗂️ Project Structure

```
hospital-patient-record-management-system/
├── HospitalPatientRecords/
│ ├── Data/ # Database context and config
│ ├── Forms/ # Windows Forms for UI
│ ├── Models/ # Patient, Appointment, Medication models
│ ├── Migrations/ # EF Core migrations
│ ├── Program.cs # Application entry point
│ └── HospitalRecords.db # SQLite database
├── HospitalPatientRecords.sln
├── README.md
└── run.bat
```

## 🛠️ Technologies Used

- **C# (.NET 8.0)**: Application logic and UI
- **Windows Forms**: User interface
- **Entity Framework Core**: ORM for database access
- **SQLite**: Local database storage

## 📝 How to Run

1. Open the solution in Visual Studio Code or use the .NET CLI.
2. Build the project: `dotnet build`
3. Run the application: `dotnet run --project HospitalPatientRecords`
4. Use the UI to manage patients, appointments, and medications.

## 📚 What I Learned

- Building desktop applications with Windows Forms
- Implementing CRUD operations with Entity Framework Core
- Designing relational data models
- Handling user input and form validation

## 🤝 Contributing

This project is for learning purposes, but feel free to fork and experiment!

## 📖 Credits

Developed as a learning project for hospital management systems.

---

*Built with ❤️ by Muhammad Moiz*
