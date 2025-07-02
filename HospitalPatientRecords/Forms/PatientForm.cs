using System;
using System.Linq;
using System.Windows.Forms;
using HospitalPatientRecords.Data;
using HospitalPatientRecords.Models;

namespace HospitalPatientRecords.Forms
{
    public partial class PatientForm : Form
    {
        private readonly DatabaseContext _context;

        public PatientForm()
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            LoadPatients();
        }

        private void LoadPatients()
        {
            var patients = _context.Patients.ToList();
            dgvPatients.DataSource = patients;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text.ToLower();
            var patients = _context.Patients
                .Where(p => p.FirstName.ToLower().Contains(searchTerm) ||
                           p.LastName.ToLower().Contains(searchTerm) ||
                           p.ContactNumber.Contains(searchTerm) ||
                           p.Email.ToLower().Contains(searchTerm))
                .ToList();

            dgvPatients.DataSource = patients;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PatientDetailsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPatients();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var patient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;
            using (var form = new PatientDetailsForm(patient))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPatients();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPatients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var patient = (Patient)dgvPatients.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("Are you sure you want to delete this patient? This will also delete all associated appointments and medications.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                LoadPatients();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
} 