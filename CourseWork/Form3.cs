using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;

        public Form3()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e) { }

        private async void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пользователь\source\repos\CourseWork\CourseWork\Database2.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Worker]", sqlConnection);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns[0].HeaderCell.Value = "ID";
            dataGridView1.Columns[1].HeaderCell.Value = "Фамилия";
            dataGridView1.Columns[2].HeaderCell.Value = "Имя";
            dataGridView1.Columns[3].HeaderCell.Value = "Отчество";
            dataGridView1.Columns[4].HeaderCell.Value = "Должность";


            SqlDataAdapter sqlDa1 = new SqlDataAdapter("SELECT * FROM [Product]", sqlConnection);
            DataTable dtbl1 = new DataTable();
            sqlDa1.Fill(dtbl1);
            dataGridView2.DataSource = dtbl1;
            dataGridView2.Columns[0].HeaderCell.Value = "ID";
            dataGridView2.Columns[1].HeaderCell.Value = "Название";
            dataGridView2.Columns[2].HeaderCell.Value = "Производитель";
            dataGridView2.Columns[3].HeaderCell.Value = "Модель";
            dataGridView2.Columns[4].HeaderCell.Value = "Условия починки";

            SqlDataAdapter sqlDa2 = new SqlDataAdapter("SELECT * FROM [Users]", sqlConnection);
            DataTable dtbl2 = new DataTable();
            sqlDa2.Fill(dtbl2);
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = dtbl2;

            SqlDataAdapter sqlDa3 = new SqlDataAdapter("SELECT * FROM [Mission]", sqlConnection);
            DataTable dtbl3 = new DataTable();
            sqlDa3.Fill(dtbl3);
            dataGridView4.DataSource = dtbl3;
            dataGridView4.Columns[0].HeaderCell.Value = "ID";
            dataGridView4.Columns[1].HeaderCell.Value = "Название услуги";
            dataGridView4.Columns[2].HeaderCell.Value = "Дата начала";
            dataGridView4.Columns[3].HeaderCell.Value = "Дата окончания";
            dataGridView4.Columns[4].HeaderCell.Value = "Статус";
            dataGridView4.Columns[5].HeaderCell.Value = "ID пользователя";
            dataGridView4.Columns[6].HeaderCell.Value = "ID продукта";
            dataGridView4.Columns[7].HeaderCell.Value = "ID работника";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Visible == true || textBox2.Visible == true || textBox3.Visible == true || textBox4.Visible == true || textBox5.Visible == true ||
                textBox6.Visible == true || textBox7.Visible == true || textBox8.Visible == true || textBox9.Visible == true || textBox10.Visible == true ||
                label3.Visible == true || label4.Visible == true || label5.Visible == true || label6.Visible == true || label7.Visible == true ||
                label8.Visible == true || label9.Visible == true || label10.Visible == true || label11.Visible == true || label12.Visible == true ||
                label13.Visible == true || label14.Visible == true || label15.Visible == true || button1.Visible == true || button2.Visible == true ||
                button3.Visible == true)
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
            if (comboBox1.Text == "Добавить сотрудника в список")
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                button1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
            }
            else if (comboBox1.Text == "Удалить сотрудника из списка")
            {
                label8.Visible = true;
                label9.Visible = true;
                textBox5.Visible = true;
                button2.Visible = true;
            }
            else if (comboBox1.Text == "Изменить информацию о сотруднике")
            {
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                button3.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label16.Visible || label17.Visible)
            {
                label16.Visible = false;
                label17.Visible = false;
            }

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                label16.Visible = true;
                label16.Text = "Все поля должны быть заполнены";
            }
            if (label16.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,20}");
                if (regex.Matches(textBox4.Text).Count == 0)
                {
                    label16.Visible = true;
                    label16.Text = "Фамилия должна иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label16.Visible == false)
            {
                if (textBox4.Text.Length > 20)
                {
                    label16.Visible = true;
                    label16.Text = "Фамилия должна иметь менее 20 символов";
                }
                if (label16.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{2,20}");
                if (regex.Matches(textBox1.Text).Count == 0)
                {
                    label16.Visible = true;
                    label16.Text = "Имя должно иметь более 1-ой букв и не содержать цифр и латинских символов";
                }
            }
            if (label16.Visible == false)
            {
                if (textBox1.Text.Length > 20)
                {
                    label16.Visible = true;
                    label16.Text = "Имя должно иметь менее 20 символов";
                }
            }
            }
            if (label16.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,20}");
                if (regex.Matches(textBox2.Text).Count == 0)
                {
                    label16.Visible = true;
                    label16.Text = "Отчество должно иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label16.Visible == false)
            {
                if (textBox2.Text.Length > 20)
                {
                    label16.Visible = true;
                    label16.Text = "Отчество должно быть менее 20 символов";
                }
            }
            if (label16.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,70}");
                if (regex.Matches(textBox3.Text).Count == 0)
                {
                    label16.Visible = true;
                    label16.Text = "Описание вакансии должно иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label16.Visible == false)
            {
                if (textBox3.Text.Length > 70)
                {
                    label16.Visible = true;
                    label16.Text = "Описание вакансии должно быть менее 70 символов";
                }
            }
            if (label16.Visible == false)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Worker] (Name, MidName, LastName, Vacancy)VALUES(@Name, @MidName, @LastName, @Vacancy)", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox4.Text);
                command.Parameters.AddWithValue("MidName", textBox1.Text);
                command.Parameters.AddWithValue("LastName", textBox2.Text);
                command.Parameters.AddWithValue("Vacancy", textBox3.Text);
                await command.ExecuteNonQueryAsync();
                update_db();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                label17.Visible = true;
                label17.Text = "Добавление успешно завершено";
            }
            }
        private async void button2_Click(object sender, EventArgs e)
        {
            if (label18.Visible || label19.Visible)
            {
                label18.Visible = false;
                label19.Visible = false;
            }
            if (string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label18.Visible = true;
                label18.Text = "ID сотрудника должен быть заполнен";
            }
            if (label18.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox5.Text).Count == 0)
                {
                    label18.Visible = true;
                    label18.Text = "ID должен быть одним числом";
                }
            }
            if (label18.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (WorkerId) AS maxworkerid FROM [Worker]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox5.Text))
                {
                    label18.Visible = true;
                    label18.Text = "Указанное ID работника превышает максимально существующее";
                }
            }
            if (label18.Visible == false)
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Worker] WHERE [WorkerId]=@WorkerId", sqlConnection);
                command.Parameters.AddWithValue("WorkerId", textBox5.Text);
                await command.ExecuteNonQueryAsync();
                update_db();
                textBox5.Clear();
                label19.Visible = true;
                label19.Text = "Удаление успешно завершено";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label20.Visible || label21.Visible)
            {
                label20.Visible = false;
                label21.Visible = false;
            }
             if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrWhiteSpace(textBox7.Text) ||
                 string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrWhiteSpace(textBox8.Text) ||
                 string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrWhiteSpace(textBox9.Text) ||
                 string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrWhiteSpace(textBox10.Text))
            {
                label20.Visible = true;
                label20.Text = "Поля 'Фамилия','Имя','Отчество' и 'Должность' должны быть заполнены";
            }

            else if (string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                label20.Visible = true;
                label20.Text = "Id должен быть заполнен";
            }
            if (label20.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox6.Text).Count == 0)
                {
                    label20.Visible = true;
                    label20.Text = "ID должен быть одним числом";
                }
            }
            if (label20.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,20}");
                if (regex.Matches(textBox7.Text).Count == 0)
                {
                    label20.Visible = true;
                    label20.Text = "Фамилия должна иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label20.Visible == false)
            {
                if (textBox7.Text.Length > 20)
                {
                    label20.Visible = true;
                    label20.Text = "Фамилия должна иметь менее 20 символов";
                }
                if (label20.Visible == false)
                {
                    Regex regex = new Regex(@"[А-Яа-яЁё]{2,20}");
                    if (regex.Matches(textBox8.Text).Count == 0)
                    {
                        label20.Visible = true;
                        label20.Text = "Имя должно иметь более 1-ой букв и не содержать цифр и латинских символов";
                    }
                }
                if (label20.Visible == false)
                {
                    if (textBox8.Text.Length > 20)
                    {
                        label20.Visible = true;
                        label20.Text = "Имя должно иметь менее 20 символов";
                    }
                }
            }
            if (label20.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,20}");
                if (regex.Matches(textBox9.Text).Count == 0)
                {
                    label20.Visible = true;
                    label20.Text = "Отчество должно иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label20.Visible == false)
            {
                if (textBox9.Text.Length > 20)
                {
                    label20.Visible = true;
                    label20.Text = "Отчество должно быть менее 20 символов";
                }
            }
            if (label20.Visible == false)
            {
                Regex regex = new Regex(@"[А-Яа-яЁё]{1,70}");
                if (regex.Matches(textBox10.Text).Count == 0)
                {
                    label20.Visible = true;
                    label20.Text = "Описание вакансии должно иметь более 1 буквы и не содержать цифр и латинских символов";
                }
            }
            if (label20.Visible == false)
            {
                if (textBox10.Text.Length > 70)
                {
                    label20.Visible = true;
                    label20.Text = "Описание вакансии должно быть менее 70 символов";
                }
            }
            if (label20.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (WorkerId) AS maxworkerid FROM [Worker]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox6.Text))
                {
                    label20.Visible = true;
                    label20.Text = "Указанное ID работника превышает максимально существующее";
                }
            }
            if (label20.Visible == false)
            {
                SqlCommand command = new SqlCommand("UPDATE [Worker] SET [Name]=@Name, [MidName]=@MidName, [LastName]=@LastName, [Vacancy]=@Vacancy WHERE WorkerId=@WorkerId", sqlConnection);
                command.Parameters.AddWithValue("WorkerId", textBox6.Text);
                command.Parameters.AddWithValue("Name", textBox7.Text);
                command.Parameters.AddWithValue("MidName", textBox8.Text);
                command.Parameters.AddWithValue("LastName", textBox9.Text);
                command.Parameters.AddWithValue("Vacancy", textBox10.Text);
                await command.ExecuteNonQueryAsync();
                update_db();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                label21.Visible = true;
                label21.Text = "Изменение успешно завершено";
            }
        }
        public void update_db()
        {
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [Worker]", sqlConnection);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (textBox11.Visible == true || textBox12.Visible == true || textBox13.Visible == true || textBox14.Visible == true || textBox15.Visible == true ||
                textBox16.Visible == true || textBox17.Visible == true || textBox18.Visible == true || textBox19.Visible == true || textBox20.Visible == true ||
                label22.Visible == true || label23.Visible == true || label24.Visible == true || label25.Visible == true || label26.Visible == true ||
                label27.Visible == true || label28.Visible == true || label29.Visible == true || label30.Visible == true || label31.Visible == true ||
                label32.Visible == true || label33.Visible == true || label34.Visible == true || button4.Visible == true || button5.Visible == true ||
                button6.Visible == true)
            {
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                textBox18.Visible = false;
                textBox19.Visible = false;
                textBox20.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
                label36.Visible = false;
                label37.Visible = false;
                label38.Visible = false;
                label39.Visible = false;
                label40.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
            }
            if (comboBox2.Text == "Добавить технику в список")
            {
                label36.Visible = true;
                label37.Visible = true;
                label38.Visible = true;
                label39.Visible = true;
                label40.Visible = true;
                button6.Visible = true;
                textBox17.Visible = true;
                textBox18.Visible = true;
                textBox19.Visible = true;
                textBox20.Visible = true;
            }
            else if (comboBox2.Text == "Удалить технику из списка")
            {
                label34.Visible = true;
                label35.Visible = true;
                textBox16.Visible = true;
                button5.Visible = true;
            }
            else if (comboBox2.Text == "Изменить информацию о технике")
            {
                label28.Visible = true;
                label29.Visible = true;
                label30.Visible = true;
                label31.Visible = true;
                label32.Visible = true;
                label33.Visible = true;
                button4.Visible = true;
                textBox11.Visible = true;
                textBox12.Visible = true;
                textBox13.Visible = true;
                textBox14.Visible = true;
                textBox15.Visible = true;
            }
        }
        private async void button6_Click(object sender, EventArgs e)
        {
            if (label26.Visible || label27.Visible)
            {
                label26.Visible = false;
                label27.Visible = false;
            }

            if (string.IsNullOrEmpty(textBox17.Text) || string.IsNullOrWhiteSpace(textBox17.Text) ||
                string.IsNullOrEmpty(textBox18.Text) || string.IsNullOrWhiteSpace(textBox18.Text) ||
                string.IsNullOrEmpty(textBox19.Text) || string.IsNullOrWhiteSpace(textBox19.Text) ||
                string.IsNullOrEmpty(textBox20.Text) || string.IsNullOrWhiteSpace(textBox20.Text))
            {
                label27.Visible = true;
                label27.Text = "Все поля должны быть заполнены";
            }
            if (label27.Visible == false)
            {
                if (textBox17.Text.Length > 20)
                {
                    label27.Visible = true;
                    label27.Text = "Название должно иметь менее 20 символов";
                }
                if (label27.Visible == false)
                {
                    if (textBox20.Text.Length > 20)
                    {
                        label27.Visible = true;
                        label27.Text = "Имя производителя должно иметь менее 20 символов";
                    }
                }
            }
            if (label27.Visible == false)
            {
                if (textBox19.Text.Length > 30)
                {
                    label27.Visible = true;
                    label27.Text = "Название модели техники должно быть менее 30 символов";
                }
            }
            if (label27.Visible == false)
            {
                if (textBox18.Text.Length > 18)
                {
                    label27.Visible = true;
                    label27.Text = "Заполните строку 'Гарантия' словами 'Только по гарантии' или 'Можно без гарантии'";
                }
            }
            if (label27.Visible == false)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Product] (Name, Firm, Model, Guarantee)VALUES(@Name, @Firm, @Model, @Guarantee)", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox17.Text);
                command.Parameters.AddWithValue("Firm", textBox20.Text);
                command.Parameters.AddWithValue("Model", textBox19.Text);
                command.Parameters.AddWithValue("Guarantee", textBox18.Text);
                await command.ExecuteNonQueryAsync();
                update_db1();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                label26.Visible = true;
                label26.Text = "Добавление успешно завершено";
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (label24.Visible || label25.Visible)
            {
                label24.Visible = false;
                label25.Visible = false;
            }
            if (string.IsNullOrEmpty(textBox16.Text) && string.IsNullOrWhiteSpace(textBox16.Text))
            {
                label25.Visible = true;
                label25.Text = "ID техники должен быть заполнен";
            }
            if (label25.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox16.Text).Count == 0)
                {
                    label25.Visible = true;
                    label25.Text = "ID должен быть одним числом";
                }
            }
            if (label25.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (ProductId) AS maxworkerid FROM [Product]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox16.Text))
                {
                    label25.Visible = true;
                    label25.Text = "Указанное ID превышает максимально существующее";
                }
            }
            if (label25.Visible == false)
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Product] WHERE [ProductId]=@ProductId", sqlConnection);
                command.Parameters.AddWithValue("ProductId", textBox16.Text);
                await command.ExecuteNonQueryAsync();
                update_db1();
                textBox16.Clear();
                label24.Visible = true;
                label24.Text = "Удаление успешно завершено";
            }
        }
        public void update_db1()
        {
            SqlDataAdapter sqlDa1 = new SqlDataAdapter("SELECT * FROM [Product]", sqlConnection);
            DataTable dtbl1 = new DataTable();
            sqlDa1.Fill(dtbl1);
            dataGridView2.DataSource = dtbl1;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (label22.Visible || label23.Visible)
            {
                label22.Visible = false;
                label23.Visible = false;
            }
            if (string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrWhiteSpace(textBox11.Text) ||
                string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrWhiteSpace(textBox12.Text) ||
                string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrWhiteSpace(textBox13.Text) ||
                string.IsNullOrEmpty(textBox14.Text) || string.IsNullOrWhiteSpace(textBox14.Text))
            {
                label23.Visible = true;
                label23.Text = "Поля должны быть заполнены";
            }

            else if (string.IsNullOrEmpty(textBox15.Text) || string.IsNullOrWhiteSpace(textBox15.Text))
            {
                label23.Visible = true;
                label23.Text = "Id должен быть заполнен";
            }
            if (label23.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox15.Text).Count == 0)
                {
                    label23.Visible = true;
                    label23.Text = "ID должен быть одним числом";
                }
            }
            if (label23.Visible == false)
            {
                if (textBox14.Text.Length > 20)
                {
                    label23.Visible = true;
                    label23.Text = "Имя техники должно иметь менее 20 символов";
                }
                if (label23.Visible == false)
                {
                    if (textBox13.Text.Length > 20)
                    {
                        label23.Visible = true;
                        label23.Text = "Производитель техники должен иметь менее 20 символов";
                    }
                }
            }
            if (label23.Visible == false)
            {
                if (textBox12.Text.Length > 30)
                {
                    label23.Visible = true;
                    label23.Text = "Модель должна быть менее 30 символов";
                }
            }
            if (label23.Visible == false)
            {
                if (textBox11.Text.Length > 18)
                {
                    label23.Visible = true;
                    label23.Text = "Заполните строку 'Гарантия' словами 'Только по гарантии' или 'Можно без гарантии'";
                }
            }
            if (label23.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (ProductId) AS maxproductid FROM [Product]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox15.Text))
                {
                    label23.Visible = true;
                    label23.Text = "Указанное ID превышает максимально существующее";
                }
            }
            if (label23.Visible == false)
            {
                SqlCommand command = new SqlCommand("UPDATE [Product] SET [Name]=@Name, [Firm]=@Firm, [Model]=@Model, [Guarantee]=@Guarantee WHERE ProductId=@ProductId", sqlConnection);
                command.Parameters.AddWithValue("ProductId", textBox15.Text);
                command.Parameters.AddWithValue("Name", textBox14.Text);
                command.Parameters.AddWithValue("Firm", textBox13.Text);
                command.Parameters.AddWithValue("Model", textBox12.Text);
                command.Parameters.AddWithValue("Guarantee", textBox11.Text);
                await command.ExecuteNonQueryAsync();
                update_db1();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                label22.Visible = true;
                label22.Text = "Изменение успешно завершено";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox21.Visible == true || textBox22.Visible == true || textBox23.Visible == true || textBox24.Visible == true || textBox25.Visible == true ||
                textBox26.Visible == true || textBox27.Visible == true || textBox28.Visible == true || textBox29.Visible == true || textBox30.Visible == true ||
                textBox31.Visible == true || textBox32.Visible == true || textBox33.Visible == true || textBox34.Visible == true || textBox35.Visible == true ||
                textBox36.Visible == true ||
                label42.Visible == true || label43.Visible == true || label44.Visible == true || label45.Visible == true || label46.Visible == true ||
                label47.Visible == true || label48.Visible == true || label49.Visible == true || label50.Visible == true || label51.Visible == true ||
                label52.Visible == true || label53.Visible == true || label54.Visible == true || label55.Visible == true || label56.Visible == true ||
                label57.Visible == true || label58.Visible == true || label59.Visible == true || label60.Visible == true || button7.Visible == true ||
                button8.Visible == true || button9.Visible == true)
            {
                textBox21.Visible = false;
                textBox22.Visible = false;
                textBox23.Visible = false;
                textBox24.Visible = false;
                textBox25.Visible = false;
                textBox26.Visible = false;
                textBox27.Visible = false;
                textBox28.Visible = false;
                textBox29.Visible = false;
                textBox30.Visible = false;
                textBox31.Visible = false;
                textBox32.Visible = false;
                textBox33.Visible = false;
                textBox34.Visible = false;
                textBox35.Visible = false;
                textBox36.Visible = false;
                label42.Visible = false;
                label43.Visible = false;
                label44.Visible = false;
                label45.Visible = false;
                label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                label49.Visible = false;
                label50.Visible = false;
                label51.Visible = false;
                label52.Visible = false;
                label53.Visible = false;
                label54.Visible = false;
                label55.Visible = false;
                label56.Visible = false;
                label57.Visible = false;
                label58.Visible = false;
                label59.Visible = false;
                label60.Visible = false;
                label61.Visible = false;
                label62.Visible = false;
                label63.Visible = false;
                label64.Visible = false;
                label65.Visible = false;
                label66.Visible = false;
                label67.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
            }
            if (comboBox3.Text == "Добавить заказ в список")
            {
                label56.Visible = true;
                label57.Visible = true;
                label58.Visible = true;
                label59.Visible = true;
                label60.Visible = true;
                label62.Visible = true;
                label63.Visible = true;
                label64.Visible = true;
                button9.Visible = true;
                textBox27.Visible = true;
                textBox28.Visible = true;
                textBox29.Visible = true;
                textBox30.Visible = true;
                textBox31.Visible = true;
                textBox32.Visible = true;
                textBox33.Visible = true;
            }
            else if (comboBox3.Text == "Удалить заказ из списка")
            {
                label54.Visible = true;
                label55.Visible = true;
                textBox26.Visible = true;
                button8.Visible = true;
            }
            else if (comboBox3.Text == "Изменить информацию о заказе")
            {
                label48.Visible = true;
                label49.Visible = true;
                label50.Visible = true;
                label51.Visible = true;
                label65.Visible = true;
                label67.Visible = true;
                label66.Visible = true;
                label52.Visible = true;
                button7.Visible = true;
                textBox34.Visible = true;
                textBox35.Visible = true;
                textBox36.Visible = true;
                textBox21.Visible = true;
                textBox22.Visible = true;
                textBox23.Visible = true;
                textBox24.Visible = true;
                textBox25.Visible = true;
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (label46.Visible || label47.Visible)
            {
                label46.Visible = false;
                label47.Visible = false;
            }

            if (string.IsNullOrEmpty(textBox27.Text) || string.IsNullOrWhiteSpace(textBox27.Text) ||
                string.IsNullOrEmpty(textBox28.Text) || string.IsNullOrWhiteSpace(textBox28.Text) ||
                string.IsNullOrEmpty(textBox29.Text) || string.IsNullOrWhiteSpace(textBox29.Text) ||
                string.IsNullOrEmpty(textBox30.Text) || string.IsNullOrWhiteSpace(textBox30.Text) ||
                string.IsNullOrEmpty(textBox31.Text) || string.IsNullOrWhiteSpace(textBox31.Text) ||
                string.IsNullOrEmpty(textBox32.Text) || string.IsNullOrWhiteSpace(textBox32.Text) ||
                string.IsNullOrEmpty(textBox33.Text) || string.IsNullOrWhiteSpace(textBox33.Text))
            {
                label47.Visible = true;
                label47.Text = "Все поля должны быть заполнены";
            }
            if (label47.Visible == false)
            {
                if (textBox27.Text.Length > 30)
                {
                    label27.Visible = true;
                    label27.Text = "Название услуги должно иметь менее 30 символов";
                }
                if (label47.Visible == false)
                {
                    if (textBox30.Text.Length > 10)
                    {
                        label47.Visible = true;
                        label47.Text = "Дата начала ремонта должна иметь менее 10 символов";
                    }
                }
            }
            if (label47.Visible == false)
            {
                if (textBox29.Text.Length > 10)
                {
                    label47.Visible = true;
                    label47.Text = "Дата конца ремонта должна иметь менее 10 символов";
                }
            }
            if (label47.Visible == false)
            {
                if (textBox28.Text.Length > 100)
                {
                    label47.Visible = true;
                    label47.Text = "Особенности заказа должны быть менее 100 символов";
                }
            }
            if (label47.Visible == false)
            {
                Regex regex = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                if (regex.Matches(textBox30.Text).Count == 0)
                {
                    label47.Visible = true;
                    label47.Text = "Дата начала ремонта задана в неверном формате";
                }
            }
            if (label47.Visible == false)
            {
                Regex regex = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                if (regex.Matches(textBox29.Text).Count == 0)
                {
                    label47.Visible = true;
                    label47.Text = "Дата конца ремонта задана в неверном формате";
                }
            }
            if (label47.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (ProductId) AS maxworkerid FROM [Product]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox33.Text))
                {
                    label47.Visible = true;
                    label47.Text = "Указанное ID товара превышает максимально существующее";
                }
            }
            if (label47.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox33.Text).Count == 0)
                {
                    label47.Visible = true;
                    label47.Text = "ID должен быть одним числом";
                }
            }
            if (label47.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (WorkerId) AS maxworkerid FROM [Worker]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox32.Text))
                {
                    label47.Visible = true;
                    label47.Text = "Указанное ID работника превышает максимально существующее";
                }
            }
            if (label47.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox32.Text).Count == 0)
                {
                    label47.Visible = true;
                    label47.Text = "ID должен быть одним числом";
                }
            }
            if (label47.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (UserId) AS maxworkerid FROM [Users]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox31.Text))
                {
                    label47.Visible = true;
                    label47.Text = "Указанное ID пользователя превышает максимально существующее";
                }
            }
            if (label47.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox31.Text).Count == 0)
                {
                    label47.Visible = true;
                    label47.Text = "ID должен быть одним числом";
                }
            }
            if (label47.Visible == false)
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Mission] (NameOfService, DateOfBeginning, DateOfEnding, Situation, UserID, ProductID, WorkerID)VALUES(@NameOfService, @DateOfBeginning, @DateOfEnding, @Situation, @UserID, @ProductID, @WorkerID)", sqlConnection);
                command.Parameters.AddWithValue("NameOfService", textBox27.Text);
                command.Parameters.AddWithValue("DateOfBeginning", textBox30.Text);
                command.Parameters.AddWithValue("DateOfEnding", textBox29.Text);
                command.Parameters.AddWithValue("Situation", textBox28.Text);
                command.Parameters.AddWithValue("UserID", textBox31.Text);
                command.Parameters.AddWithValue("ProductID", textBox32.Text);
                command.Parameters.AddWithValue("WorkerID", textBox33.Text);
                await command.ExecuteNonQueryAsync();
                update_db2();
                textBox27.Clear();
                textBox28.Clear();
                textBox29.Clear();
                textBox30.Clear();
                textBox31.Clear();
                textBox32.Clear();
                textBox33.Clear();
                label46.Visible = true;
                label46.Text = "Добавление успешно завершено";
            }
        }
        private void update_db2()
        {
            SqlDataAdapter sqlDa3 = new SqlDataAdapter("SELECT * FROM [Mission]", sqlConnection);
            DataTable dtbl3 = new DataTable();
            sqlDa3.Fill(dtbl3);
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (label44.Visible || label45.Visible)
            {
                label44.Visible = false;
                label45.Visible = false;
            }
            if (string.IsNullOrEmpty(textBox26.Text) && string.IsNullOrWhiteSpace(textBox26.Text))
            {
                label45.Visible = true;
                label45.Text = "ID техники должен быть заполнен";
            }
            if (label45.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox26.Text).Count == 0)
                {
                    label45.Visible = true;
                    label45.Text = "ID должен быть одним числом";
                }
            }
            if (label45.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (MissionId) AS maxworkerid FROM [Mission]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox26.Text))
                {
                    label45.Visible = true;
                    label45.Text = "Указанное ID превышает максимально существующее";
                }
            }
            if (label45.Visible == false)
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Mission] WHERE [MissionId]=@MissionId", sqlConnection);
                command.Parameters.AddWithValue("MissionId", textBox26.Text);
                await command.ExecuteNonQueryAsync();
                update_db2();
                textBox26.Clear();
                label44.Visible = true;
                label44.Text = "Удаление успешно завершено";
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (label42.Visible || label43.Visible)
            {
                label42.Visible = false;
                label43.Visible = false;
            }
            if (string.IsNullOrEmpty(textBox21.Text) || string.IsNullOrWhiteSpace(textBox21.Text) ||
                string.IsNullOrEmpty(textBox22.Text) || string.IsNullOrWhiteSpace(textBox22.Text) ||
                string.IsNullOrEmpty(textBox23.Text) || string.IsNullOrWhiteSpace(textBox23.Text) ||
                string.IsNullOrEmpty(textBox24.Text) || string.IsNullOrWhiteSpace(textBox24.Text) ||
                string.IsNullOrEmpty(textBox34.Text) || string.IsNullOrWhiteSpace(textBox34.Text) ||
                string.IsNullOrEmpty(textBox35.Text) || string.IsNullOrWhiteSpace(textBox35.Text) ||
                string.IsNullOrEmpty(textBox35.Text) || string.IsNullOrWhiteSpace(textBox36.Text))
            {
                label43.Visible = true;
                label43.Text = "Поля должны быть заполнены";
            }

            else if (string.IsNullOrEmpty(textBox25.Text) || string.IsNullOrWhiteSpace(textBox25.Text))
            {
                label43.Visible = true;
                label43.Text = "ID должен быть заполнен";
            }
            if (label43.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox25.Text).Count == 0)
                {
                    label43.Visible = true;
                    label43.Text = "ID должен быть одним числом";
                }
            }


            if (label43.Visible == false)
            {
                if (textBox24.Text.Length > 30)
                {
                    label43.Visible = true;
                    label43.Text = "Название услуги должно иметь менее 30 символов";
                }
                if (label43.Visible == false)
                {
                    if (textBox23.Text.Length > 10)
                    {
                        label43.Visible = true;
                        label43.Text = "Дата начала ремонта должна иметь менее 10 символов";
                    }
                }
            }
            if (label43.Visible == false)
            {
                if (textBox22.Text.Length > 10)
                {
                    label43.Visible = true;
                    label43.Text = "Дата конца ремонта должна иметь менее 10 символов";
                }
            }
            if (label43.Visible == false)
            {
                if (textBox21.Text.Length > 100)
                {
                    label43.Visible = true;
                    label43.Text = "Особенности заказа должны быть менее 100 символов";
                }
            }
            if (label43.Visible == false)
            {
                Regex regex = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                if (regex.Matches(textBox23.Text).Count == 0)
                {
                    label43.Visible = true;
                    label43.Text = "Дата начала ремонта задана в неверном формате";
                }
            }
            if (label43.Visible == false)
            {
                Regex regex = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
                if (regex.Matches(textBox22.Text).Count == 0)
                {
                    label43.Visible = true;
                    label43.Text = "Дата конца ремонта задана в неверном формате";
                }
            }
            if (label43.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (ProductId) AS maxworkerid FROM [Product]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox34.Text))
                {
                    label43.Visible = true;
                    label43.Text = "Указанное ID товара превышает максимально существующее";
                }
            }
            if (label43.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox34.Text).Count == 0)
                {
                    label43.Visible = true;
                    label43.Text = "ID должен быть одним числом";
                }
            }
            if (label43.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (WorkerId) AS maxworkerid FROM [Worker]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox35.Text))
                {
                    label43.Visible = true;
                    label43.Text = "Указанное ID работника превышает максимально существующее";
                }
            }
            if (label43.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox35.Text).Count == 0)
                {
                    label43.Visible = true;
                    label43.Text = "ID должен быть одним числом";
                }
            }
            if (label43.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (UserId) AS maxworkerid FROM [Users]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox36.Text))
                {
                    label43.Visible = true;
                    label43.Text = "Указанное ID пользователя превышает максимально существующее";
                }
            }
            if (label43.Visible == false)
            {
                Regex regex = new Regex(@"^[0-9]+$");
                if (regex.Matches(textBox36.Text).Count == 0)
                {
                    label43.Visible = true;
                    label43.Text = "ID должен быть одним числом";
                }
            }

            if (label43.Visible == false)
            {
                SqlCommand command1 = new SqlCommand("SELECT MAX (MissionId) AS maxproductid FROM [Mission]", sqlConnection);
                command1.CommandType = CommandType.Text;
                if (Convert.ToInt32(command1.ExecuteScalar()) < Convert.ToInt32(textBox25.Text))
                {
                    label43.Visible = true;
                    label43.Text = "Указанное ID превышает максимально существующее";
                }
            }
            if (label43.Visible == false)
            {
                SqlCommand command = new SqlCommand("UPDATE [Mission] SET [NameOfService]=@NameOfService, [DateOfBeginning]=@DateOfBeginning, [DateOfEnding]=@DateOfEnding, [Situation]=@Situation, [UserID]=@UserID, [ProductID]=@ProductID, [WorkerID]=@WorkerID WHERE MissionId=@MissionId", sqlConnection);
                command.Parameters.AddWithValue("MissionId", textBox25.Text);
                command.Parameters.AddWithValue("NameOfService", textBox24.Text);
                command.Parameters.AddWithValue("DateOfBeginning", textBox23.Text);
                command.Parameters.AddWithValue("DateOfEnding", textBox22.Text);
                command.Parameters.AddWithValue("Situation", textBox21.Text);
                command.Parameters.AddWithValue("UserID", textBox36.Text);
                command.Parameters.AddWithValue("ProductID", textBox35.Text);
                command.Parameters.AddWithValue("WorkerID", textBox34.Text);
                await command.ExecuteNonQueryAsync();
                update_db2();
                textBox34.Clear();
                textBox35.Clear();
                textBox36.Clear();
                textBox21.Clear();
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                label42.Visible = true;
                label42.Text = "Изменение успешно завершено";
            }
        }
    }
    }
