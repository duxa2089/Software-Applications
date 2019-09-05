using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginFrom f2 = new LoginFrom();
            f2.ShowDialog();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пользователь\source\repos\CourseWork\CourseWork\Database2.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader sqlReader = null;
            SqlCommand command1 = new SqlCommand("SELECT * FROM [Users]", sqlConnection);
            if (label4.Visible || label5.Visible)
            {
                label4.Visible = false;
                label5.Visible = false;
            }
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                label4.Visible = true;
                    label4.Text = "Все поля должны быть заполнены";
            }
            if (label4.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,20}");
                if (regex.Matches(textBox5.Text).Count == 0)
                {
                    label4.Visible = true;
                    label4.Text = "Фамилия должна иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label4.Visible == false)
            {
                if (textBox5.Text.Length > 20)
                {
                    label4.Visible = true;
                    label4.Text = "Фамилия должна быть менее 20 символов";
                }
            }
            if (label4.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{2,20}");
                if (regex.Matches(textBox4.Text).Count == 0)
                {
                    label4.Visible = true;
                    label4.Text = "Имя должно иметь более 1-ой букв и не содержать цифр и латинских символов";
                }
            }
            if (label4.Visible == false)
            {
                if (textBox4.Text.Length > 20)
                {
                    label4.Visible = true;
                    label4.Text = "Имя должно быть менее 20 символов";
                }
            }
            if (label4.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,20}");
                if (regex.Matches(textBox3.Text).Count == 0)
                {
                    label4.Visible = true;
                    label4.Text = "Отчество должно иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label4.Visible == false)
            {
                if (textBox3.Text.Length > 20)
                {
                    label4.Visible = true;
                    label4.Text = "Отчество должно быть менее 20 символов";
                }
            }
            if (label4.Visible == false)
            {
                Regex regex = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
                if (regex.Matches(textBox6.Text).Count == 0)
                {
                    label4.Visible = true;
                    label4.Text = "Введите номер телефона без букв и в корректном формате";
                }
            }
            if (label4.Visible == false)
            {
                if (textBox6.Text.Length < 11)
                {
                    label4.Visible = true;
                    label4.Text = "Введите номер телефона в корректном формате";
                }
            }
            if (label4.Visible == false)
            {
                Regex regex = new Regex(@"^[aA-zZ0-9_-]{3,16}$");
                if (regex.Matches(textBox1.Text).Count == 0)
                {
                    label4.Visible = true;
                    label4.Text = "Логин должен иметь от 3 до 16 латинских символов и цифр";
                }
            }
            if (label4.Visible == false)
            {
                if (textBox2.Text.Length > 20)
                {
                    label4.Visible = true;
                    label4.Text = "Пароль должен быть меньше 20 символов";
                }
            }
            if (label4.Visible == false)
            {
                try
                {
                    sqlReader = await command1.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        if (Convert.ToString(sqlReader["Login"]) == textBox1.Text)
                        {
                            label4.Visible = true;
                            label4.Text = "Этот логин уже занят, придумайте другой";
                        }
                        if (Convert.ToString(sqlReader["PhoneNumber"]) == textBox6.Text)
                        {
                            label4.Visible = true;
                            label4.Text = "Этот номер телефона уже занят";
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
            if (label4.Visible == false)
            {
                    SqlCommand command = new SqlCommand("INSERT INTO [Users] (Name, MidName, LastName, PhoneNumber, Login, Password, Type) VALUES(@Name, @MidName, @LastName, @PhoneNumber, @Login, @Password, @Type)", sqlConnection);
                    command.Parameters.AddWithValue("Name", textBox4.Text);
                    command.Parameters.AddWithValue("MidName", textBox5.Text);
                    command.Parameters.AddWithValue("LastName", textBox3.Text);
                    command.Parameters.AddWithValue("PhoneNumber", textBox6.Text);
                    command.Parameters.AddWithValue("Login", textBox1.Text);
                    command.Parameters.AddWithValue("Password", computeHash(textBox2.Text));
                    command.Parameters.AddWithValue("Type", "User");
                    await command.ExecuteNonQueryAsync();
                    update_db();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    label5.Visible = true;
                    label5.Text = "Регистрация успешно завершена";
            }
        }
        public async void update_db()
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Users]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync());
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
        private string computeHash(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] checkSum = md5.ComputeHash(Encoding.Unicode.GetBytes(str));
            string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
            return result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }
    }
    }
