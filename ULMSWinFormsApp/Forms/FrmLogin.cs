using ULMSWinFormsApp.Forms;
using ULMSWinFormsApp.Helpers;

namespace ULMSWinFormsApp
{
    public partial class FrmLogin : Form
    {
        private int invalidLoginAttempts = 0;

        public FrmLogin()
        {
            InitializeComponent();
            Shown += FrmLogin_Shown;
        }

        private void FrmLogin_Shown(object? sender, EventArgs e)
        {
            NonFunctionalTestLogger.LogUsability("Application started at Login form", 1, "Login form visible");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var timer = NonFunctionalTestLogger.StartTimer();
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Intentional faulty validation logic (for testing scenario)
            if (username == "admin" || password == "1234")
            {
                NonFunctionalTestLogger.LogSecurity(
                    "Login attempt",
                    timer,
                    "Accepted",
                    "InvalidAttemptsBeforeSuccess=" + invalidLoginAttempts +
                    "; UsernameProvided=" + !string.IsNullOrWhiteSpace(username) +
                    "; PasswordProvided=" + !string.IsNullOrWhiteSpace(password));

                MessageBox.Show("Login Successful!");

                FrmDashboard dashboard = new FrmDashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                invalidLoginAttempts++;
                NonFunctionalTestLogger.LogSecurity(
                    "Login attempt",
                    timer,
                    "Rejected",
                    "InvalidAttemptCount=" + invalidLoginAttempts);

                string warning = invalidLoginAttempts >= 3
                    ? Environment.NewLine + "Security test note: 3 or more invalid attempts have been recorded."
                    : string.Empty;

                MessageBox.Show("Invalid login credentials." + warning);
            }
        }

        //btnclear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

    }
}
