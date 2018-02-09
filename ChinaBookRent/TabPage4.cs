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

        //
        private void initTabPage4()
        {
            label_type = new Label();
            label_type.Location = new Point(30, 65);
            label_type.AutoSize = true;
            this.label_type.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_type.Text = "选择书籍查询条件：";
            this.tabPage4.Controls.Add(label_type);

            //
            combo_type = new ComboBox();
            combo_type.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_type.Items.Add("按书名查询");
            combo_type.Items.Add("按ISBN查询");
            combo_type.Items.Add("按出版社查询");
            this.combo_type.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            combo_type.Size = new Size(combo_type.Width + 40, combo_type.Height);
            combo_type.Location = new Point(200, 60);
            this.tabPage4.Controls.Add(combo_type);
            combo_type.SelectedIndex = 0;
            //
            tb_condition = new TextBox();
            tb_condition.Location = new Point(200 + combo_type.Width + 20, 60);
            this.tb_condition.Font = new Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            tb_condition.Size = new Size(tb_condition.Size.Width + 100, tb_condition.Size.Height);
            this.tabPage4.Controls.Add(tb_condition);
            //
            btn_startFindBooks = new Button();
            btn_startFindBooks.Location = new Point(200 + combo_type.Width + 95, 104);
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
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=C:\\MyOwnProject\\ChinaBookRent\\ChinaBookRent\\bin\\Debug\\ChinaBookRent.db;Pooling=true;FailIfMissing=false");
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
            cmd.Dispose();
            conn.Close();
        }

        private void Btn_startFindBooks_Click(object sender, System.EventArgs e)
        {
            //
            listview_books.Items.Clear();
            //
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=C:\\MyOwnProject\\ChinaBookRent\\ChinaBookRent\\bin\\Debug\\ChinaBookRent.db;Pooling=true;FailIfMissing=false");
            conn.Open();
            //
            int nSel = combo_type.SelectedIndex;
            string sql_findbook = string.Format("select * from RentBookInfo where bookName like '%{0}%'", tb_condition.Text);
            //
            if (nSel == 1)
                sql_findbook = string.Format("select * from RentBookInfo where bookISBN = '{0}'", tb_condition.Text);
            else if (nSel == 2)
                sql_findbook = string.Format("select * from RentBookInfo where bookPublisher = '{0}'", tb_condition.Text);
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
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = bookName;
                    lvi.SubItems.Add(bookISBN);
                    lvi.SubItems.Add(personCardNum);
                    lvi.SubItems.Add(bookOutDate);
                    lvi.SubItems.Add(bookBackDate);
                    lvi.SubItems.Add(bookValue);
                    lvi.SubItems.Add(publisher);
                    listview_books.Items.Add(lvi);
                }
                this.listview_books.EndUpdate();
            }
            cmd.Dispose();
            conn.Close();
        }
    }
}
