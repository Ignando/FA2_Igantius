using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Helpers;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }


        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            var timer = NonFunctionalTestLogger.StartTimer();

            // Intentional weak validation for testing purposes
            Student student = new Student
            {
                StudentId = txtStudentId.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Age = int.Parse(txtAge.Text),
                Programme = cmbProgramme.Text
            };

            txtStudentOutput.Text =
                "Student saved successfully!" + Environment.NewLine +
                "Student ID: " + student.StudentId + Environment.NewLine +
                "Full Name: " + student.FullName + Environment.NewLine +
                "Email: " + student.Email + Environment.NewLine +
                "Age: " + student.Age + Environment.NewLine +
                "Programme: " + student.Programme;

            NonFunctionalTestLogger.LogReliability(
                "Save student",
                timer,
                "Completed",
                "StudentIdProvided=" + !string.IsNullOrWhiteSpace(student.StudentId));
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            var timer = NonFunctionalTestLogger.StartTimer();

            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbProgramme.SelectedIndex = -1;
            txtStudentOutput.Clear();
            txtStudentId.Focus();

            NonFunctionalTestLogger.LogReliability("Clear student form", timer, "Completed", "Student form cleared");
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Student Registration to Dashboard", 1, "Back button clicked");
            this.Close();
        }

    }
}
