using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Helpers;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Dashboard to Login", 1, "Logout button clicked");

            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }

        private void btnStudentRegistration_Click(object sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Dashboard to Student Registration", 1, "Student registration button clicked");
            MessageBox.Show("Opening registration form...");

            FrmStudentRegistration registrationForm = new FrmStudentRegistration();
            registrationForm.ShowDialog();
        }

        private void btnCourseEnrollment_Click(object sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Dashboard to Course Enrollment", 1, "Course enrollment button clicked");

            FrmCourseEnrollment enrollmentForm = new FrmCourseEnrollment();
            enrollmentForm.ShowDialog();
        }

        private void btnMarksCapture_Click(object sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Dashboard to Marks Capture", 1, "Marks capture button clicked");

            FrmMarksCapture marksForm = new FrmMarksCapture();
            marksForm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Dashboard to Reports", 1, "Reports button clicked");

            FrmReports reportsForm = new FrmReports();
            reportsForm.ShowDialog();
        }
    }
}
