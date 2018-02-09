using System.Windows.Forms;
using System.Drawing;

namespace ChinaBookRent
{
    partial class Form1
    {
        private Label label_backBookISBN;
        private Label label_backPersonCardNum;
        //
        private TextBox textBox_backBookISBN;
        private TextBox textBox_backPersonCardNum;
        //
        private Button btn_startBackBook;

        private void initTabPage3()
        {
            tabPage3.BackColor = Color.AliceBlue;

            this.label_backBookISBN = new Label();
            this.label_backBookISBN.Location = new Point(50, 50);
            this.label_backBookISBN.Text = "请输入书籍ISBN号码：";
            this.label_backBookISBN.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_backBookISBN.AutoSize = true;
            this.tabPage3.Controls.Add(label_backBookISBN);
            //
            textBox_backBookISBN = new TextBox();
            textBox_backBookISBN.Location = new Point(50 + label_backBookISBN.Size.Width + 20, 45);
            this.textBox_backBookISBN.Size = new Size(textBox_backBookISBN.Size.Width + 130, textBox_backBookISBN.Size.Height);
            this.tabPage3.Controls.Add(textBox_backBookISBN);

            //
            this.label_backPersonCardNum = new Label();
            this.label_backPersonCardNum.Location = new Point(50, 130);
            this.label_backPersonCardNum.Text = "请输入人员卡号：";
            this.label_backPersonCardNum.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_backPersonCardNum.AutoSize = true;
            this.tabPage3.Controls.Add(label_backPersonCardNum);
            //
            textBox_backPersonCardNum = new TextBox();
            textBox_backPersonCardNum.Location = new Point(50 + label_backPersonCardNum.Size.Width + 20, 125);
            this.textBox_backPersonCardNum.Size = new Size(textBox_backPersonCardNum.Size.Width + 130, textBox_backPersonCardNum.Size.Height);
            this.tabPage3.Controls.Add(textBox_backPersonCardNum);

            //
            //
            btn_startBackBook = new Button();
            btn_startBackBook.Location = new Point(50 + label_backPersonCardNum.Size.Width + 20, 170);
            btn_startBackBook.AutoSize = true;
            btn_startBackBook.Text = "还书";
            btn_startBackBook.Font = new Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.Controls.Add(btn_startBackBook);
            btn_startBackBook.Click += Btn_startBackBook_Click;
        }

        private void Btn_startBackBook_Click(object sender, System.EventArgs e)
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=C:\\MyOwnProject\\ChinaBookRent\\ChinaBookRent\\bin\\Debug\\ChinaBookRent.db;Pooling=true;FailIfMissing=false");
            conn.Open();
            //
            string sql_del = string.Format("delete from RentBookInfo where bookISBN = '{0}' and personCardNum = '{1}'", textBox_backBookISBN.Text, textBox_backPersonCardNum.Text);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_del;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("还书成功", "提示");
            //
            cmd.Dispose();
            conn.Close();
        }
    }
}
