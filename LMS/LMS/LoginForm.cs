using LMS.Utility;
using System.Data.SQLite;

namespace LMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (Login(txtUsername.Text, txtPassword.Text))
            {
                Dashboard dashboard = new();
                dashboard.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Wrong user credentials!", "Login error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private static bool Login(string Username, string Password)
        {
            try
            {

                Db.Connection.Open();
                Db.Command = new SQLiteCommand("SELECT * FROM [Accounts] WHERE [Username]='" + Username + "' AND [Password]='" + Password + "'", Db.Connection);
                Db.DataReader = Db.Command.ExecuteReader();

                if (Db.DataReader.Read())
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Login error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Db.Connection.Close();
                Db.Command!.Dispose();
            }
        }
    }
}