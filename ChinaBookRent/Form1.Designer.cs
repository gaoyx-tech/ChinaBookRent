using System.Data.SQLite;
using System.Data;

namespace ChinaBookRent
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label labelPersonName;
        private System.Windows.Forms.Label labelPersonCardNum;
        private System.Windows.Forms.Label labelPersonPersonNum;
        private System.Windows.Forms.Label labelPersonMobile;
        private System.Windows.Forms.Label labelPersonCardDate;
        private System.Windows.Forms.Label labelPersonMoneyNum;
        private System.Windows.Forms.TextBox TextBoxPersonName;
        private System.Windows.Forms.TextBox TextBoxPersonCardNum;
        private System.Windows.Forms.TextBox TextBoxPersonNum;
        private System.Windows.Forms.TextBox TextBoxMobile;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.TextBox TextBoxMoneyNum;
        private System.Windows.Forms.Button btn_createPerson;
        private System.Windows.Forms.Button btn_deletePerson;
        private System.Windows.Forms.Label label_delPersonNote;

        private void initTabPage1()
        {
            tabPage1.BackColor = System.Drawing.Color.Azure;
            
            this.labelPersonName = new System.Windows.Forms.Label();
            this.labelPersonName.AutoSize = true;
            this.labelPersonName.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPersonName.Location = new System.Drawing.Point(100, 60);
            this.labelPersonName.Text = "借书人姓名";
            this.tabPage1.Controls.Add(labelPersonName);
            //
            this.TextBoxPersonName = new System.Windows.Forms.TextBox();
            this.TextBoxPersonName.Location = new System.Drawing.Point(230, 55);
            this.TextBoxPersonName.Size = new System.Drawing.Size(this.TextBoxPersonName.Size.Width + 50, this.TextBoxPersonName.Size.Height);
            this.TextBoxPersonName.Focus();
            this.TextBoxPersonName.Enabled = true;
            this.tabPage1.Controls.Add(TextBoxPersonName);

            this.labelPersonCardNum = new System.Windows.Forms.Label();
            this.labelPersonCardNum.AutoSize = true;
            this.labelPersonCardNum.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPersonCardNum.Location = new System.Drawing.Point(100, 130);
            this.labelPersonCardNum.Text = "借书人卡号";
            this.tabPage1.Controls.Add(labelPersonCardNum);
            //
            this.TextBoxPersonCardNum = new System.Windows.Forms.TextBox();
            this.TextBoxPersonCardNum.Location = new System.Drawing.Point(230, 125);
            this.TextBoxPersonCardNum.Size = new System.Drawing.Size(this.TextBoxPersonName.Size.Width + 50, this.TextBoxPersonName.Size.Height);
            this.tabPage1.Controls.Add(TextBoxPersonCardNum);

            this.labelPersonPersonNum = new System.Windows.Forms.Label();
            this.labelPersonPersonNum.AutoSize = true;
            this.labelPersonPersonNum.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPersonPersonNum.Location = new System.Drawing.Point(100, 200);
            this.labelPersonPersonNum.Text = "借书人身份证号";
            this.tabPage1.Controls.Add(labelPersonPersonNum);
            //
            this.TextBoxPersonNum = new System.Windows.Forms.TextBox();
            this.TextBoxPersonNum.Location = new System.Drawing.Point(230, 195);
            this.TextBoxPersonNum.Size = new System.Drawing.Size(this.TextBoxPersonName.Size.Width + 50, this.TextBoxPersonName.Size.Height);
            this.tabPage1.Controls.Add(TextBoxPersonNum);

            this.labelPersonMobile = new System.Windows.Forms.Label();
            this.labelPersonMobile.AutoSize = true;
            this.labelPersonMobile.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPersonMobile.Location = new System.Drawing.Point(100, 270);
            this.labelPersonMobile.Text = "借书人手机号";
            this.tabPage1.Controls.Add(labelPersonMobile);
            //
            this.TextBoxMobile = new System.Windows.Forms.TextBox();
            this.TextBoxMobile.Location = new System.Drawing.Point(230, 265);
            this.TextBoxMobile.Size = new System.Drawing.Size(this.TextBoxPersonName.Size.Width + 50, this.TextBoxPersonName.Size.Height);
            this.tabPage1.Controls.Add(TextBoxMobile);

            this.labelPersonCardDate = new System.Windows.Forms.Label();
            this.labelPersonCardDate.AutoSize = true;
            this.labelPersonCardDate.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPersonCardDate.Location = new System.Drawing.Point(100, 340);
            this.labelPersonCardDate.Text = "办卡日期";
            this.tabPage1.Controls.Add(labelPersonCardDate);
            //
            DatePicker = new System.Windows.Forms.DateTimePicker();
            this.DatePicker.Location = new System.Drawing.Point(230, 335);
            this.tabPage1.Controls.Add(DatePicker);

            this.labelPersonMoneyNum = new System.Windows.Forms.Label();
            this.labelPersonMoneyNum.AutoSize = true;
            this.labelPersonMoneyNum.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPersonMoneyNum.Location = new System.Drawing.Point(100, 410);
            this.labelPersonMoneyNum.Text = "收据号";
            this.tabPage1.Controls.Add(labelPersonMoneyNum);
            //
            this.TextBoxMoneyNum = new System.Windows.Forms.TextBox();
            this.TextBoxMoneyNum.Location = new System.Drawing.Point(230, 405);
            this.TextBoxMoneyNum.Size = new System.Drawing.Size(this.TextBoxPersonName.Size.Width + 50, this.TextBoxPersonName.Size.Height);
            this.tabPage1.Controls.Add(TextBoxMoneyNum);

            this.btn_createPerson = new System.Windows.Forms.Button();
            this.btn_createPerson.Location = new System.Drawing.Point(100, 510);
            this.btn_createPerson.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_createPerson.Text = "新建借书人员";
            this.btn_createPerson.Size = new System.Drawing.Size(btn_createPerson.Size.Width + 80, btn_createPerson.Size.Height + 10);
            this.tabPage1.Controls.Add(btn_createPerson);
            //
            this.btn_deletePerson = new System.Windows.Forms.Button();
            this.btn_deletePerson.Location = new System.Drawing.Point(300, 510);
            this.btn_deletePerson.Text = "删除借书人员";
            this.btn_deletePerson.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_deletePerson.Size = new System.Drawing.Size(btn_deletePerson.Size.Width + 80, btn_deletePerson.Size.Height + 10);
            this.tabPage1.Controls.Add(btn_deletePerson);
            //
            this.label_delPersonNote = new System.Windows.Forms.Label();
            this.label_delPersonNote.AutoSize = true;
            this.label_delPersonNote.Location = new System.Drawing.Point(470, 518);
            this.label_delPersonNote.Font = new System.Drawing.Font("黑体", 13F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_delPersonNote.Text = "（注：删除借书人记录只需填写借书人卡号，其他非必须）";
            this.tabPage1.Controls.Add(label_delPersonNote);

            //
            this.btn_createPerson.Click += Btn_createPerson_Click;
            this.btn_deletePerson.Click += Btn_deletePerson_Click;
        }

        private void Btn_deletePerson_Click(object sender, System.EventArgs e)
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=C:\\MyOwnProject\\ChinaBookRent\\ChinaBookRent\\bin\\Debug\\ChinaBookRent.db;Pooling=true;FailIfMissing=false");
            conn.Open();
            //
            string sql_del = string.Format("delete from RentPersonInfo where personCardNum = '{0}'", TextBoxPersonCardNum.Text);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_del;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("删除借书人员成功", "提示");
            //
            cmd.Dispose();
            conn.Close();
        }

        private void Btn_createPerson_Click(object sender, System.EventArgs e)
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection("Data Source=C:\\MyOwnProject\\ChinaBookRent\\ChinaBookRent\\bin\\Debug\\ChinaBookRent.db;Pooling=true;FailIfMissing=false");
            conn.Open();
            //
            string sql_insert = string.Format("insert into RentPersonInfo values ('{0}','{1}','{2}','{3}','{4}','{5}')",
                TextBoxPersonName.Text, TextBoxPersonNum.Text, TextBoxPersonCardNum.Text, TextBoxMobile.Text, DatePicker.Text, TextBoxMoneyNum.Text);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_insert;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("新建借书人员成功", "提示");
            //
            cmd.Dispose();
            conn.Close();
        }

        private void InitializeComponent()
        {
            this.BackColor = System.Drawing.Color.White;
            this.lableWelcome = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lableWelcome
            // 
            this.lableWelcome.AutoSize = true;
            this.lableWelcome.Font = new System.Drawing.Font("微软雅黑", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Bold)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lableWelcome.Location = new System.Drawing.Point(20, 20);
            this.lableWelcome.Size = new System.Drawing.Size(432, 27);
            this.lableWelcome.Text = "欢迎使用本借阅系统（中国书店西黄城根南街）";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            //this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("幼圆", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 59);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1917, 948);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1909, 914);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "借书人员管理";
            this.tabPage1.UseVisualStyleBackColor = true;
            //
            initTabPage1();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1909, 914);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "办理借出书籍";
            this.tabPage2.UseVisualStyleBackColor = true;
            //
            this.initTabPage2();
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1909, 914);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "办理还回书籍";
            this.tabPage3.UseVisualStyleBackColor = true;
            //
            initTabPage3();
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1909, 914);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "按书籍查询信息";
            this.tabPage4.UseVisualStyleBackColor = true;
            //
            initTabPage4();
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 30);
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1909, 914);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "按人员查询借书信息";
            this.tabPage5.UseVisualStyleBackColor = true;
            //
            initTabPage5();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1055);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lableWelcome);
            this.Name = "Form1";
            this.Text = "中国书店西黄城根南街店借阅系统";

        }

        private System.Windows.Forms.Label lableWelcome;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
    }
}

