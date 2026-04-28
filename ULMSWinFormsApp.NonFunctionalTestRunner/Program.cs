using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp;
using ULMSWinFormsApp.Forms;

namespace ULMSWinFormsApp.NonFunctionalTestRunner
{
    internal static class Program
    {
        private const int WmClose = 0x0010;
        private static readonly BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;

        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            string logFilePath = Path.Combine(AppContext.BaseDirectory, "NonFunctionalTestResults.csv");
            if (File.Exists(logFilePath))
            {
                File.Delete(logFilePath);
            }

            RunSecurityTests();
            RunPerformanceTests();
            RunReliabilityTests();
            RunUsabilityTests();

            Console.WriteLine(logFilePath);
            Console.WriteLine();
            Console.WriteLine(File.ReadAllText(logFilePath));
        }

        private static void RunSecurityTests()
        {
            using FrmLogin login = new FrmLogin();

            for (int i = 1; i <= 3; i++)
            {
                SetText(login, "txtUsername", "invalid" + i);
                SetText(login, "txtPassword", "bad" + i);
                AutoCloseMessageBoxes();
                InvokeHandler(login, "btnLogin_Click");
            }
        }

        private static void RunPerformanceTests()
        {
            using FrmReports reports = new FrmReports();
            SetComboText(reports, "cmbReportType", "Student Summary Report");
            SetText(reports, "txtReportStudentId", "ST1001");
            InvokeHandler(reports, "btnGenerateReport_Click");
        }

        private static void RunReliabilityTests()
        {
            for (int i = 1; i <= 3; i++)
            {
                using FrmStudentRegistration student = new FrmStudentRegistration();
                SetText(student, "txtStudentId", "ST10" + i);
                SetText(student, "txtFullName", "Test Student " + i);
                SetText(student, "txtEmail", "student" + i + "@example.com");
                SetText(student, "txtAge", "20");
                SetComboText(student, "cmbProgramme", "Software Engineering");
                InvokeHandler(student, "btnSaveStudent_Click");
                InvokeHandler(student, "btnClearStudent_Click");

                using FrmCourseEnrollment enrollment = new FrmCourseEnrollment();
                SetText(enrollment, "txtEnrollStudentId", "ST10" + i);
                SetText(enrollment, "txtEnrollStudentName", "Test Student " + i);
                SetComboText(enrollment, "cmbCourse", "Programming 1");
                SetComboText(enrollment, "cmbSemester", "Semester 1");
                InvokeHandler(enrollment, "btnEnroll_Click");
                InvokeHandler(enrollment, "btnClearEnrollment_Click");

                using FrmMarksCapture marks = new FrmMarksCapture();
                SetText(marks, "txtMarkStudentId", "ST10" + i);
                SetText(marks, "txtMarkStudentName", "Test Student " + i);
                SetText(marks, "txtSubject1", "75");
                SetText(marks, "txtSubject2", "80");
                SetText(marks, "txtSubject3", "70");
                InvokeHandler(marks, "btnCalculateResults_Click");
                InvokeHandler(marks, "btnClearMarks_Click");

                using FrmReports reports = new FrmReports();
                InvokeHandler(reports, "btnClearReport_Click");
            }
        }

        private static void RunUsabilityTests()
        {
            using FrmStudentRegistration student = new FrmStudentRegistration();
            InvokeHandler(student, "btnBackToDashboard_Click");

            using FrmCourseEnrollment enrollment = new FrmCourseEnrollment();
            InvokeHandler(enrollment, "btnBackEnrollment_Click");

            using FrmMarksCapture marks = new FrmMarksCapture();
            InvokeHandler(marks, "btnBackMarks_Click");

            using FrmReports reports = new FrmReports();
            InvokeHandler(reports, "btnBackReport_Click");
        }

        private static void InvokeHandler(Form form, string methodName)
        {
            MethodInfo? method = form.GetType().GetMethod(methodName, Flags);
            if (method == null)
            {
                throw new InvalidOperationException("Missing handler: " + form.GetType().Name + "." + methodName);
            }

            method.Invoke(form, new object?[] { form, EventArgs.Empty });
        }

        private static void SetText(Form form, string fieldName, string value)
        {
            TextBox textBox = GetField<TextBox>(form, fieldName);
            textBox.Text = value;
        }

        private static void SetComboText(Form form, string fieldName, string value)
        {
            ComboBox comboBox = GetField<ComboBox>(form, fieldName);
            comboBox.Text = value;
        }

        private static T GetField<T>(Form form, string fieldName) where T : Control
        {
            FieldInfo? field = form.GetType().GetField(fieldName, Flags);
            if (field?.GetValue(form) is not T control)
            {
                throw new InvalidOperationException("Missing field: " + form.GetType().Name + "." + fieldName);
            }

            return control;
        }

        private static void AutoCloseMessageBoxes()
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < 20; i++)
                {
                    await Task.Delay(100);
                    CloseOpenDialogs();
                }
            });
        }

        private static void CloseOpenDialogs()
        {
            EnumWindows((handle, _) =>
            {
                StringBuilder className = new StringBuilder(256);
                GetClassName(handle, className, className.Capacity);
                if (className.ToString() == "#32770")
                {
                    PostMessage(handle, WmClose, IntPtr.Zero, IntPtr.Zero);
                }

                return true;
            }, IntPtr.Zero);
        }

        private delegate bool EnumWindowsProc(IntPtr handle, IntPtr parameter);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc callback, IntPtr parameter);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr handle, StringBuilder className, int maxCount);

        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr handle, int message, IntPtr wParam, IntPtr lParam);
    }
}
