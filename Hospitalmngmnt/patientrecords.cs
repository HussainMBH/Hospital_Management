using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospitalmngmnt
{
    public partial class patientrecords : Form
    {
        public patientrecords()
        {
            InitializeComponent();
            GetPatientrecords();
        }

        int indexRow;
        int selectedRow;

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2EUKE18\SQLEXPRESS;Initial Catalog=healthcare;Integrated Security=True");

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String pid, dname, pdiagno, lresult, treatment;
            String querry = "INSERT INTO patientrecords (pid, dname, pdiagno, lresult, treatment) VALUES ('" + textBox6.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox1.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

            DataTable register = new DataTable();
            sda.Fill(register);

            MessageBox.Show("Patient Records Successfully Added");
            GetPatientrecords();
        }
        private void patientrecords_Load(object sender, EventArgs e)
        {
            GetPatientrecords();
        }

        private void GetPatientrecords()
        {
            conn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from patientrecords", conn);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();



        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            textBox6.Text = row.Cells[0].Value.ToString();
            label14.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox5.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox1.Text = row.Cells[4].Value.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void patientrecords_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String pid, dname, pdiagno, lresult, treatment;
            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
            String querry = "UPDATE patientrecords SET pid ='" + textBox6.Text + "', dname = '" + textBox2.Text + "', pdiagno = '" + textBox5.Text + "', lresult = '" + textBox4.Text + "', treatment = '" + textBox1.Text + "'";
            String querry1 = "UPDATE patientinfo SET pid ='" + textBox6.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);
            SqlDataAdapter sda1 = new SqlDataAdapter(querry1, conn);

            DataTable register = new DataTable();
            sda.Fill(register);
            sda1.Fill(register);

            MessageBox.Show("Patient Records Successfully Updated");
            GetPatientrecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String pid, dname, pdiagno, lresult, treatment;
            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
            String querry = "DELETE FROM patientrecords WHERE pid ='" + textBox6.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

            DataTable register = new DataTable();
            sda.Fill(register);

            MessageBox.Show("Patient Records Successfully Deleted");
            GetPatientrecords();
        }

        private void searchData(string valueToFind)
        {
            string searchQuery = "SELECT * FROM patientinfo WHERE CONCAT(pid) LIKE '%"+valueToFind+"%' ";
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, conn);
            DataTable register = new DataTable();
            sda.Fill(register);
        }

    }
}
