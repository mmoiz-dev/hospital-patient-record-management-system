using System;
using System.Collections.Generic;

namespace HospitalPatientRecords.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string ContactNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string MedicationHistory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();

        public string FullName => $"{FirstName} {LastName}";

        public Patient()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            ContactNumber = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            MedicationHistory = string.Empty;
        }
    }
} 