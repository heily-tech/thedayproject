using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 로그인 { 

    public partial class CustomCalendar : UserControl
    {
        public delegate void DateTimeEventHandler(DateTime dt);
        public event DateTimeEventHandler _changedDate;
        likeCal LikeCal = new likeCal();
       
      
        public CustomCalendar()
        {
            InitializeComponent();
            LikeCal._changeDate += new likeCal.dtDelegate(LikeCal__changeDate);
            LikeCal.Dock = DockStyle.Fill;
            LikeCal.selectDate(DateTime.Now);
            panel_day.Controls.Add(LikeCal);
        }
        // 이벤트 달력에 출력
  
        public DateTime selectedDate
        {
            get 
            { 
                return LikeCal.dtValue; 
            }
        }
        
        private void LikeCal__changeDate(DateTime dt)
        {
            label_caption.Text = dt.Month + " , " + dt.Year;
            if(_changedDate != null) _changedDate(LikeCal.dtValue);
        }
        private void label_next_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void label_next_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
        }

        private void label_next_Click(object sender, EventArgs e)
        {
            LikeCal.nextMonth();
        }

        private void label_pre_Click(object sender, EventArgs e)
        {
            LikeCal.preMonth();
        }

        private void label_caption_Click(object sender, EventArgs e)
        {
            LikeCal.moveToToday();
        }
        
        public void goToDateWithNoEvent(int[] onlyDayDisit, string[] redDayName, DateTime dt)
        {
            LikeCal.setRedDay(onlyDayDisit, redDayName);
            LikeCal.selectDate(dt);
            label_caption.Text = dt.Month + " , " + dt.Year;
        }

        public void goToToday()
        {
            LikeCal.moveToToday();
        }
        public void goToPreDay()
        {
            LikeCal.preDay();
        }
        public void goToNextDay()
        {
        }
        public void goToPreWeek()
        {
            LikeCal.preWeek();
        }
        public void goToNextWeek()
        {
            LikeCal.nextWeek();
        }
        public void goToPreMonth()
        {
            LikeCal.preMonth();
        }
        public void goToNextMonth()
        {
            LikeCal.nextMonth();
        }
    }
    class dLabel : Label
    {
        public dLabel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }
    }

    class likeCal : TableLayoutPanel
    {
        public delegate void dtDelegate(DateTime dt);
        public event dtDelegate _changeDate;

        int Month = DateTime.Now.Month;
        public DateTime dtValue = DateTime.Now;
        public dLabel[] TB = new dLabel[42];
        int[] redDayList = null;
        string[] redDayName = null;

        int[] eventDayList = null;
        string[] eventDayName = null;

        public likeCal()
        {
            DoubleBuffered = true;
            setRowColumns(7, 7);
        }
        public void setRedDay(int[] redDayList, string[] redDayName) // set 공휴일 
        {
            this.redDayList = redDayList;
            this.redDayName = redDayName;
        }

        public void setEventDay(int[] eventDayList, string[] eventDayName) // set 이벤트데이
        {
            this.eventDayList = eventDayList;
            this.eventDayName = eventDayName;
        }

        private void likeCal_MouseClick(object sender, MouseEventArgs e)
        {
            if (((Control)sender).Text != null && ((Control)sender).Text != "")
            {
                DateTime dt;
                try
                {
                    dt = new DateTime(dtValue.Year, dtValue.Month, int.Parse(((Control)sender).Text), 0, 0, 0);
                }
                catch 
                {
                    return;
                }
                selectDate(dt);
                if (_changeDate != null) _changeDate(dt);
            }
        }
        public void setRowColumns(int rows, int columns)
        {
            ColumnCount = columns;
            RowCount = rows;
            for (int i = 0; i < RowCount; i++) RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            for (int i = 0; i < ColumnCount; i++) ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            //int cnt = 0;
            dLabel tb = null;
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    tb = new dLabel();
                    tb.AutoSize = false;
                    if (i == 0)
                    {
                        tb.Text = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[j][0].ToString();
                        tb.ForeColor = System.Drawing.Color.White;
                        tb.BackColor = System.Drawing.Color.LightSteelBlue;
                    }
                    else
                    {
                        tb.ForeColor = System.Drawing.Color.Black;
                        tb.BackColor = System.Drawing.Color.White;
                        //tb.MouseClick += new MouseEventHandler(likeCal_MouseClick);//첫 줄은 요일.
                        TB[j + ((i-1) * 7)] = tb;
                    }

                    tb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                    tb.Font = new System.Drawing.Font("Arial", 10, FontStyle.Bold);
                    tb.BorderStyle = BorderStyle.None;
                    tb.Margin = new Padding(1);
                    tb.Padding = new Padding(0);
                    tb.Dock = DockStyle.Fill;
                    Controls.Add(tb, j, i);
                }
            }
        }
        
        public void selectDate(DateTime DT)
        {
            dtValue = DT;
            clearDay();

            DateTime Start = new DateTime(DT.Year, DT.Month, 1);
            int End = DateTime.DaysInMonth(DT.Year, DT.Month);
            int week = (int)Start.DayOfWeek;

            for (int var = 1; var <= End; var++)
            {
                int index = var + week -1;

                //TB[index].Cursor = Cursors.Hand;
                TB[index].Text = string.Format("{0:0}", var);

                

                int index1 = 0;
                if (var == dtValue.Day)
                {
                    if (redDayList != null && (index1=Array.IndexOf(redDayList, var)) >= 0)
                    {
                        TB[index].ForeColor = System.Drawing.Color.Red;//선택된 날짜가 리스트에 있을 경우
                        TB[index].Text += "\n" + redDayName[index1];
                    }
                    else if (eventDayList != null && (index1 = Array.IndexOf(eventDayList, var)) >= 0)
                    {
                        TB[index].ForeColor = System.Drawing.Color.BlueViolet;//선택된 날짜가 리스트에 있을 경우
                        TB[index].Text += "\n" + eventDayName[index1];
                    }
                    else
                    {
                        if (index % 7 == 0)
                        {
                            TB[index].ForeColor = System.Drawing.Color.Red;
                        }
                        else TB[index].ForeColor = System.Drawing.Color.Black;//선택된 날짜가 리스트가 아닐 때
                    }
                    //TB[index].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    //TB[index].BackColor = System.Drawing.Color.Gainsboro;
                }

                else
                {
                    if (redDayList != null && (index1 = Array.IndexOf(redDayList, var)) >= 0)
                    {
                        TB[index].ForeColor = System.Drawing.Color.Red;//선택된 공휴일이 리스트에 있을 경우
                        TB[index].Text += "\n" + redDayName[index1];
                    }
                    else if (eventDayList != null && (index1 = Array.IndexOf(eventDayList, var)) >= 0)
                    {
                        TB[index].ForeColor = System.Drawing.Color.BlueViolet;//선택된 일정이 리스트에 있을 경우
                        TB[index].Text += "\n" + eventDayName[index1];
                    }
                    else
                    {
                        if (index % 7 == 0) // 일요일 빨간색으로 색입힘
                        {
                            TB[index].ForeColor = System.Drawing.Color.Red ;
                        }
                        else if (index % 7 == 6) // 토요일 파란색으로 색입힘
                        {
                            TB[index].ForeColor = System.Drawing.Color.Blue;
                        }
                        else TB[index].ForeColor = System.Drawing.Color.Black; // 일반날
                    }

                }
            }
        }

        public void nextMonth()
        {
            DateTime dt = dtValue.AddMonths(1);
            selectDate(dt);
            if (_changeDate != null) _changeDate(dt);
        }
        public void preMonth()
        {
            DateTime dt = dtValue.AddMonths(-1);
            selectDate(dt);
            if (_changeDate != null) _changeDate(dt);
        }
        public void nextWeek()
        {
            DateTime dt = dtValue.AddDays(7);
            selectDate(dt);
            if (_changeDate != null) _changeDate(dt);
        }
        public void preWeek()
        {
            DateTime dt = dtValue.AddDays(-7);
            selectDate(dt);
            if (_changeDate != null) _changeDate(dt);
        }
        public void nextDay()
        {
            DateTime dt = dtValue.AddDays(1);
            selectDate(dt);
            if (_changeDate != null) _changeDate(dt);
        }
        public void preDay()
        {
            DateTime dt = dtValue.AddDays(-1);
            selectDate(dt);
            if (_changeDate != null) _changeDate(dt);
        }
        public void moveToToday()
        {
            DateTime dt = DateTime.Now;
            selectDate(dt);
            if (_changeDate != null) _changeDate(dt);
        }

        public void clearDay()
        {
            for(int i = 0; i < 42; i++)
            {
                TB[i].BorderStyle = System.Windows.Forms.BorderStyle.None;
                TB[i].BackColor = Color.White;
                TB[i].Cursor = Cursors.Default;
                TB[i].Text = string.Empty;
            }
        }
    }
}
