using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 로그인
{
    public partial class mypage : Form
    {
        Form1 f1;
        string myConnection = "datasource = localhost;port=3306;username=root;password=password";
        public mypage()
        {
            InitializeComponent();
        }
        public mypage(Form1 frm2)
        {
            InitializeComponent();
            this.f1 = frm2;
        }

        private void button_update_Click(object sender, EventArgs e)
        {


            string Query = "update login.edata set PW = '" + this.textBox_newPW.Text + "',nicname = '" + this.textBox_newNicname.Text + "',name ='" + this.textBox_newName.Text + "' where ID = '" + this.label_ID2.Text + "';";

            MySqlConnection conDataBase = new MySqlConnection(myConnection);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);

            MySqlDataReader myReader;

            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("수정되었습니다.");
                this.Hide();
                new MainForm(f1).Show();

                while (myReader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainForm(f1).Show();
        }

        private void label_ID2_Click(object sender, EventArgs e)
        {

        }

        private void mypage_Load(object sender, EventArgs e)
        {


            MySqlConnection myConn = new MySqlConnection(myConnection); // mysql 연결 기능

            //아이디 비밀번호 입력
            MySqlCommand selectCommand = new MySqlCommand("select ID from login.edata where ID='" + f1.textBox_ID.Text + "'", myConn);


            try
            {
                myConn.Open(); // mysql 연결


                String Id = (String)selectCommand.ExecuteScalar();
                label_ID2.Text = Id;

                myConn.Close(); //mysql 연결해제

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("회원탈퇴 하시겠습니까?", "회원탈퇴", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Query = "delete from login.edata where ID='" + f1.textBox_ID.Text + "';";

                MySqlConnection conDataBase = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);

                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("탈퇴했습니다.");
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
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
