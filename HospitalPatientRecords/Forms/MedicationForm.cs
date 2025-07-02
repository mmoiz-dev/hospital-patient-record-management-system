using System;
using System.Linq;
using System.Windows.Forms;
using HospitalPatientRecords.Data;
using HospitalPatientRecords.Models;

namespace HospitalPatientRecords.Forms
{
    public partial class MedicationForm : Form
    {
        private readonly DatabaseContext _context;

        public MedicationForm()
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
        }

        private void MedicationForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            LoadMedications();
        }

        private void LoadPatients()
        {
            var patients = _context.Patients.ToList();
            cmbPatient.DataSource = patients;
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "Id";
        }

        private void LoadMedications()
        {
            if (cmbPatient.SelectedValue != null && cmbPatient.SelectedValue is int patientId)
            {
                var medications = _context.Medications
                    .Where(m => m.PatientId == patientId)
                    .ToList();
                dgvMedications.DataSource = medications;
            }
            else
            {
                dgvMedications.DataSource = null;
            }
        }

        private void CmbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMedications();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedValue != null && cmbPatient.SelectedValue is int patientId)
            {
                using (var form = new MedicationDetailsForm(patientId))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _context.Medications.Add(form.Medication);
                        _context.SaveChanges();
                        LoadMedications();
                    }
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMedications.SelectedRows.Count > 0)
            {
                var medication = (Medication)dgvMedications.SelectedRows[0].DataBoundItem;
                using (var form = new MedicationDetailsForm(medication))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _context.SaveChanges();
                        LoadMedications();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMedications.SelectedRows.Count > 0)
            {
                var medication = (Medication)dgvMedications.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Are you sure you want to delete this medication?", "Confirm Delete",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _context.Medications.Remove(medication);
                    _context.SaveChanges();
                    LoadMedications();
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadMedications();
        }

        private void BtnViewReminders_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedValue != null && cmbPatient.SelectedValue is int patientId)
            {
                var medications = _context.Medications
                    .Where(m => m.PatientId == patientId && m.EndDate >= DateTime.Today)
                    .ToList();

                var message = "Medication Reminders:\n\n";
                foreach (var medication in medications)
                {
                    message += $"{medication.MedicationName} - {medication.Dosage}\n";
                    message += $"Frequency: {medication.Frequency}\n";
                    message += $"End Date: {medication.EndDate?.ToShortDateString()}\n\n";
                }

                MessageBox.Show(message, "Medication Reminders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
} 