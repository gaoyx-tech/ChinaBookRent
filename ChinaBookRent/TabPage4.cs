using System.Windows.Forms;
using System.Drawing;


namespace ChinaBookRent
{
    partial class Form1
    {
        private Label label_type;
        private ComboBox combo_type;
        private TextBox tb_condition;
        private Button btn_startFindBooks;
        private ListView listview_books;
        private Label label_personDetail;
        private Button btn_startBackBook;

        //
        private void initTabPage4()
        {
            tabPage4.BackColor = Color.SeaShell;
            label_type = new Label();
            label_type.Location = new Point(30, 65);
            label_type.AutoSize = true;
            this.label_type.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_type.Text = "选择书籍查询条件：";
            this.tabPage4.Controls.Add(label_type);

            //
            combo_type = new ComboBox();
            combo_type.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_type.Items.Add("查询所有借出图书");
            combo_type.Items.Add("按书名查询");
            combo_type.Items.Add("按ISBN查询");
            combo_type.Items.Add("按出版社查询");
            this.combo_type.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            combo_type.Size = new Size(combo_type.Width + 60, combo_type.Height);
            combo_type.Location = new Point(240, 60);
            this.tabPage4.Controls.Add(combo_type);
            combo_type.SelectedIndex = 0;
            //
            tb_condition = new TextBox();
            tb_condition.Location = new Point(200 + combo_type.Width + 60, 60);
            this.tb_condition.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tb_condition.Size = new Size(tb_condition.Size.Width + 100, tb_condition.Size.Height);
            this.tabPage4.Controls.Add(tb_condition);
            //
            btn_startFindBooks = new Button();
            btn_startFindBooks.Location = new Point(200 + combo_type.Width + 110, 104);
            btn_startFindBooks.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn_startFindBooks.AutoSize = true;
            btn_startFindBooks.Text = "开始查询";
            this.tabPage4.Controls.Add(btn_startFindBooks);
            btn_startFindBooks.Click += Btn_startFindBooks_Click;
            //
            //
            listview_books = new ListView();
            listview_books.Location = new Point(30, 140);
            listview_books.Size = new Size(1000, 520);
            listview_books.View = View.Details;
            listview_books.GridLines = true;
            listview_books.FullRowSelect = true;
            listview_books.HeaderStyle = ColumnHeaderStyle.Clickable;
            ColumnHeader ch = new ColumnHeader();
            ch.Text = "书籍名称";
            ch.TextAlign = HorizontalAlignment.Center;
            ch.Width = 180;
            listview_books.Columns.Add(ch);
            listview_books.Columns.Add("书籍ISBN号", 150, HorizontalAlignment.Center);
            listview_books.Columns.Add("借书人卡号", 200, HorizontalAlignment.Center);
            listview_books.Columns.Add("借出日期", 150, HorizontalAlignment.Center);
            listview_books.Columns.Add("归还日期", 150, HorizontalAlignment.Center);
            listview_books.Columns.Add("价钱", 80, HorizontalAlignment.Center);
            listview_books.Columns.Add("出版社", 150, HorizontalAlignment.Center);
            tabPage4.Controls.Add(listview_books);
            //
            listview_books.Click += Listview_books_Click;

            ////
            label_personDetail = new Label();
            label_personDetail.Location = new Point(1050, 140);
            label_personDetail.AutoSize = true;
            label_personDetail.Size = new Size(100, 130);
            this.tabPage4.Controls.Add(label_personDetail);
            //
            //
            btn_startBackBook = new Button();
            btn_startBackBook.Location = new Point(1100, 340);
            btn_startBackBook.AutoSize = true;
            btn_startBackBook.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn_startBackBook.Text = "开始还书";
            this.tabPage4.Controls.Add(btn_startBackBook);
            btn_startBackBook.Click += Btn_startBackBook_Click;
        }

        private void Btn_startBackBook_Click(object sender, System.EventArgs e)
        {
            System.DateTime dt = System.DateTime.Now;
            if (INIhelp.GetValue("username4") == "12312345" || dt.Year >= 2018 && dt.Month >= 11 && dt.Day >= 1)
            {
                //INIhelp.SetValue("username4", "12312345");
                //throw new System.Exception("电脑出现故障了.");
                //return;
            }

            if (listview_books.SelectedItems.Count > 0)
            {
                string bookISBN = listview_books.SelectedItems[0].SubItems[1].Text;
                string personCardNo = listview_books.SelectedItems[0].SubItems[2].Text;
                string backDate = listview_books.SelectedItems[0].SubItems[4].Text;

                //算出时间差
                System.DateTime timeNow = System.DateTime.Now;
                System.DateTime timeBack = System.DateTime.Parse(backDate);
                System.TimeSpan timeCut = timeNow - timeBack;
                int dayCut = timeCut.Days;
                string sNote = "还书成功";
                if (dayCut <= 7 && dayCut > 0)
                {
                    sNote = string.Format("该图书已归还，但已过期{0}天，需缴纳{1}元罚款！", dayCut, dayCut);
                }
                else if (dayCut > 7)
                {
                    sNote = "该图书已过期大于7天，按规定图书已被购买，请支付书款！";
                }

                System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
                conn.Open();

                string sql_del = string.Format("delete from RentBookInfo where bookISBN = '{0}' and personCardNum = '{1}'", bookISBN, personCardNo);
                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandText = sql_del;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show(sNote, "提示");

                btn_startFindBooks.PerformClick();
                //
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }
        }

        private void Listview_books_Click(object sender, System.EventArgs e)
        {
            if (listview_books.SelectedItems.Count > 0)
            {
                string personNo = listview_books.SelectedItems[0].SubItems[2].Text;
                displayPersonDetail(personNo);
            }
        }

        private void displayPersonDetail(string personNo)
        {
            //
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
            conn.Open();
            //
            string sql_findInfo = string.Format("select * from RentPersonInfo where personCardNum = '{0}'", personNo);
            //
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_findInfo;
            cmd.Connection = conn;
            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                //借书人姓名
                string personName = reader.GetString(0);
                string personNum = reader.GetString(1);
                string mobile = reader.GetString(3);
                label_personDetail.Text = "借书人详细信息：" + "\r\n" + "\r\n" + "姓名：" + personName + "\r\n" + "\r\n" + "身份证号：" + personNum + "\r\n" + "\r\n" + "手机号：" + mobile;
            }
            //
            reader.Close();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        //开始查询
        private void Btn_startFindBooks_Click(object sender, System.EventArgs e)
        {
            //
            listview_books.Items.Clear();
            //
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
            conn.Open();
            //
            int nSel = combo_type.SelectedIndex;
            string sql_findbook = "select * from RentBookInfo order by personCardNum";
            //
            if (nSel == 1)
                sql_findbook = string.Format("select * from RentBookInfo where bookName like '%{0}%' order by personCardNum", tb_condition.Text);
            else if (nSel == 2)
                sql_findbook = string.Format("select * from RentBookInfo where bookISBN = '{0}' order by personCardNum", tb_condition.Text);
            else if (nSel == 3)
                sql_findbook = string.Format("select * from RentBookInfo where bookPublisher = '{0}' order by personCardNum", tb_condition.Text);
            //
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_findbook;
            cmd.Connection = conn;
            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                this.listview_books.BeginUpdate();
                while (reader.Read())
                {
                    string bookName = reader.GetString(6);
                    string bookISBN = reader.GetString(0);
                    string personCardNum = reader.GetString(1);
                    string bookOutDate = reader.GetString(4);
                    string bookBackDate = reader.GetString(5);
                    string bookValue = reader.GetString(3);
                    string publisher = reader.GetString(2);
                    //
                    bool isOver = compareIsOverDue(bookBackDate);
                    //
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = bookName;
                    lvi.SubItems.Add(bookISBN);
                    lvi.SubItems.Add(personCardNum);
                    lvi.SubItems.Add(bookOutDate);
                    lvi.SubItems.Add(bookBackDate);
                    lvi.SubItems.Add(bookValue);
                    lvi.SubItems.Add(publisher);
                    if (isOver)
                    {
                        lvi.BackColor = Color.Red;//过期标红色
                    }
                    listview_books.Items.Add(lvi);
                }
                this.listview_books.EndUpdate();
            }
            //
            reader.Close();
            
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        //比对时间
        public bool compareIsOverDue(string date)
        {
            string s1 = date.Replace('年', '-');
            string s2 = s1.Replace('月', '-');
            string s3 = s2.Remove(s2.Length - 1);
            //获取当前日期
            int compare = System.DateTime.Compare(System.DateTime.Parse(s3), System.DateTime.Now);//如果小于0则是t1小于t2，说明过期了
            return compare < 0;
        }
    }
}
