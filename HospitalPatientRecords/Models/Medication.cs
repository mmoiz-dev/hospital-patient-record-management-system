using System;

namespace HospitalPatientRecords.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public required string MedicationName { get; set; }
        public required string Dosage { get; set; }
        public required string Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required string PrescribedBy { get; set; }
        public required string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual Patient Patient { get; set; } = null!;
    }
} 