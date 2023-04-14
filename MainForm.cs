using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;

namespace 로그인
{

    public partial class MainForm : Form // 로그인 후 창
    {
        Form1 f1;
        Form2 f2;
        Insert insert;
        public string selectitemeventName;
        public string selectiteendDay;
        string myConnection = "datasource=localhost;port=3306;username=root;password=password"; // mysql 정보
        string strURL = "http://www.kma.go.kr/weather/forecast/mid-term-xml.jsp"; // 날씨중기예보 정보 주소
        string strCity = "";

        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(Form1 frm1)
        {
            InitializeComponent();
            Daylist(frm1);

            dayviewlist.View = View.Details;
            dayviewlist.FullRowSelect = true;

            choosecity.SelectedIndex = 0; // 도시 고르는곳에 0번째 도시를 기본으로 적용 (대구)
            Today_txt.Text = DateTime.Now.ToString("yyyy-MM-dd"); // 현재 날짜 출력

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mypage mypage = new mypage(f1);
            Insert insert = new Insert(f1);
            dateTimePicker1.Value = DateTime.Now;
            try
            {

                MySqlConnection myConn = new MySqlConnection(myConnection); // mysql 연결 기능

                //아이디 비밀번호 입력
                MySqlCommand selectCommand = new MySqlCommand("select nicname from login.edata where ID='" + f1.textBox_ID.Text + "'", myConn);

                myConn.Open(); // mysql 연결


                String nicname = (String)selectCommand.ExecuteScalar();
                label_nicname.Text = nicname;

                myConn.Close(); //mysql 연결해제

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // checkedListBox1.Text;
        }

        private void choosecity_SelectedIndexChanged_1(object sender, EventArgs e) //그 도시 고르는 부분(choosecity의 combo박스)의 정보를 토대로 웹주소의 Xml 정보를 검색과 출력
        {
            try
            {
                using (XmlReader xr = XmlReader.Create(strURL))
                {
                    string strMsg = "";
                    XmlWriterSettings ws = new XmlWriterSettings();
                    ws.Indent = true;
                    bool bCheck = false;
                    int iCount = 0;
                    strCity = choosecity.Text;

                    while (xr.Read())
                    {
                        switch (xr.NodeType)
                        {
                            case XmlNodeType.Element:
                                {
                                    break;
                                }
                            case XmlNodeType.Text:
                                {
                                    if (xr.Value.Equals(strCity))
                                    {
                                        bCheck = true;
                                    }
                                    if (bCheck)
                                    {
                                        DateTime dt;
                                        bool b = DateTime.TryParse(xr.Value.ToString(), out dt);
                                        if (b)
                                        {
                                            strMsg += "/";
                                        }
                                        strMsg += xr.Value + ",";
                                        iCount += 1;
                                        if (iCount > 36)
                                        {
                                            bCheck = false;
                                        }
                                    }
                                    break;
                                }
                            case XmlNodeType.XmlDeclaration:
                                {
                                    break;
                                }
                            case XmlNodeType.ProcessingInstruction:
                                {
                                    break;
                                }
                            case XmlNodeType.Comment:
                                {
                                    break;
                                }
                            case XmlNodeType.EndElement:
                                {
                                    break;
                                }
                        }
                    }

                    //while 

                    //요일별로 짜르기

                    string[] strTmp = strMsg.Split('/');

                    //요일별 데이터 
                    string[] strWh1 = strTmp[1].Split(',');
                    label50.Text = strWh1[0];
                    label51.Text = "최저: " + strWh1[2] + " ℃";
                    label52.Text = "최고: " + strWh1[3] + " ℃";
                    label53.Text = strWh1[1];

                    string[] strWh2 = strTmp[2].Split(',');
                    label54.Text = strWh2[0];
                    label55.Text = "최저: " + strWh2[2] + " ℃";
                    label56.Text = "최고: " + strWh2[3] + " ℃";
                    label57.Text = strWh2[1];

                    string[] strWh3 = strTmp[3].Split(',');
                    label58.Text = strWh3[0];
                    label59.Text = "최저: " + strWh3[2] + " ℃";
                    label60.Text = "최고: " + strWh3[3] + " ℃";
                    label61.Text = strWh3[1];

                    string[] strWh4 = strTmp[4].Split(',');
                    label62.Text = strWh4[0];
                    label63.Text = "최저: " + strWh4[2] + " ℃";
                    label64.Text = "최고: " + strWh4[3] + " ℃";
                    label65.Text = strWh4[1];

                    string[] strWh5 = strTmp[5].Split(',');
                    label66.Text = strWh5[0];
                    label67.Text = "최저: " + strWh5[2] + " ℃";
                    label68.Text = "최고: " + strWh5[3] + " ℃";
                    label69.Text = strWh5[1];

                    string[] strWh6 = strTmp[6].Split(',');
                    label70.Text = strWh6[0];
                    label71.Text = "최저: " + strWh6[2] + " ℃";
                    label72.Text = "최고: " + strWh6[3] + " ℃";
                    label73.Text = strWh6[1];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public void Daylist(Form1 frm)
        {
            f1 = frm;
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmd;
            MySqlDataAdapter da;
            DataTable dt;
            DateTime newDate = DateTime.Now;

            try
            {
                myConn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = myConn;
                cmd.CommandText = "Select * FROM login.event where ID = '" + f1.textBox_ID.Text + "'"; // 어떤 테이블을 이용할것인지 지정
                da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)  // i가 0부터 ~ 데이터 수만큼 카운트
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["eventName"].ToString());// 이벤트 이름 출력
                    listitem.SubItems.Add(dr["endDay"].ToString()); // 마감일 출력
                    listitem.SubItems.Add(dr["day"].ToString()); // 남은 날짜 출력
                    dayviewlist.Items.Add(listitem);
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

        private void button_logout_Click(object sender, EventArgs e) //로그아웃버튼
        {
            if (MessageBox.Show("로그아웃하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new Form1().Show();
            }

        }


        private void button_mypage_Click(object sender, EventArgs e) //마이페이지 버튼
        {
            this.Hide();
            new mypage(f1).Show();
        }



        private void button1_Click_1(object sender, EventArgs e) //추가버튼
        {
            this.Hide();
            insert = new Insert(this);
            insert = new Insert(f1);
            insert.Show();
        }

        private void button3_Click(object sender, EventArgs e) //삭제버튼
        {

            ListView.SelectedListViewItemCollection items = dayviewlist.SelectedItems;
            ListViewItem lvItem = items[0];
            selectitemeventName = lvItem.SubItems[0].Text;
            if (MessageBox.Show(selectitemeventName + "을 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Query = "delete from login.event where eventName='" + selectitemeventName + "'and ID= '" + f1.textBox_ID.Text + "';";

                MySqlConnection conDataBase = new MySqlConnection(myConnection);
                MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);

                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("삭제되었습니다. ");


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
                    conDataBase.Close();
                }
                this.Hide();
                new MainForm(f1).Show();
            }
        }

        public void dayviewlist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dayviewlist.SelectedItems.Count == 1)
            {
                this.Hide();
                f2 = new Form2(this);
                f2 = new Form2(f1);
                ListView.SelectedListViewItemCollection items = dayviewlist.SelectedItems;
                ListViewItem lvItem = items[0];
                selectitemeventName = lvItem.SubItems[0].Text;
                f2.passvalue = selectitemeventName;

                f2.ShowDialog();
            }

        }

        private void btn_back_month_Click(object sender, EventArgs e)
        {
            int[] no;
            string[] name1;

            getRedDay(customCalendar1.selectedDate.AddMonths(-1).Year,
                customCalendar1.selectedDate.AddMonths(-1).Month, out no, out name1);

            customCalendar1.goToDateWithNoEvent(no, name1, customCalendar1.selectedDate.AddMonths(-1));
        }

        private void btn_front_month_Click(object sender, EventArgs e)
        {
            int[] no;
            string[] name1;
            getRedDay(customCalendar1.selectedDate.AddMonths(1).Year,
                customCalendar1.selectedDate.AddMonths(1).Month, out no, out name1);


            customCalendar1.goToDateWithNoEvent(no, name1, customCalendar1.selectedDate.AddMonths(1));
        }

        private void getRedDay(int year, int month, out int[] no, out string[] name1)
        {
            List<int> no2 = new List<int>();
            List<string> name2 = new List<string>();
            switch (month)
            {
                case 1:
                    no2.Add(1);
                    name2.Add("신정");
                    break;
                case 3:
                    no2.Add(1);
                    name2.Add("삼일절");
                    break;
                case 5:
                    no2.Add(5);
                    name2.Add("어린이날");
                    break;
                case 6:
                    no2.Add(6);
                    name2.Add("현충일");
                    break;
                case 8:
                    no2.Add(15);
                    name2.Add("광복절");
                    break;
                case 9:
                    break;
                case 10:
                    no2.Add(3);
                    name2.Add("개천절");
                    no2.Add(9);
                    name2.Add("한글날");
                    break;
                case 12:
                    no2.Add(25);
                    name2.Add("크리스마스");
                    break;
                default:
                    no = null;
                    name1 = null;
                    break;
            }
            DateTime dt = new DateTime(year - 1, 12, 30);
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);//설날
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("설날");
            }

            dt = new DateTime(year, 1, 1);
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);//설날
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("설날");
            }

            dt = new DateTime(year, 1, 2);//설날
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);//설날
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("설날");
            }

            dt = new DateTime(year, 4, 8);//석가탄신일
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);//석가탄신일
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("석가탄신일");
            }

            dt = new DateTime(year, 8, 14);//추석
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("추석");
            }

            dt = new DateTime(year, 8, 15);//추석
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("추석");
            }

            dt = new DateTime(year, 8, 16);//추석
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("추석");
            }

            no = no2.ToArray();
            name1 = name2.ToArray();
        }

        private DateTime convertKoreanMonth2(DateTime dt)//양력을 음력 변환
        {
            int n윤월;
            int n음력년, n음력월, n음력일;
            bool b윤달 = false;
            System.Globalization.KoreanLunisolarCalendar 음력 =
            new System.Globalization.KoreanLunisolarCalendar();


            n음력년 = 음력.GetYear(dt);
            n음력월 = 음력.GetMonth(dt);
            n음력일 = 음력.GetDayOfMonth(dt);
            if (음력.GetMonthsInYear(n음력년) > 12)             //1년이 12이상이면 윤달이 있음..
            {
                b윤달 = 음력.IsLeapMonth(n음력년, n음력월);     //윤월인지
                n윤월 = 음력.GetLeapMonth(n음력년);             //년도의 윤달이 몇월인지?
                if (n음력월 >= n윤월)                           //달이 윤월보다 같거나 크면 -1을 함 즉 윤8은->9 이기때문
                    n음력월--;
            }
            return new DateTime(int.Parse(n음력년.ToString()), int.Parse(n음력월.ToString()), int.Parse(n음력일.ToString()));
        }

        private DateTime convertKoreanMonth(int n음력년, int n음력월, int n음력일)//음력을 양력 변환
        {
            System.Globalization.KoreanLunisolarCalendar 음력 =
            new System.Globalization.KoreanLunisolarCalendar();

            bool b달 = 음력.IsLeapMonth(n음력년, n음력월);
            int n윤월;

            if (음력.GetMonthsInYear(n음력년) > 12)
            {
                n윤월 = 음력.GetLeapMonth(n음력년);
                if (b달)
                    n음력월++;
                if (n음력월 > n윤월)
                    n음력월++;
            }
            try
            {
                음력.ToDateTime(n음력년, n음력월, n음력일, 0, 0, 0, 0);
            }
            catch
            {
                return 음력.ToDateTime(n음력년, n음력월, 음력.GetDaysInMonth(n음력년, n음력월), 0, 0, 0, 0);//음력은 마지막 날짜가 매달 다르기 때문에 예외 뜨면 그날 맨 마지막 날로 지정
            }

            return 음력.ToDateTime(n음력년, n음력월, n음력일, 0, 0, 0, 0);
        }

        private void dayviewlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }
    }
}