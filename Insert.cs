using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace 로그인
{
    public partial class Insert : Form
    {
        Form1 f1;
        MainForm mf;
         string constring = "datasource = localhost;port=3306;username=root;password=password";
        public Insert(MainForm mainform)
        {
            InitializeComponent();
            
            mf = mainform;
        }
        public Insert(Form1 frm)
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            this.f1 = frm;
        }

        void Cal()//달력에 날짜를 선택하면 양력 음력 날짜가 다 나오도록 설정
        {
            KoreanLunisolarCalendar klc = new KoreanLunisolarCalendar();
            bool bExistLeap = false;

            DateTime dt = (DateTime)monthCalendar1.SelectionRange.Start;
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
            textBox_ayng.Text = tmpDt.ToString(Year + "-" + Month + "-" + day);
            textBox_um.Text = tmpDt.ToString(InYear + "-" + InMonth + "-" + Inday);
        }

        
        private void btnOK_Click(object sender, EventArgs e)  //저장 버튼
        {
            DateTime oldDate = (DateTime)monthCalendar1.SelectionRange.Start;
            if (MessageBox.Show(txtEvent.Text + "\n" + textBox_ayng.Text, "등록하시겠습니까?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Query = "select eventName from login.event where eventName = '" + this.txtEvent.Text + "'and ID = '" + f1.textBox_ID.Text + "'";
                MySqlConnection conDataBase = new MySqlConnection(constring);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);

                try
                {
                    MySqlDataReader myReader;
                    conDataBase.Open();
                    String eName = (String)cmdDataBase.ExecuteScalar();



                    if (eName == this.txtEvent.Text)
                    {

                        MessageBox.Show("중복되는 이벤트명이 있습니다.");

                    }
                    else
                    {
                        cmdDataBase.CommandText = "insert into login.event (eventName,startDay,endDay,day,ID) value ('" + this.txtEvent.Text + "','" + this.dateTimePicker1.Text + "','" + this.textBox_ayng.Text + "','" + this.txtDay.Text + "','" + f1.textBox_ID.Text + "')";
                        myReader = cmdDataBase.ExecuteReader();
                        while (myReader.Read())
                        {

                        }
                        this.Hide();
                        new MainForm(f1).Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Cal();
        }

        private void btnToDayON_Click(object sender, EventArgs e)
        {
            DateTime oldDate = (DateTime)monthCalendar1.SelectionRange.Start;
            DateTime newDate = dateTimePicker1.Value;

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
                    txtDay.Text = b.ToString();
                }
                else
                {
                    int a = Days - 1;
                    txtDay.Text = a.ToString();
                }

            }
            else if (Days > 0)
                txtDay.Text = Days.ToString("+0;-#");
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            new MainForm(f1).Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Insert_Load(object sender, EventArgs e)
        {

        }

        private void textBox_ayng_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
