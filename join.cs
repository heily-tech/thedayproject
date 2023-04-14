using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 로그인
{
    public partial class join : Form //회원가입창
    {
        string constring = "datasource = localhost;port=3306;username=root;password=password";
        public join()
        {
            InitializeComponent();
            textBox_ID.MaxLength = 20;

            textBox_PW.MaxLength = 15;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button_save_Click(object sender, EventArgs e)
        {

            string Query = "insert into login.edata (ID,PW,nicname,name,age) value ('" + this.textBox_ID.Text + "','" + this.textBox_PW.Text + "','" + this.textBox_nicname.Text + "','" + this.textBox_name.Text + "','" + this.textBox_age.Text + "')";

            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("회원가입되었습니다.");
                this.Hide();
                new Form1().Show();

                while (myReader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox_nicname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void join_Load(object sender, EventArgs e)
        {

        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
