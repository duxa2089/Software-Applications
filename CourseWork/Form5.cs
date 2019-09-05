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

namespace CourseWork
{
    public partial class Form5 : Form
    {
        SqlConnection sqlConnection;

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Form5_Load(object sender, EventArgs e)
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
        }

    }
}
