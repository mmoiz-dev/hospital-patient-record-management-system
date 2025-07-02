using System;

namespace HospitalPatientRecords.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public required string AppointmentType { get; set; }
        public required string Notes { get; set; }
        public required string Status { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual Patient Patient { get; set; } = null!;

        public Appointment()
        {
            AppointmentType = string.Empty;
            Notes = string.Empty;
            Status = "Scheduled";
        }
    }
} 