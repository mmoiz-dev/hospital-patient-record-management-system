using System;
using System.Windows.Forms;

namespace HospitalPatientRecords.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnPatientManagement_Click(object sender, EventArgs e)
        {
            using (var form = new PatientForm())
            {
                form.ShowDialog();
            }
        }

        private void BtnAppointmentScheduler_Click(object sender, EventArgs e)
        {
            using (var form = new AppointmentForm())
            {
                form.ShowDialog();
            }
        }

        private void BtnMedicationManagement_Click(object sender, EventArgs e)
        {
            using (var form = new MedicationForm())
            {
                form.ShowDialog();
            }
        }
    }
} 