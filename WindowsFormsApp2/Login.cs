using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {

        private readonly string connection_string = @"Data Source = (local)\SQLEXPRESS; Initial Catalog = Судоходство 1.0; Integrated Security = True";
        public static SqlConnection connection;
        public static bool isAdmin = true;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var goodConnection = connection_string.Replace("{{l}}", textBoxLog.Text).Replace("{{p}}", textBoxPass.Text);
            connection = new SqlConnection(goodConnection);
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT is_admin FROM dbo.Юзер where user_name='" + textBoxLog.Text + "'";

                cmd.ExecuteNonQuery();
                if (cmd.ExecuteScalar() == null) MessageBox.Show("Ошибка при подключении к БД");
                else
                {
                    isAdmin = (bool)cmd.ExecuteScalar();
                    this.Hide();
                    Form1 f = new Form1();
                    f.FormClosed += F_FormClosed;
                    f.Show();
                    connection.Close();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при подключении к БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
        }

        private void F_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((sender as Form1).changeAccount) this.Show(); else this.Close();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            textBoxPass.PasswordChar = textBoxPass.PasswordChar == '*' ? (char)0 : '*';
        }
    }
}
