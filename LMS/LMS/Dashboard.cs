using LMS.Utility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SQLite;

namespace LMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void LoadStats(Label label, string status)
        {
            Db.Connection.Open();
            Db.Command = new SQLiteCommand("SELECT COUNT() FROM [Books] WHERE [Status]='"+ status +"'", Db.Connection);
            Db.DataReader = Db.Command.ExecuteReader();

            if (Db.DataReader.Read()) label.Text = Db.DataReader.GetInt32(0).ToString();

            Db.DataReader.Close();
            Db.Connection.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            List<Label> labels = new()
            {
                lblTotalBooks,
                lblBorrowedBooks,
                lblLostBooks
            };

            List<string> statuses = new()
            {
                "AVAILABLE",
                "BORROWED",
                "LOST"
            };

            int i = 0;
            labels.ForEach(label =>
            {
                LoadStats(label, statuses[i]);
                i++;
            });

        }
    }
}