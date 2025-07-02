using System;
using System.Windows.Forms;
using HospitalPatientRecords.Data;
using HospitalPatientRecords.Forms;
using System.Linq;

namespace HospitalPatientRecords
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Initialize database
                DatabaseConfig.InitializeDatabase();

                // Show main form
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}