using System;
using System.Windows.Forms;
using HospitalPatientRecords.Data;
using HospitalPatientRecords.Models;
using System.Linq;

namespace HospitalPatientRecords.Forms
{
    public partial class MedicationDetailsForm : Form
    {
        private readonly DatabaseContext _context;
        public Medication Medication { get; private set; }

        public MedicationDetailsForm(int patientId)
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            // Populate patient ComboBox
            var patients = _context.Patients.ToList();
            cmbPatient.DataSource = patients;
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "Id";
            // Set selected patient
            cmbPatient.SelectedValue = patientId;
            Medication = new Medication
            {
                Id = 0,
                PatientId = patientId,
                MedicationName = string.Empty,
                Dosage = string.Empty,
                Frequency = string.Empty,
                PrescribedBy = string.Empty,
                Notes = string.Empty
            };
            LoadMedicationData();
        }

        public MedicationDetailsForm(Medication medication)
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            // Populate patient ComboBox
            var patients = _context.Patients.ToList();
            cmbPatient.DataSource = patients;
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "Id";
            // Set selected patient
            cmbPatient.SelectedValue = medication.PatientId;
            Medication = medication;
            LoadMedicationData();
        }

        private void LoadMedicationData()
        {
            if (Medication.Id > 0)
            {
                txtMedicationName.Text = Medication.MedicationName;
                txtDosage.Text = Medication.Dosage;
                txtFrequency.Text = Medication.Frequency;
                dtpStartDate.Value = Medication.StartDate;
                dtpEndDate.Value = Medication.EndDate ?? DateTime.Now.AddMonths(1);
                txtPrescribedBy.Text = Medication.PrescribedBy;
                txtNotes.Text = Medication.Notes;
            }
            else
            {
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Now.AddMonths(1);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Medication.MedicationName = txtMedicationName.Text;
                Medication.Dosage = txtDosage.Text;
                Medication.Frequency = txtFrequency.Text;
                Medication.StartDate = dtpStartDate.Value;
                Medication.EndDate = dtpEndDate.Value;
                Medication.PrescribedBy = txtPrescribedBy.Text;
                Medication.Notes = txtNotes.Text;
                // Update PatientId from ComboBox
                if (cmbPatient.SelectedValue is int selectedPatientId)
                {
                    Medication.PatientId = selectedPatientId;
                }
                // Prevent EF Core tracking conflict
                Medication.Patient = null;
                if (Medication.Id == 0)
                {
                    Medication.CreatedAt = DateTime.Now;
                    _context.Medications.Add(Medication);
                }
                else
                {
                    Medication.UpdatedAt = DateTime.Now;
                    _context.Medications.Update(Medication);
                }
                _context.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMedicationName.Text))
            {
                MessageBox.Show("Please enter medication name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDosage.Text))
            {
                MessageBox.Show("Please enter dosage.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFrequency.Text))
            {
                MessageBox.Show("Please enter frequency.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrescribedBy.Text))
            {
                MessageBox.Show("Please enter who prescribed the medication.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpEndDate.Value < dtpStartDate.Value)
            {
                MessageBox.Show("End date cannot be earlier than start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
} 