using System.Windows.Forms;
using System.Drawing;
using System;

namespace ChinaBookRent
{
    partial class Form1
    {
        Graphics graphical = null;
        Pen pen = null;
        System.Collections.ArrayList arrayRentData = new System.Collections.ArrayList();
        //
        DateTimePicker datePicker;

        private void initTabPage3()
        {
            this.tabPage3.BackColor = Color.White;
            this.tabPage3.Paint += Form1_Paint;
            Timer timer = new Timer();
            timer.Interval = 30000;
            timer.Enabled = true;
            timer.Start();
            timer.Tick += Timer_Tick;
            //
            datePicker = new DateTimePicker();
            datePicker.Location = new Point(1150, 50);
            datePicker.Value = DateTime.Now;
            this.tabPage3.Controls.Add(datePicker);
            caculateRentBookData();
            datePicker.ValueChanged += DatePicker_ValueChanged;
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            caculateRentBookData();
            this.tabPage3.Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            caculateRentBookData();
            this.tabPage3.Invalidate();
        }

        private void caculateRentBookData()
        {
            arrayRentData.Clear();
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
            conn.Open();
            for (int i = 0; i < 10; ++i)
            {
                DateTime reduce = datePicker.Value - new TimeSpan(1 * i, 0, 0, 0);
                string sql = string.Format("select * from RentBookInfo where bookOutDate = '{0}'", reduce.GetDateTimeFormats().GetValue(10));
                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int count = 0;
                    while (reader.Read()) { ++count; }
                    arrayRentData.Add(count);
                }
                else arrayRentData.Add(0);

                //
                reader.Close();
                cmd.Dispose();
            }
            conn.Close();
            conn.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphical = e.Graphics;
            pen = new Pen(Color.Black, 3);
            //
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            graphical.DrawLine(pen, new Point(100, 640), new Point(100, 40));
            graphical.DrawLine(pen, new Point(100, 640), new Point(1100, 640));
            //10天的数据
            //DateTime dtNow = DateTime.Now;
            //单色填充 定义单色画刷  
            SolidBrush b1 = new SolidBrush(Color.Black);
            for (int i = 0; i < 10; ++i)
            {
                //字符串日期
                DateTime reduce = datePicker.Value - new TimeSpan(1 * i, 0, 0, 0);
                string reduceStr = reduce.ToShortDateString();
                graphical.DrawString(reduceStr, new Font("黑体", 11), b1, new PointF(100 * i + 70, 650));
                //小竖杠
                Pen penSmall = new Pen(Color.Black, 3);
                penSmall.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                graphical.DrawLine(penSmall, new Point(100 * i + 100, 637), new Point(100 * i + 100, 640));
            }

            //Y轴的100本基准书
            for (int i = 0; i < 101; ++i)
            {
                if (i % 5 != 0) continue;
                Pen penSmall = new Pen(Color.Brown, 3);
                penSmall.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                graphical.DrawLine(penSmall, new Point(95, 640 - i * 6), new Point(100, 640 - i * 6));
                //
                graphical.DrawString(string.Format("{0}本", i), new Font("黑体", 11), b1, new Point(50, 635 - i * 6));
            }
            graphical.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //折线
            for (int i = 0; i < arrayRentData.Count; ++i)
            {
                if (i == arrayRentData.Count - 1) break;
                Pen penSmall = new Pen(Color.IndianRed, 3);
                penSmall.EndCap = System.Drawing.Drawing2D.LineCap.Square;
                graphical.DrawLine(penSmall, new Point(100 * i + 100, 640 - System.Int16.Parse(arrayRentData[i].ToString()) * 6), new Point(100 * (i+1) + 100, 640 - System.Int16.Parse(arrayRentData[i+1].ToString()) * 6));
                //
                graphical.DrawEllipse(penSmall, 100 * i + 98, 639 - System.Int16.Parse(arrayRentData[i].ToString()) * 6, 4, 4);
            }
        }
    }
}
