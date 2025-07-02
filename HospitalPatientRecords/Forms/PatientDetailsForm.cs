using System;
using System.Windows.Forms;
using HospitalPatientRecords.Data;
using HospitalPatientRecords.Models;

namespace HospitalPatientRecords.Forms
{
    public partial class PatientDetailsForm : Form
    {
        private readonly DatabaseContext _context;
        public Patient Patient { get; private set; }

        public PatientDetailsForm()
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            Patient = new Patient
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                ContactNumber = string.Empty,
                Email = string.Empty,
                Address = string.Empty,
                MedicationHistory = string.Empty
            };
            LoadPatientData();
        }

        public PatientDetailsForm(Patient patient)
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            Patient = patient;
            LoadPatientData();
        }

        private void LoadPatientData()
        {
            if (Patient.Id > 0)
            {
                txtFirstName.Text = Patient.FirstName;
                txtLastName.Text = Patient.LastName;
                dtpDateOfBirth.Value = Patient.DateOfBirth;
                txtContactNumber.Text = Patient.ContactNumber;
                txtEmail.Text = Patient.Email;
                txtAddress.Text = Patient.Address;
                txtMedicalHistory.Text = Patient.MedicationHistory;
            }
            else
            {
                dtpDateOfBirth.Value = DateTime.Now.AddYears(-18);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Patient.FirstName = txtFirstName.Text;
                Patient.LastName = txtLastName.Text;
                Patient.DateOfBirth = dtpDateOfBirth.Value;
                Patient.ContactNumber = txtContactNumber.Text;
                Patient.Email = txtEmail.Text;
                Patient.Address = txtAddress.Text;
                Patient.MedicationHistory = txtMedicalHistory.Text;

                if (Patient.Id == 0)
                {
                    Patient.CreatedAt = DateTime.Now;
                    _context.Patients.Add(Patient);
                }
                else
                {
                    Patient.UpdatedAt = DateTime.Now;
                }

                _context.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Please enter first name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Please enter contact number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dtpDateOfBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Date of birth cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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