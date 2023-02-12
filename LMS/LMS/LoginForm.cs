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

            }
            else
            {
                MessageBox.Show("Wrong user credentials!", "Login error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private bool Login(string Username, string Password)
        {
            try
            {

                Db.Connection.Open();
                Db.Command = new SQLiteCommand("SELECT * FROM [Users] WHERE [Username]='" + Username + "' AND [Password]='" + Password + "'", Db.Connection);
                Db.DataReader = Db.Command.ExecuteReader();

                if (Db.DataReader.Read())
                    return true;
                return false;
            }
            catch
            {
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