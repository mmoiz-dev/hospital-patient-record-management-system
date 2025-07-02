using System;
using System.Windows.Forms;
using HospitalPatientRecords.Data;
using HospitalPatientRecords.Models;

namespace HospitalPatientRecords.Forms
{
    public partial class AppointmentDetailsForm : Form
    {
        private readonly DatabaseContext _context;
        public Appointment Appointment { get; private set; }

        public AppointmentDetailsForm(int patientId)
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            cmbPatient.DataSource = _context.Patients.ToList();
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "Id";
            Appointment = new Appointment
            {
                PatientId = patientId,
                AppointmentType = string.Empty,
                Notes = string.Empty,
                Status = "Scheduled"
            };
            cmbPatient.SelectedValue = patientId;
            LoadAppointmentData();
        }

        public AppointmentDetailsForm(Appointment appointment)
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            cmbPatient.DataSource = _context.Patients.ToList();
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "Id";
            Appointment = appointment;
            cmbPatient.SelectedValue = appointment.PatientId;
            LoadAppointmentData();
        }

        private void LoadAppointmentData()
        {
            if (Appointment.Id > 0)
            {
                dtpDate.Value = Appointment.AppointmentDate;
                dtpTime.Value = Appointment.AppointmentTime;
                txtAppointmentType.Text = Appointment.AppointmentType;
                txtNotes.Text = Appointment.Notes;
                cmbStatus.SelectedItem = Appointment.Status;
            }
            else
            {
                dtpDate.Value = DateTime.Today;
                dtpTime.Value = DateTime.Now;
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Appointment.AppointmentDate = dtpDate.Value.Date;
                Appointment.AppointmentTime = dtpTime.Value;
                Appointment.AppointmentType = txtAppointmentType.Text;
                Appointment.Notes = txtNotes.Text;
                Appointment.Status = cmbStatus.SelectedItem?.ToString() ?? "Scheduled";

                if (Appointment.Id == 0)
                {
                    Appointment.CreatedAt = DateTime.Now;
                    _context.Appointments.Add(Appointment);
                }
                else
                {
                    Appointment.UpdatedAt = DateTime.Now;
                }

                _context.SaveChanges();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtAppointmentType.Text))
            {
                MessageBox.Show("Please enter appointment type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select appointment status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var appointmentDateTime = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            if (appointmentDateTime < DateTime.Now)
            {
                MessageBox.Show("Appointment date and time cannot be in the past.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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