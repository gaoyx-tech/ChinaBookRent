using System.Windows.Forms;
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
            listview_personInfos.Columns.Add("姓名", 100, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("身份证号", 200, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("借书卡号", 180, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("手机号", 160, HorizontalAlignment.Center);
            this.tabPage5.Controls.Add(listview_personInfos);
            listview_personInfos.Click += Listview_personInfos_Click;
            //
            //
            listview_personOfBooks = new ListView();
            listview_personOfBooks.Location = new Point(760, 76);
            listview_personOfBooks.Size = new Size(400, 300);
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
            btn_startReturnBook.Location = new Point(760, 400);
            btn_startReturnBook.Text = "开始还书";
            btn_startReturnBook.AutoSize = true;
            btn_startReturnBook.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage5.Controls.Add(btn_startReturnBook);
            //
            btn_startReturnBook.Click += Btn_startReturnBook_Click;
        }

        private void Btn_startReturnBook_Click(object sender, System.EventArgs e)
        {
            if (listview_personOfBooks.SelectedItems.Count > 0)
            {
                string bookISBN = listview_personOfBooks.SelectedItems[0].SubItems[1].Text;
                string personCardNo = listview_personOfBooks.SelectedItems[0].SubItems[4].Text;
                //
                System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
                conn.Open();
                //
                string sql_del = string.Format("delete from RentBookInfo where bookISBN = '{0}' and personCardNum = '{1}'", bookISBN, personCardNo);
                System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
                cmd.CommandText = sql_del;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("还书成功", "提示");
                //
                Listview_personInfos_Click(null, null);
                cmd.Dispose();
                conn.Close();
            }

        }

        private void Listview_personInfos_Click(object sender, System.EventArgs e)
        {
            //点击某一个人显示他的所有借书
            if (listview_personInfos.SelectedItems.Count > 0)
            {
                string sCardNo = listview_personInfos.SelectedItems[0].SubItems[2].Text;
                //
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
                        listview_personOfBooks.Items.Add(lvi);
                    }
                    this.listview_personOfBooks.EndUpdate();

                }
            }

        }

        private void Btn_startPersonInfo_Click(object sender, System.EventArgs e)
        {
            listview_personInfos.Items.Clear();
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
            conn.Open();
            //
            string sql_findInfo = "select * from RentPersonInfo";
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
                    listview_personInfos.Items.Add(lvi);
                }
                this.listview_personInfos.EndUpdate();
            }
            cmd.Dispose();
            conn.Close();
        }
    }
}
