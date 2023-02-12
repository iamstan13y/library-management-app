using LMS.Utility;
using System.Data.SQLite;

namespace LMS
{
    public partial class BookModal : Form
    {
        public BookModal()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            AddBook();

            BooksPage booksPage = new();
            booksPage.Show();
            Close();
        }

        private void AddBook()
        {
            try
            {
                Db.Connection.Open();
                Db.Command = new SQLiteCommand("INSERT INTO [Books] VALUES(@Title,@Category,@Author,@ISBN,@DateAdded,@Price,@Status)", Db.Connection);
                Db.Command.Parameters.AddWithValue("@Title", txtTitle.Text);
                Db.Command.Parameters.AddWithValue("@Category", txtCategory.Text);
                Db.Command.Parameters.AddWithValue("@Author", txtAuthor.Text);
                Db.Command.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                Db.Command.Parameters.AddWithValue("@DateAdded", DateTime.Now.Date.ToString());
                Db.Command.Parameters.AddWithValue("@Price", txtPrice.Text);
                Db.Command.Parameters.AddWithValue("@Status", "AVAILABLE");
                Db.Command.ExecuteNonQuery();

                MessageBox.Show("New book added to library", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Db.Connection.Close();
                Db.Command!.Dispose();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}