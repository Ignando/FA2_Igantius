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
    public partial class FrmCourseEnrollment : Form
    {
        public FrmCourseEnrollment()
        {
            InitializeComponent();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            var timer = NonFunctionalTestLogger.StartTimer();

            // Intentional weak business-rule validation for testing purposes
            Enrollment enrollment = new Enrollment
            {
                StudentId = txtEnrollStudentId.Text,
                StudentName = txtEnrollStudentName.Text,
                CourseName = cmbCourse.Text,
                Semester = cmbSemester.Text
            };

            txtEnrollmentOutput.Text =
                "Enrollment completed successfully!" + Environment.NewLine +
                "Student ID: " + enrollment.StudentId + Environment.NewLine +
                "Student Name: " + enrollment.StudentName + Environment.NewLine +
                "Course: " + enrollment.CourseName + Environment.NewLine +
                "Semester: " + enrollment.Semester;

            NonFunctionalTestLogger.LogReliability(
                "Enroll student",
                timer,
                "Completed",
                "StudentIdProvided=" + !string.IsNullOrWhiteSpace(enrollment.StudentId) +
                "; CourseSelected=" + !string.IsNullOrWhiteSpace(enrollment.CourseName));
        }

        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            var timer = NonFunctionalTestLogger.StartTimer();

            txtEnrollStudentId.Clear();
            txtEnrollStudentName.Clear();
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtEnrollmentOutput.Clear();
            txtEnrollStudentId.Focus();

            NonFunctionalTestLogger.LogReliability("Clear enrollment form", timer, "Completed", "Enrollment form cleared");
        }

        private void btnBackEnrollment_Click(object sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Course Enrollment to Dashboard", 1, "Back button clicked");
            this.Close();
        }



    }
}
