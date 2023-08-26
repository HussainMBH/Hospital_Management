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
using System.Configuration;

namespace Hospitalmngmnt
{
    public partial class patientinfo : Form
    {
        public patientinfo()
        {
            InitializeComponent();
            GetPatientinfo();
        }

        int indexRow;
        int selectedRow;

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2EUKE18\SQLEXPRESS;Initial Catalog=healthcare;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            String fname, lname, gender, location, ptype, pid;
            String querry = "INSERT INTO patientinfo (fname, lname, dob, age, gender, contact, location, fapntmnt, ptype, pid) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Text + "','" + comboBox2.Text + "','" + textBox6.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

            DataTable register = new DataTable();
            sda.Fill(register);

            MessageBox.Show("Patient Details Successfully Added");
            GetPatientinfo();

        }

        private void patientinfo_Load(object sender, EventArgs e)
        {
            GetPatientinfo();
        }

        private void GetPatientinfo()
        {
            conn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from patientinfo", conn);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            String fname, lname, gender, location, ptype, pid;
            DataGridViewRow newDataRow = dataGridView1.Rows[selectedRow];
            String querry = "UPDATE patientinfo SET fname = '" + textBox1.Text + "', lname = '" + textBox2.Text + "', dob = '" + dateTimePicker1.Text + "', age = '" + textBox3.Text + "', gender = '" + comboBox1.Text + "', contact = '" + textBox5.Text + "', location = '" + textBox4.Text + "', fapntmnt = '" + dateTimePicker2.Text + "', ptype = '" + comboBox2.Text + "', pid = '" + textBox6.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

            DataTable register = new DataTable();
            sda.Fill(register);

            MessageBox.Show("Patient Details Successfully Updated");
            GetPatientinfo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            dateTimePicker1.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            comboBox1.Text = row.Cells[4].Value.ToString();
            textBox5.Text = row.Cells[5].Value.ToString();
            textBox4.Text = row.Cells[6].Value.ToString();
            dateTimePicker2.Text = row.Cells[7].Value.ToString();
            comboBox2.Text = row.Cells[8].Value.ToString();
            textBox6.Text = row.Cells[9].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String fname;
            String querry = "DELETE FROM patientinfo WHERE fname = '" + textBox1.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

            DataTable register = new DataTable();
            sda.Fill(register);

            MessageBox.Show("Patient Details Successfully Deleted");
            GetPatientinfo();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime time_start = Convert.ToDateTime(dateTimePicker1.Value);
            DateTime time_end = DateTime.Today;
            TimeSpan span = time_end.Subtract(time_start);
            var daysTotal = span.TotalDays;
            var yearsTotal = Math.Truncate(daysTotal / 365);
            textBox3.Text = Convert.ToString(yearsTotal);
        }
    }
}
