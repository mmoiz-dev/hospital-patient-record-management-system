# Hospital Patient Record Management System

A Windows Forms application for managing hospital patient records, appointments, and medications. Built with C# and .NET, this project demonstrates CRUD operations, database integration, and user-friendly form-based interfaces.

## 🏥 Features

- **Patient Management**: Add, view, edit, and delete patient records.
- **Appointment Scheduling**: Manage appointments for patients with detailed forms.
- **Medication Tracking**: Record and update patient medications.
- **Live Data Updates**: All changes are reflected instantly in the UI.
- **Database Integration**: Uses SQLite with Entity Framework Core for persistent storage.

## 🗂️ Project Structure

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


# Hospital Patient Records System

A comprehensive hospital management system built with C# Windows Forms and SQLite.

## Features

### Patient Management
- Store and manage patient information
- Search patients by name or ID
- Update patient records
- View medical history

### Appointment Scheduling
- Visual calendar interface
- Schedule, reschedule, and cancel appointments
- Appointment reminders
- View daily appointments

### Medication Management
- Track patient medications
- Manage dosages and frequencies
- Set medication reminders
- View active prescriptions

## System Requirements

- Windows OS
- .NET 6.0 or later
- SQLite

## Setup Instructions

1. Clone the repository
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Build the solution
5. Run the application

## Database Setup

The system uses SQLite, which is automatically initialized on first run. The database file (HospitalDB.db) will be created in the application directory.

## Usage

1. Start the application
2. Use the main menu to navigate between:
   - Patient Management
   - Appointment Scheduler
   - Medication Management

### Adding a New Patient
1. Click "Patient Management"
2. Click "Add Patient"
3. Fill in the required information
4. Click "Save"

### Scheduling an Appointment
1. Click "Appointment Scheduler"
2. Select a date on the calendar
3. Click "Add Appointment"
4. Select patient and enter appointment details
5. Click "Save"

### Managing Medications
1. Click "Medication Management"
2. Select a patient
3. Click "Add Medication"
4. Enter medication details
5. Click "Save"

## Support

For any issues or questions, please contact the system administrator.

## Running the Project in Visual Studio Code (VS Code)

You can run this project using Visual Studio Code and the .NET CLI, without needing Visual Studio IDE.

### Prerequisites
- **Windows OS**
- **.NET 6.0 SDK or later** (Install from https://dotnet.microsoft.com/download)
- **SQLite** (No manual setup required; the database is created automatically)
- **Visual Studio Code** (Install from https://code.visualstudio.com/)
- **C# Dev Kit** and **.NET Install Tool** extensions for VS Code (recommended)

### Steps

1. **Clone the Repository**
   ```sh
   https://github.com/httpsmojojojo/hospital-record-management-system.git
   ```

2. **Open the Project in VS Code**
   - Launch VS Code.
   - Go to `File > Open Folder...` and select the project folder.

3. **Install Recommended Extensions**
   - When prompted, install the recommended extensions for C# development:
     - **C# Dev Kit** (by Microsoft)
     - **.NET Install Tool** (by Microsoft)
   - You can also search for these in the Extensions sidebar (`Ctrl+Shift+X`).

4. **Restore NuGet Packages**
   - Open the integrated terminal in VS Code (`Ctrl+`` or `View > Terminal`).
   - Run:
     ```sh
     dotnet restore
     ```

5. **Build the Project**
   ```sh
   dotnet build
   ```

6. **Run the Application**
   ```sh
   dotnet run --project HospitalPatientRecords
   ```
   - This will launch the Windows Forms application. You may see a console window as well as the main app window.

7. **Database Setup**
   - The SQLite database file (`HospitalRecords.db`) will be created automatically in the project directory on first run. No manual setup is required.

### Notes
- If you encounter any issues with missing dependencies, ensure the .NET SDK is installed and available in your system PATH.
- For Windows Forms designer support, you may want to use the [Windows Forms Designer for VS Code (Preview)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.vscode-windowsforms-designer), but this is optional.
- All application features (patients, appointments, medications) are accessible from the main menu after launching the app. 
hospital-patient-record-management-system/
├── HospitalPatientRecords/
│ ├── Data/ # Database context and config
│ ├── Forms/ # Windows Forms for UI
│ ├── Models/ # Patient, Appointment, Medication models
│ ├── Migrations/ # EF Core migrations
│ ├── Program.cs # Application entry point
│ ├── HospitalRecords.db # SQLite database
│ └── ...
├── HospitalPatientRecords.sln
├── README.md
└── run.bat
