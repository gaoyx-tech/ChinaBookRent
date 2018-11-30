using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace ChinaBookRent
{
    partial class Form1
    {
        private Label lb_personCondition;
        private ComboBox cb_personCondition;
        private TextBox tb_personCondition;
        private Button btn_startPersonInfo;
        //
        private ListView listview_personInfos;
        private ListView listview_personOfBooks;
        //
        private Button btn_startReturnBook;
        //
        private Label lb_allBookOfPerson;
        private ListView listview_allBookOfPerson;
        //当前借出isbn集合
        private ArrayList m_listRenting = new ArrayList();

        private void initTabPage5()
        {
            tabPage5.BackColor = Color.AliceBlue;

            lb_personCondition = new Label();
            lb_personCondition.Location = new Point(40, 40);
            lb_personCondition.Text = "按条件查询借书人：";
            lb_personCondition.AutoSize = true;
            lb_personCondition.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage5.Controls.Add(lb_personCondition);

            //
            cb_personCondition = new ComboBox();
            cb_personCondition.Location = new Point(lb_personCondition.Width + 60, 35);
            cb_personCondition.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            cb_personCondition.Size = new Size(cb_personCondition.Width + 50, cb_personCondition.Height);
            cb_personCondition.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_personCondition.Items.Add("查询所有借书人");
            cb_personCondition.Items.Add("按照姓名查询人");
            cb_personCondition.Items.Add("按照卡号查询人");
            cb_personCondition.Items.Add("按照手机号查询人");
            cb_personCondition.SelectedIndex = 0;
            this.tabPage5.Controls.Add(cb_personCondition);

            //
            tb_personCondition = new TextBox();
            tb_personCondition.Location = new Point(lb_personCondition.Width + 60 + cb_personCondition.Width + 25, 35);
            tb_personCondition.Size = new Size(tb_personCondition.Width + 100, tb_personCondition.Height);
            this.tabPage5.Controls.Add(tb_personCondition);
            //
            btn_startPersonInfo = new Button();
            btn_startPersonInfo.Location = new Point(lb_personCondition.Width + 60 + cb_personCondition.Width + 25 + tb_personCondition.Width + 20, 35);
            btn_startPersonInfo.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn_startPersonInfo.AutoSize = true;
            btn_startPersonInfo.Text = "开始查询";
            this.tabPage5.Controls.Add(btn_startPersonInfo);
            btn_startPersonInfo.Click += Btn_startPersonInfo_Click;
            //
            listview_personInfos = new ListView();
            listview_personInfos.Location = new Point(40, 76);
            listview_personInfos.Size = new Size(700, 600);
            listview_personInfos.View = View.Details;
            listview_personInfos.FullRowSelect = true;
            listview_personInfos.GridLines = true;
            listview_personInfos.Columns.Add("姓名", 180, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("身份证号", 200, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("借书卡号", 180, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("手机号", 160, HorizontalAlignment.Center);
            this.tabPage5.Controls.Add(listview_personInfos);
            listview_personInfos.Click += Listview_personInfos_Click;
            //
            //
            listview_personOfBooks = new ListView();
            listview_personOfBooks.Location = new Point(760, 76);
            listview_personOfBooks.Size = new Size(400, 220);
            listview_personOfBooks.View = View.Details;
            listview_personOfBooks.GridLines = true;
            listview_personOfBooks.FullRowSelect = true;
            listview_personOfBooks.Columns.Add("书名", 100, HorizontalAlignment.Center);
            listview_personOfBooks.Columns.Add("ISBN号", 144, HorizontalAlignment.Center);
            listview_personOfBooks.Columns.Add("价格", 90, HorizontalAlignment.Center);
            listview_personOfBooks.Columns.Add("归还日期", 130, HorizontalAlignment.Center);
            listview_personOfBooks.Columns.Add("人员卡号", 130, HorizontalAlignment.Center);
            this.tabPage5.Controls.Add(listview_personOfBooks);
            //
            //
            btn_startReturnBook = new Button();
            btn_startReturnBook.Location = new Point(760 + listview_personOfBooks.Width + 10, 230);
            btn_startReturnBook.Text = "开始还书";
            btn_startReturnBook.AutoSize = true;
            btn_startReturnBook.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage5.Controls.Add(btn_startReturnBook);
            //
            btn_startReturnBook.Click += Btn_startReturnBook_Click;

            //
            lb_allBookOfPerson = new Label();
            lb_allBookOfPerson.AutoSize = true;
            lb_allBookOfPerson.Text = "借阅者所有图书（包括已还和未还，红色为未还，蓝色为已还）";
            lb_allBookOfPerson.Font = new Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lb_allBookOfPerson.Location = new Point(760, listview_personOfBooks.Height + 76 + 30);
            this.tabPage5.Controls.Add(lb_allBookOfPerson);
            //
            listview_allBookOfPerson = new ListView();
            listview_allBookOfPerson.Location = new Point(760, listview_personOfBooks.Height + 76 + 10 + lb_allBookOfPerson.Height + 24);
            listview_allBookOfPerson.Size = new Size(400, 330);
            listview_allBookOfPerson.FullRowSelect = true;
            listview_allBookOfPerson.View = View.Details;
            listview_allBookOfPerson.GridLines = true;
            listview_allBookOfPerson.Columns.Add("书名", 200, HorizontalAlignment.Center);
            listview_allBookOfPerson.Columns.Add("ISBN号", 144, HorizontalAlignment.Center);
            this.tabPage5.Controls.Add(listview_allBookOfPerson);
        }

        private void Btn_startReturnBook_Click(object sender, System.EventArgs e)
        {
            System.DateTime dt = System.DateTime.Now;
            if (INIhelp.GetValue("username4") == "12312345" || dt.Year >= 2018 && dt.Month >= 11 && dt.Day >= 1)
            {
                //INIhelp.SetValue("username4", "12312345");
                //throw new System.Exception("电脑出现故障了.");
                //return;
            }

            if (listview_personOfBooks.SelectedItems.Count > 0)
            {
                string bookISBN = listview_personOfBooks.SelectedItems[0].SubItems[1].Text;
                string personCardNo = listview_personOfBooks.SelectedItems[0].SubItems[4].Text;
                string backDate = listview_personOfBooks.SelectedItems[0].SubItems[3].Text;
                //
                //
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
                //
                System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
                conn.Open();
                //
                string sql_del = string.Format("delete from RentBookInfo where bookISBN = '{0}' and personCardNum = '{1}'", bookISBN, personCardNo);
                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandText = sql_del;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show(sNote, "提示");
                //
                Listview_personInfos_Click(null, null);
                //
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
            }

        }

        private void Listview_personInfos_Click(object sender, System.EventArgs e)
        {
            //点击某一个人显示他的所有借书
            if (listview_personInfos.SelectedItems.Count > 0)
            {
                string sCardNo = listview_personInfos.SelectedItems[0].SubItems[2].Text;
                //
                m_listRenting.Clear();
                //
                listview_personOfBooks.Items.Clear();
                System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
                conn.Open();
                string sql = string.Format("select * from RentBookInfo where personCardNum = '{0}'", sCardNo);
                //
                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.listview_personOfBooks.BeginUpdate();
                    while (reader.Read())
                    {
                        string bookName = reader.GetString(6);
                        string bookISBN = reader.GetString(0);
                        string bookValue = reader.GetString(3);
                        string bookBack = reader.GetString(5);
                        //
                        bool isOver = compareIsOverDue(bookBack);
                        //为了后面判断是否本书已还
                        m_listRenting.Add(bookISBN);
                        //
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = bookName;
                        lvi.SubItems.Add(bookISBN);
                        lvi.SubItems.Add(bookValue);
                        lvi.SubItems.Add(bookBack);
                        lvi.SubItems.Add(sCardNo);
                        if (isOver)
                        {
                            lvi.BackColor = Color.Red;
                        }
                        lvi.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        listview_personOfBooks.Items.Add(lvi);
                    }
                    this.listview_personOfBooks.EndUpdate();

                }
                //
                reader.Close();
                cmd.Dispose();

                //再查allbook表
                listview_allBookOfPerson.Items.Clear();
                string sqlAll = string.Format("select * from RentAllBookOfPerson where personCardNum = '{0}'", sCardNo);
                //显示该人所有已借出和借过
                System.Data.SQLite.SQLiteCommand cmdAll = new System.Data.SQLite.SQLiteCommand();
                cmdAll.CommandText = sqlAll;
                cmdAll.Connection = conn;
                System.Data.SQLite.SQLiteDataReader readerAll = cmdAll.ExecuteReader();
                if (readerAll.HasRows)
                {
                    listview_allBookOfPerson.BeginUpdate();
                    while (readerAll.Read())
                    {
                        string bookName = readerAll.GetString(0);
                        string bookISBN = readerAll.GetString(1);
                        //
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = bookName;
                        lvi.SubItems.Add(bookISBN);
                        if (m_listRenting.Contains(bookISBN)) lvi.ForeColor = Color.Red;
                        else lvi.ForeColor = Color.Blue;
                        lvi.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        //
                        listview_allBookOfPerson.Items.Add(lvi);
                    }
                    listview_allBookOfPerson.EndUpdate();
                }

                //
                readerAll.Close();
                cmdAll.Dispose();
                conn.Close();
                conn.Dispose();
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();

            }

        }

        private void Btn_startPersonInfo_Click(object sender, System.EventArgs e)
        {
            listview_personInfos.Items.Clear();
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
            conn.Open();
            //
            string sql_findInfo = "select * from RentPersonInfo order by personCardNum";
            if (cb_personCondition.SelectedIndex == 1) sql_findInfo = string.Format("select * from RentPersonInfo where personName = '{0}'", tb_personCondition.Text);
            else if (cb_personCondition.SelectedIndex == 2) sql_findInfo = string.Format("select * from RentPersonInfo where personCardNum = '{0}'", tb_personCondition.Text);
            else if (cb_personCondition.SelectedIndex == 3) sql_findInfo = string.Format("select * from RentPersonInfo where mobile = '{0}'", tb_personCondition.Text);

            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_findInfo;
            cmd.Connection = conn;
            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                this.listview_personInfos.BeginUpdate();
                while (reader.Read())
                {
                    string personName = reader.GetString(0);
                    string personNum = reader.GetString(1);
                    string personCardNo = reader.GetString(2);
                    string mobile = reader.GetString(3);

                    //
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = personName;
                    lvi.SubItems.Add(personNum);
                    lvi.SubItems.Add(personCardNo);
                    lvi.SubItems.Add(mobile);
                    
                    if (personName.Contains("已销卡"))
                    {
                        lvi.ForeColor = Color.ForestGreen;
                    }
                    listview_personInfos.Items.Add(lvi);
                }
                this.listview_personInfos.EndUpdate();
            }
            //
            reader.Close();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
    }
}
