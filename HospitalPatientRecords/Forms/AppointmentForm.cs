using System;
using System.Linq;
using System.Windows.Forms;
using HospitalPatientRecords.Data;
using HospitalPatientRecords.Models;

namespace HospitalPatientRecords.Forms
{
    public partial class AppointmentForm : Form
    {
        private readonly DatabaseContext _context;

        public AppointmentForm()
        {
            InitializeComponent();
            _context = DatabaseContext.Create();
            LoadData();
        }

        private void LoadData()
        {
            var patients = _context.Patients.ToList();
            cmbPatient.DisplayMember = "FullName";
            cmbPatient.ValueMember = "Id";
            cmbPatient.DataSource = patients;

            RefreshAppointments();
        }

        private void RefreshAppointments()
        {
            var selectedDate = calendar.SelectionStart.Date;
            var appointments = _context.Appointments
                .Where(a => a.AppointmentDate.Date == selectedDate)
                .OrderBy(a => a.AppointmentTime)
                .ToList();

            dgvAppointments.DataSource = appointments;
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshAppointments();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedItem == null)
            {
                MessageBox.Show("Please select a patient.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var patientId = ((Patient)cmbPatient.SelectedItem).Id;
            using (var form = new AppointmentDetailsForm(patientId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshAppointments();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to edit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var appointment = (Appointment)dgvAppointments.SelectedRows[0].DataBoundItem;
            using (var form = new AppointmentDetailsForm(appointment))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshAppointments();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var appointment = (Appointment)dgvAppointments.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                RefreshAppointments();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAppointments();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _context.Dispose();
        }
    }
}