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

namespace Hospitalmngmnt
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2EUKE18\SQLEXPRESS;Initial Catalog=healthcare;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            String username, position, mailadrs, regpassword, regcpassword;
            username = textBox1.Text;
            position = comboBox1.Text;
            mailadrs = textBox4.Text;
            regcpassword = textBox3.Text;
            regpassword = textBox2.Text;

            String querry = "INSERT INTO register(username, position, mailadrs, password, cpassword) VALUES('" + textBox1.Text + "','" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

            DataTable register = new DataTable();
            sda.Fill(register);

            MessageBox.Show("Registration Successfully Added");

            Form1 logfrm = new Form1();
            this.Hide();
            logfrm.ShowDialog();
        }
    }
}
