using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class LoginFrom : Form
    {
        SqlConnection sqlConnection;

        public LoginFrom()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string login;
        private int id;
        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пользователь\source\repos\CourseWork\CourseWork\Database2.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            if (label4.Visible)
                label4.Visible = false;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label4.Visible = true;
                label4.Text = "Поля 'Имя' и 'Пароль' должны быть заполнены";
            }
            if (label4.Visible == false && textBox1.Text.Length > 15 || textBox2.Text.Length > 50)
            {
                label4.Visible = true;
                label4.Text = "Неверное имя пользователя или пароль";
            }
            if (label4.Visible == false)
            { 
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Users]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["Login"]) == textBox1.Text && Convert.ToString(sqlReader["Password"]) == computeHash(textBox2.Text))
                    {
                        if (Convert.ToString(sqlReader["Type"]) == "User")
                        {
                            login = Convert.ToString(sqlReader["Login"]);
                            id = Convert.ToInt32(sqlReader["UserId"]);

                                this.Hide();
                                Form4 f4 = new Form4
                                {
                                    Owner = this
                                };
                            f4.ShowDialog();
                        }
                        else
                        {
                            this.Hide();
                            Form3 f3 = new Form3();
                            f3.ShowDialog();
                        }
                    }
                    else
                    {
                        label4.Visible = true;
                        label4.Text = "Неверное имя пользователя или пароль";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }
        }
        private string computeHash(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.Unicode.GetBytes(str));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
        }
        public string GetUserLogin()
        {
            return login;
        }
        public int GetUserId()
        {
            return id;
        }
    }
}
