using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 로그인
{

    public partial class Form1 : Form //로그인창
    {

        public Form1()
        {
            InitializeComponent();
            textBox_PW.PasswordChar = '●';
            textBox_PW.MaxLength = 15;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm(this);
            mypage mypage = new mypage(this);
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=password"; // mysql 정보
                MySqlConnection myConn = new MySqlConnection(myConnection); // mysql 연결 기능
                MySqlCommand resetday = new MySqlCommand("update login.event SET day = datediff(current_date(), endDay) where ID = '" + this.textBox_ID.Text + "'", myConn);
                //아이디 비밀번호 입력
                MySqlCommand selectCommand = new MySqlCommand("select * from login.edata where ID='" + this.textBox_ID.Text + "'and PW = '" + this.textBox_PW.Text + "'", myConn);

                MySqlDataReader myReader;
                myConn.Open(); // mysql 연결
                myReader = selectCommand.ExecuteReader(); //아이디 비밀번호 입력한것을 읽어온다. 중복사용불가

                int count = 0;

                while (myReader.Read()) // mysql과 입력 ID, 비밀번호를 비교?한다
                {
                    count = count + 1;
                }
                myReader.Close();
                selectCommand.CommandText = "select nicname from login.edata where ID='" + this.textBox_ID.Text + "'";

                String nicname = (String)selectCommand.ExecuteScalar();
                if (count == 1)
                {
                    MessageBox.Show("아이디와 비밀번호가 일치합니다.");
                    this.Hide();
                    resetday.ExecuteReader();
                    MessageBox.Show(nicname + "님 환영합니다.");
                    new MainForm(this).Show();
                }
                else
                {
                    MessageBox.Show("아이디와 비밀번호가 일치하지 않습니다.");
                }

                myConn.Close(); //mysql 연결해제
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new join().Show();

        }

        private void textBox_PW_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
