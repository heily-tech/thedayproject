using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 로그인
{
    public partial class CalendarA : Form
    {
        public CalendarA()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            button3_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] no;
            string[] name1;

            getRedDay(customCalendar1.selectedDate.AddMonths(-1).Year,
                customCalendar1.selectedDate.AddMonths(-1).Month, out no, out name1);

            customCalendar1.goToDateWithNoEvent(no, name1, customCalendar1.selectedDate.AddMonths(-1));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] no;
            string[] name1;
            getRedDay(customCalendar1.selectedDate.AddMonths(1).Year,
                customCalendar1.selectedDate.AddMonths(1).Month, out no, out name1);

            customCalendar1.goToDateWithNoEvent(no, name1, customCalendar1.selectedDate.AddMonths(1));
        }
        private void getRedDay(int year,int month, out int[] no, out string[] name1)
        {
            List<int> no2 = new List<int>();
            List<string> name2 = new List<string>();
            switch(month)
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

            dt = new DateTime(year,4,8);//석가탄신일
            dt = convertKoreanMonth(dt.Year, dt.Month, dt.Day);//석가탄신일
            if (dt.Month == month)
            {
                no2.Add(dt.Day);
                name2.Add("석가탄신일");
            }

            dt = new DateTime(year,8,14);//추석
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
            return new  DateTime(int.Parse(n음력년.ToString()), int.Parse(n음력월.ToString()), int.Parse( n음력일.ToString()));
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
                return 음력.ToDateTime(n음력년, n음력월, 음력.GetDaysInMonth( n음력년, n음력월), 0, 0, 0, 0);//음력은 마지막 날짜가 매달 다르기 때문에 예외 뜨면 그날 맨 마지막 날로 지정
            }

            return 음력.ToDateTime(n음력년, n음력월, n음력일, 0, 0, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Image pb = PrintPanel(customCalendar1);
            PrintDialog myPrintDialog = new PrintDialog();

            PrintDocument pd = new PrintDocument();
            //pd.DefaultPageSettings.PrinterSettings.PrinterName = "Printer Name";
            pd.DefaultPageSettings.Landscape = true; //or false!
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 300;
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 300;
            pd.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            pd.PrintPage += (sender1, args) =>
            {
                Image i = pb;
                Rectangle m = args.MarginBounds;
                args.PageSettings.PrinterResolution.X = 300;
                args.PageSettings.PrinterResolution.Y = 300;

                if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                {
                    m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                }
                else
                {
                    m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                }
                args.Graphics.DrawImage(i, m);
            };

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Name = "Documents";
            printPreviewDialog1.Visible = false;
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.Document.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        private Bitmap PrintPanel(Control pnl)
        {
            PrintDialog myPrintDialog = new PrintDialog();
            System.Drawing.Bitmap memoryImage = new System.Drawing.Bitmap(pnl.Width, pnl.Height);
            memoryImage.SetResolution(300, 300);
            pnl.DrawToBitmap(memoryImage, new Rectangle(0, 0, 2300, 3400));//a4 pixel size in 300dpi
            return memoryImage;
        }

        private void CalendarA_Load(object sender, EventArgs e)
        {

        }
    }
}
