

namespace ChinaBookRent
{
    partial class Form1
    {
        private System.Windows.Forms.Label label_CheckBook;
        private System.Windows.Forms.TextBox TextBox_CheckBookISBN;
        private System.Windows.Forms.Button btn_CheckBook;
        private System.Windows.Forms.Label label_Cut;
        //
        private System.Windows.Forms.Label label_bookName;
        private System.Windows.Forms.Label label_bookISBN;
        private System.Windows.Forms.Label label_personCardNum;
        private System.Windows.Forms.Label label_bookPublisher;
        private System.Windows.Forms.Label label_bookOutDate;
        private System.Windows.Forms.Label label_bookValue;
        private System.Windows.Forms.Label label_bookBackDate;
        //
        private System.Windows.Forms.TextBox TextBox_bookName;
        private System.Windows.Forms.TextBox TextBox_bookISBN;
        private System.Windows.Forms.TextBox TextBox_personCardNum;
        private System.Windows.Forms.TextBox TextBox_bookPublisher;
        private System.Windows.Forms.DateTimePicker DataPic_bookOutDate;
        private System.Windows.Forms.DateTimePicker DataPic_bookBackDate;
        private System.Windows.Forms.TextBox TextBox_bookValue;

        //
        private System.Windows.Forms.Button btn_startOutBook;

        private void initTabPage2()
        {
            tabPage2.BackColor = System.Drawing.Color.Ivory;
            this.label_CheckBook = new System.Windows.Forms.Label();
            this.label_CheckBook.Location = new System.Drawing.Point(30, 30);
            this.label_CheckBook.Text = "请检查此书是否可借出（请输入书籍ISBN号码）";
            this.label_CheckBook.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CheckBook.Size = new System.Drawing.Size(label_CheckBook.Size.Width + 250, label_CheckBook.Height);
            this.tabPage2.Controls.Add(label_CheckBook);
            //
            this.TextBox_CheckBookISBN = new System.Windows.Forms.TextBox();
            this.TextBox_CheckBookISBN.Location = new System.Drawing.Point(label_CheckBook.Width + 30, 25);
            this.TextBox_CheckBookISBN.Size = new System.Drawing.Size(TextBox_CheckBookISBN.Size.Width + 130, TextBox_CheckBookISBN.Size.Height);
            this.tabPage2.Controls.Add(TextBox_CheckBookISBN);
            //
            this.btn_CheckBook = new System.Windows.Forms.Button();
            this.btn_CheckBook.Location = new System.Drawing.Point(label_CheckBook.Width + 30, TextBox_CheckBookISBN.Height + 35);
            this.btn_CheckBook.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CheckBook.AutoSize = true;
            this.btn_CheckBook.Text = "开始检查";
            this.btn_CheckBook.Click += Btn_CheckBook_Click;
            this.tabPage2.Controls.Add(btn_CheckBook);
            //分割线
            label_Cut = new System.Windows.Forms.Label();
            label_Cut.AutoSize = false;
            label_Cut.BackColor = System.Drawing.Color.BurlyWood;
            label_Cut.Size = new System.Drawing.Size(1920, 3);
            label_Cut.Location = new System.Drawing.Point(0, 110);
            label_Cut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(label_Cut);

            //书籍名称
            label_bookName = new System.Windows.Forms.Label();
            label_bookName.Text = "书籍名称";
            label_bookName.AutoSize = true;
            label_bookName.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_bookName.Location = new System.Drawing.Point(50, 150);
            this.tabPage2.Controls.Add(label_bookName);
            //
            this.TextBox_bookName = new System.Windows.Forms.TextBox();
            this.TextBox_bookName.Location = new System.Drawing.Point(180, 145);
            this.TextBox_bookName.Size = new System.Drawing.Size(TextBox_bookName.Size.Width + 130, TextBox_bookName.Size.Height);
            this.tabPage2.Controls.Add(TextBox_bookName);

            //书籍ISBN
            label_bookISBN = new System.Windows.Forms.Label();
            label_bookISBN.Text = "书籍ISBN号码";
            label_bookISBN.AutoSize = true;
            label_bookISBN.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_bookISBN.Location = new System.Drawing.Point(50, 220);
            this.tabPage2.Controls.Add(label_bookISBN);
            //
            this.TextBox_bookISBN = new System.Windows.Forms.TextBox();
            this.TextBox_bookISBN.Location = new System.Drawing.Point(180, 215);
            this.TextBox_bookISBN.Size = new System.Drawing.Size(TextBox_bookISBN.Size.Width + 130, TextBox_bookISBN.Size.Height);
            this.tabPage2.Controls.Add(TextBox_bookISBN);


            //书籍出版社
            label_bookPublisher = new System.Windows.Forms.Label();
            label_bookPublisher.Text = "书籍出版社";
            label_bookPublisher.AutoSize = true;
            label_bookPublisher.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_bookPublisher.Location = new System.Drawing.Point(50, 290);
            this.tabPage2.Controls.Add(label_bookPublisher);
            //
            this.TextBox_bookPublisher = new System.Windows.Forms.TextBox();
            this.TextBox_bookPublisher.Location = new System.Drawing.Point(180, 285);
            this.TextBox_bookPublisher.Size = new System.Drawing.Size(TextBox_bookPublisher.Size.Width + 130, TextBox_bookPublisher.Size.Height);
            this.tabPage2.Controls.Add(TextBox_bookPublisher);

            //书籍价格
            label_bookValue = new System.Windows.Forms.Label();
            label_bookValue.Text = "书籍价格";
            label_bookValue.AutoSize = true;
            label_bookValue.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_bookValue.Location = new System.Drawing.Point(50, 360);
            this.tabPage2.Controls.Add(label_bookValue);
            //
            this.TextBox_bookValue = new System.Windows.Forms.TextBox();
            this.TextBox_bookValue.Location = new System.Drawing.Point(180, 355);
            this.TextBox_bookValue.Size = new System.Drawing.Size(TextBox_bookValue.Size.Width + 130, TextBox_bookValue.Size.Height);
            this.tabPage2.Controls.Add(TextBox_bookValue);

            //书籍借出日期
            label_bookOutDate = new System.Windows.Forms.Label();
            label_bookOutDate.Text = "书籍借出日期";
            label_bookOutDate.AutoSize = true;
            label_bookOutDate.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_bookOutDate.Location = new System.Drawing.Point(50, 430);
            this.tabPage2.Controls.Add(label_bookOutDate);
            //
            DataPic_bookOutDate = new System.Windows.Forms.DateTimePicker();
            DataPic_bookOutDate.Location = new System.Drawing.Point(180, 425);
            this.tabPage2.Controls.Add(DataPic_bookOutDate);
            //
            DataPic_bookOutDate.ValueChanged += DataPic_bookOutDate_ValueChanged;

            //书籍归还日期
            label_bookBackDate = new System.Windows.Forms.Label();
            label_bookBackDate.Text = "书籍还回日期";
            label_bookBackDate.AutoSize = true;
            label_bookBackDate.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_bookBackDate.Location = new System.Drawing.Point(50, 500);
            this.tabPage2.Controls.Add(label_bookBackDate);
            //
            //
            DataPic_bookBackDate = new System.Windows.Forms.DateTimePicker();
            DataPic_bookBackDate.Location = new System.Drawing.Point(180, 495);
            this.tabPage2.Controls.Add(DataPic_bookBackDate);
            //
            //
            System.DateTime dt = DataPic_bookOutDate.Value;
            System.DateTime dtBack = dt + new System.TimeSpan(29, 0, 0, 0);
            DataPic_bookBackDate.Value = dtBack;

            //借书人卡号
            label_personCardNum = new System.Windows.Forms.Label();
            label_personCardNum.Text = "借书人卡号";
            label_personCardNum.AutoSize = true;
            label_personCardNum.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_personCardNum.Location = new System.Drawing.Point(50, 570);
            this.tabPage2.Controls.Add(label_personCardNum);
            //
            this.TextBox_personCardNum = new System.Windows.Forms.TextBox();
            this.TextBox_personCardNum.Location = new System.Drawing.Point(180, 565);
            this.TextBox_personCardNum.Size = new System.Drawing.Size(TextBox_personCardNum.Size.Width + 130, TextBox_personCardNum.Size.Height);
            this.tabPage2.Controls.Add(TextBox_personCardNum);

            //
            //
            btn_startOutBook = new System.Windows.Forms.Button();
            btn_startOutBook.Location = new System.Drawing.Point(250, 620);
            btn_startOutBook.AutoSize = true;
            btn_startOutBook.Text = "确认借出书籍";
            btn_startOutBook.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Controls.Add(btn_startOutBook);
            btn_startOutBook.Click += Btn_startOutBook_Click;
        }

        private void DataPic_bookOutDate_ValueChanged(object sender, System.EventArgs e)
        {
            System.DateTime dt = DataPic_bookOutDate.Value;
            System.DateTime dtBack = dt + new System.TimeSpan(29, 0, 0, 0);
            DataPic_bookBackDate.Value = dtBack;
        }

        private void Btn_startOutBook_Click(object sender, System.EventArgs e)
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=C:\\MyOwnProject\\ChinaBookRent\\ChinaBookRent\\bin\\Debug\\ChinaBookRent.db;Pooling=true;FailIfMissing=false");
            conn.Open();
            string sql_insert = string.Format("insert into RentBookInfo values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                        TextBox_bookISBN.Text, TextBox_personCardNum.Text, TextBox_bookPublisher.Text, TextBox_bookValue.Text, DataPic_bookOutDate.Text, DataPic_bookBackDate.Text, TextBox_bookName.Text);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_insert;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("新建借书成功", "提示");
            //
            cmd.Dispose();
            conn.Close();
        }

        private void Btn_CheckBook_Click(object sender, System.EventArgs e)
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=C:\\MyOwnProject\\ChinaBookRent\\ChinaBookRent\\bin\\Debug\\ChinaBookRent.db;Pooling=true;FailIfMissing=false");
            conn.Open();
            //
            int iCount = 0;
            //
            string sql_checkbook = string.Format("select * from RentBookInfo where bookISBN = {0}", TextBox_CheckBookISBN.Text);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_checkbook;
            cmd.Connection = conn;
            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    iCount += 1;
                }
            }
            if (iCount == 2) System.Windows.Forms.MessageBox.Show("此书借出已达到两本，不可借出", "提示");
            else System.Windows.Forms.MessageBox.Show("此书可借出", "提示");
            cmd.Dispose();
            conn.Close();
        }
    }
}
