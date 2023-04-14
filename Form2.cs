using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace 로그인
{
    public partial class Form2 : Form
    {
        Form1 f1;
        MainForm mf;
        string myConnection = "datasource=localhost;port=3306;username=root;password=password;sslMode=none"; // mysql 정보        

        private string Form2_value;
        public string passvalue // mainForm eventName 가져오기
        {
            get { return this.Form2_value; }
            set { this.Form2_value = value; }
        }


        public Form2(MainForm mainform)
        {
            InitializeComponent();
            mf = mainform;
            dateTimePicker2.Value = DateTime.Now;
        }

       
        public Form2(Form1 frm)
        {
            InitializeComponent();
            f1 = frm;
            dateTimePicker2.Value = DateTime.Now;
        }
        public Form2()
        {
            InitializeComponent();
            dateTimePicker2.Value = DateTime.Now;
        }

        void Cal()//달력에 날짜를 선택하면 양력 음력 날짜가 다 나오도록 설정
        {
            KoreanLunisolarCalendar klc = new KoreanLunisolarCalendar();
            bool bExistLeap = false;

            DateTime dt = (DateTime)monthCalendar2.SelectionRange.Start;
            string year = dt.ToString("yyyy");
            string month = dt.ToString("MM");
            string day = dt.ToString("dd");
            int Year = Convert.ToInt32(year);
            int Month = Convert.ToInt32(month);
            int Day = Convert.ToInt32(day);


            DateTime tmpDt = new DateTime(Year, Month, Day);
            int InYear = klc.GetYear(tmpDt);
            int InMonth = klc.GetMonth(tmpDt);
            int Inday = klc.GetDayOfMonth(tmpDt);

            if (klc.GetMonthsInYear(InYear) > 12)
            {
                bExistLeap = klc.IsLeapMonth(InYear, InMonth);
                int intLeap_mm = klc.GetLeapMonth(InYear);
                if (InMonth >= intLeap_mm)
                {
                    InMonth--;
                }
            }
            textBox_ayng2.Text = tmpDt.ToString(Year + "-" + Month + "-" + day);
            textBox_um2.Text = tmpDt.ToString(InYear + "-" + InMonth + "-" + Inday);
        }

        private void btnOK2_Click(object sender, EventArgs e) //수정버튼
        {
            dateTimePicker2.Value = DateTime.Now;
            DateTime oldDate = (DateTime)monthCalendar2.SelectionRange.Start;
            if (MessageBox.Show(txtEvent2.Text + "\n" + textBox_ayng2.Text, "수정하시겠습니까?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Query = "update login.event set eventName = '" + this.txtEvent2.Text + "', startDay = '" + this.dateTimePicker2.Text + "', endDay = '" + this.textBox_ayng2.Text + "', day = '" + this.txtDay2.Text + "', ID= '" + f1.textBox_ID.Text + "' where eventName = '" + passvalue + "';";    //ID = '" + f1.textBox_ID + "', 

                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, myConn);

                MySqlDataReader myReader;

                

                try
                {
                    myConn.Open();
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
                finally
                {
                    myConn.Close();
                }

                
            }
        }

        private void btnToDayON2_Click(object sender, EventArgs e) //날짜계산
        {
            DateTime oldDate = (DateTime)monthCalendar2.SelectionRange.Start;
            DateTime newDate = dateTimePicker2.Value;

            TimeSpan ts = newDate - oldDate;
            string day = newDate.ToString("dd");
            int Day = Convert.ToInt32(day);
            string day2 = oldDate.ToString("dd");
            int Day2 = Convert.ToInt32(day2);
            string month = newDate.ToString("MM");
            int Month = Convert.ToInt32(month);
            string month2 = oldDate.ToString("MM");
            int Month2 = Convert.ToInt32(month2);
            string year = newDate.ToString("yy");
            int Year = Convert.ToInt32(year);
            string year2 = oldDate.ToString("yy");
            int Year2 = Convert.ToInt32(year2);

            int Days = ts.Days;
            if (Days <= 0)
            {
                if (Day == Day2 && Month == Month2 && year == year2)
                {
                    int b = Day - Day2;
                    txtDay2.Text = b.ToString();
                }
                else
                {
                    int a = Days - 1;
                    txtDay2.Text = a.ToString();
                }

            }
            else if (Days > 0)
                txtDay2.Text = Days.ToString("+0;-#");
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            Cal();
        }

        private void button_back_Click(object sender, EventArgs e) //뒤로가기
        {
            this.Hide();
            new MainForm(f1).Show();
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
           mf = new MainForm();
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand selectCommand = new MySqlCommand("select eventName from login.event where eventName = '" + passvalue +  "'", myConn);
            
            
            try
            {
                myConn.Open();
                String event_name = (String)selectCommand.ExecuteScalar();
                txtEvent2.Text = event_name;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }


    }
}
