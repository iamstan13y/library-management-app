using LMS.Utility;
using System.Data;
using System.Data.SQLite;

namespace LMS
{
    public partial class BooksPage : Form
    {
        public BooksPage()
        {
            InitializeComponent();
        }

        private void BooksPage_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            Db.Command = new SQLiteCommand("SELECT * FROM [Books]", Db.Connection);
            Db.Adapter = new SQLiteDataAdapter(Db.Command);
            DataTable table = new DataTable();
            Db.Adapter.Fill(table);
            dgvBooks.DataSource = table;
        }
    }
}