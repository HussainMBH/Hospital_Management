using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospitalmngmnt
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new patientinfo());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new patientrecords());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new doctorinfo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new apointments());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadform(new medication());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadform(new roomtheatre());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadform(new viewresource());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadform(new billingservice());
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
