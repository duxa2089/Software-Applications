using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form4 : Form
    {
        SqlConnection sqlConnection;

        public Form4()
        {
            InitializeComponent();
        }
        private int WorkerID;
        private int ProductID;
        private async void Form4_Load(object sender, EventArgs e)
        {
            var form = Owner as LoginFrom;
            string login = form.GetUserLogin();
            int id = form.GetUserId();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Пользователь\source\repos\CourseWork\CourseWork\Database2.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Users]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToString(sqlReader["Login"]) == login)
                    {
                        listBox1.Items.Add("Фамилия:  " + Convert.ToString(sqlReader["Name"]));
                        listBox1.Items.Add("Имя:  " + Convert.ToString(sqlReader["MidName"]));
                        listBox1.Items.Add("Отчество:  " + Convert.ToString(sqlReader["LastName"]));
                        listBox1.Items.Add("Номер телефона:  " + Convert.ToString(sqlReader["PhoneNumber"]));
                        listBox1.Items.Add("Логин:  " + Convert.ToString(sqlReader["Login"]));
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

            SqlCommand command1 = new SqlCommand("SELECT * FROM [Mission]", sqlConnection);
            try
            {
                sqlReader = await command1.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToInt32(sqlReader["UserID"]) == id)
                    {
                       WorkerID = Convert.ToInt32(sqlReader["WorkerID"]);
                       ProductID = Convert.ToInt32(sqlReader["ProductID"]);
                        listBox2.Items.Add(Convert.ToString(sqlReader["NameOfService"]) + "      " + Convert.ToString(sqlReader["DateOfBeginning"]) + "        " + Convert.ToString(sqlReader["DateOfEnding"]) + "        " + Convert.ToString(sqlReader["Situation"]));
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
            SqlCommand command2 = new SqlCommand("SELECT * FROM [Worker]", sqlConnection);
            try
            {
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToInt32(sqlReader["WorkerId"]) == WorkerID)
                    {
                        listBox2.Items.Add(Convert.ToString(sqlReader["Name"]) + "      " + Convert.ToString(sqlReader["MidName"]) + "        " + Convert.ToString(sqlReader["LastName"]) + "        " + Convert.ToString(sqlReader["Vacancy"]));
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
            SqlCommand command3 = new SqlCommand("SELECT * FROM [Product]", sqlConnection);
            try
            {
                sqlReader = await command3.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    if (Convert.ToInt32(sqlReader["ProductId"]) == ProductID)
                    {
                        listBox2.Items.Add(Convert.ToString(sqlReader["Name"]) + "      " + Convert.ToString(sqlReader["Firm"]) + "        " + Convert.ToString(sqlReader["Model"]) + "        " + Convert.ToString(sqlReader["Guarantee"]));
                        listBox2.Items.Add("_____________________________________________________________________________________________________________");
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
}
