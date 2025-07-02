namespace HospitalPatientRecords.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPatientManagement = new System.Windows.Forms.Button();
            this.btnAppointmentScheduler = new System.Windows.Forms.Button();
            this.btnMedicationManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPatientManagement
            // 
            this.btnPatientManagement.Location = new System.Drawing.Point(50, 50);
            this.btnPatientManagement.Name = "btnPatientManagement";
            this.btnPatientManagement.Size = new System.Drawing.Size(200, 40);
            this.btnPatientManagement.TabIndex = 0;
            this.btnPatientManagement.Text = "Patient Management";
            this.btnPatientManagement.UseVisualStyleBackColor = true;
            this.btnPatientManagement.Click += new System.EventHandler(this.BtnPatientManagement_Click);
            // 
            // btnAppointmentScheduler
            // 
            this.btnAppointmentScheduler.Location = new System.Drawing.Point(50, 100);
            this.btnAppointmentScheduler.Name = "btnAppointmentScheduler";
            this.btnAppointmentScheduler.Size = new System.Drawing.Size(200, 40);
            this.btnAppointmentScheduler.TabIndex = 1;
            this.btnAppointmentScheduler.Text = "Appointment Scheduler";
            this.btnAppointmentScheduler.UseVisualStyleBackColor = true;
            this.btnAppointmentScheduler.Click += new System.EventHandler(this.BtnAppointmentScheduler_Click);
            // 
            // btnMedicationManagement
            // 
            this.btnMedicationManagement.Location = new System.Drawing.Point(50, 150);
            this.btnMedicationManagement.Name = "btnMedicationManagement";
            this.btnMedicationManagement.Size = new System.Drawing.Size(200, 40);
            this.btnMedicationManagement.TabIndex = 2;
            this.btnMedicationManagement.Text = "Medication Management";
            this.btnMedicationManagement.UseVisualStyleBackColor = true;
            this.btnMedicationManagement.Click += new System.EventHandler(this.BtnMedicationManagement_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btnMedicationManagement);
            this.Controls.Add(this.btnAppointmentScheduler);
            this.Controls.Add(this.btnPatientManagement);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Patient Records System";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnPatientManagement;
        private System.Windows.Forms.Button btnAppointmentScheduler;
        private System.Windows.Forms.Button btnMedicationManagement;
    }
} 