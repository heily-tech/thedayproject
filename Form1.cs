using System;
using System.Windows.Forms;

namespace theday
{
    public partial class theday : Form
    {
        public theday()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void theday_Load(object sender, EventArgs e)
        {

        }

        private void maxi_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            maxd.Visible = true;
        }
        private void maxd_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            maxd.Visible = false;
            maxi.Visible = true;
        }
        private void mini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

       

       
    }
}
