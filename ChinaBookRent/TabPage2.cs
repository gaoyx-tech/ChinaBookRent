
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using ChinaBookRentDataClass;
using System.Text.RegularExpressions;
using System;
using System.Drawing;

namespace ChinaBookRent
{
    partial class Form1
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private Label label_CheckBook;
        private TextBox TextBox_CheckBookISBN;
        private Button btn_CheckBook;
        private Label label_Cut;
        //
        private PictureBox pic_cover;
        private Label lb_intro;
        private Label lb_author;
        //
        private Label label_bookName;
        private Label label_bookISBN;
        private Label label_personCardNum;
        private Label label_bookPublisher;
        private Label label_bookOutDate;
        private Label label_bookValue;
        private Label label_bookBackDate;
        //
        private TextBox TextBox_bookName;
        private TextBox TextBox_bookISBN;
        private TextBox TextBox_personCardNum;
        private TextBox TextBox_bookPublisher;
        private DateTimePicker DataPic_bookOutDate;
        private DateTimePicker DataPic_bookBackDate;
        private TextBox TextBox_bookValue;

        //
        private Button btn_startOutBook;
        //
        private Label lb_checkPersonCanRent;
        private TextBox tb_checkPersonCanRent;
        private Button btn_checkPersonCanRent;
        //
        private Button btn_clearISBN;
        //
        Timer timerGetFirst;
        Timer timerGetSecond;
        Timer timerGetThird;
        //
        private ListView listview_ddwNetData;
        //待选书籍
        System.Collections.Generic.List<ProductsItem> ddwNetItems = new System.Collections.Generic.List<ProductsItem>();

        private void initTabPage2()
        {
            tabPage2.BackColor = System.Drawing.Color.Ivory;
            this.label_CheckBook = new System.Windows.Forms.Label();
            this.label_CheckBook.Location = new System.Drawing.Point(30, 30);
            this.label_CheckBook.Text = "请检查此书是否可借出（请输入书籍ISBN号码）";
            this.label_CheckBook.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CheckBook.AutoSize = true;
            this.tabPage2.Controls.Add(label_CheckBook);
            //
            this.TextBox_CheckBookISBN = new System.Windows.Forms.TextBox();
            this.TextBox_CheckBookISBN.Location = new System.Drawing.Point(label_CheckBook.Width + 35, 25);
            this.TextBox_CheckBookISBN.Size = new System.Drawing.Size(TextBox_CheckBookISBN.Size.Width + 50, TextBox_CheckBookISBN.Size.Height);
            this.tabPage2.Controls.Add(TextBox_CheckBookISBN);
            //
            this.btn_CheckBook = new System.Windows.Forms.Button();
            this.btn_CheckBook.Location = new System.Drawing.Point(label_CheckBook.Width + 35, TextBox_CheckBookISBN.Height + 35);
            this.btn_CheckBook.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CheckBook.AutoSize = true;
            this.btn_CheckBook.Text = "开始检查";
            this.btn_CheckBook.Click += Btn_CheckBook_Click;
            this.tabPage2.Controls.Add(btn_CheckBook);

            //
            //检查此人是否再可借书
            lb_checkPersonCanRent = new System.Windows.Forms.Label();
            lb_checkPersonCanRent.Location = new System.Drawing.Point(label_CheckBook.Width + TextBox_CheckBookISBN.Width + 60, 30);
            lb_checkPersonCanRent.AutoSize = true;
            lb_checkPersonCanRent.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            lb_checkPersonCanRent.Text = "检查此读者是否再可借书（请输入读者卡号）";
            this.tabPage2.Controls.Add(lb_checkPersonCanRent);
            //
            tb_checkPersonCanRent = new System.Windows.Forms.TextBox();
            tb_checkPersonCanRent.Size = new System.Drawing.Size(tb_checkPersonCanRent.Size.Width + 50, tb_checkPersonCanRent.Size.Height);
            tb_checkPersonCanRent.Location = new System.Drawing.Point(30 + label_CheckBook.Width + TextBox_CheckBookISBN.Width + 35 + lb_checkPersonCanRent.Width, 25);
            this.tabPage2.Controls.Add(tb_checkPersonCanRent);
            //
            btn_checkPersonCanRent = new System.Windows.Forms.Button();
            btn_checkPersonCanRent.Location = new System.Drawing.Point(30 + label_CheckBook.Width + TextBox_CheckBookISBN.Width + 35 + lb_checkPersonCanRent.Width, tb_checkPersonCanRent.Height + 35);
            btn_checkPersonCanRent.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            btn_checkPersonCanRent.Text = "检查读者";
            btn_checkPersonCanRent.AutoSize = true;
            this.tabPage2.Controls.Add(btn_checkPersonCanRent);
            btn_checkPersonCanRent.Click += Btn_checkPersonCanRent_Click;

            //-----------------------------------------------------------------------------------------------------------------------------------

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
            label_bookName.Location = new System.Drawing.Point(50, 220);

            this.tabPage2.Controls.Add(label_bookName);
            //
            this.TextBox_bookName = new System.Windows.Forms.TextBox();
            this.TextBox_bookName.Location = new System.Drawing.Point(180, 215);
            TextBox_bookName.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBox_bookName.Size = new System.Drawing.Size(TextBox_bookName.Size.Width + 200, TextBox_bookName.Size.Height);
            this.tabPage2.Controls.Add(TextBox_bookName);

            //书籍封面
            pic_cover = new System.Windows.Forms.PictureBox();
            pic_cover.Location = new System.Drawing.Point(TextBox_bookName.Width + 285, 145);
            pic_cover.Size = new System.Drawing.Size(180, 220);
            pic_cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic_cover.BorderStyle = BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(pic_cover);

            //
            //
            lb_intro = new System.Windows.Forms.Label();
            lb_intro.Location = new System.Drawing.Point(TextBox_bookName.Width + 280, 400);
            lb_intro.Size = new System.Drawing.Size(400, 460);
            lb_intro.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Controls.Add(lb_intro);

            //
            lb_author = new System.Windows.Forms.Label();
            lb_author.Location = new System.Drawing.Point(TextBox_bookName.Width + 280, 375);
            lb_author.AutoSize = true;
            lb_author.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Controls.Add(lb_author);

            //当当网总数据选择listview
            listview_ddwNetData = new ListView();
            listview_ddwNetData.Location = new System.Drawing.Point(TextBox_bookName.Width + 300 + lb_intro.Width, 150);
            listview_ddwNetData.Size = new System.Drawing.Size(500, 550);
            listview_ddwNetData.View = View.LargeIcon;
            this.tabPage2.Controls.Add(listview_ddwNetData);
            listview_ddwNetData.Click += Listview_ddwNetData_Click;

            //书籍ISBN
            label_bookISBN = new System.Windows.Forms.Label();
            label_bookISBN.Text = "书籍ISBN号码";
            label_bookISBN.AutoSize = true;
            label_bookISBN.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label_bookISBN.Location = new System.Drawing.Point(50, 150);
            this.tabPage2.Controls.Add(label_bookISBN);
            //
            this.TextBox_bookISBN = new System.Windows.Forms.TextBox();
            this.TextBox_bookISBN.Location = new System.Drawing.Point(180, 145);
            this.TextBox_bookISBN.Size = new System.Drawing.Size(TextBox_bookISBN.Size.Width + 130, TextBox_bookISBN.Size.Height);
            this.tabPage2.Controls.Add(TextBox_bookISBN);
            //输入ISBN后请求其他图书数据
            TextBox_bookISBN.TextChanged += TextBox_bookISBN_TextChanged_ForNet;

            //
            btn_clearISBN = new System.Windows.Forms.Button();
            btn_clearISBN.Location = new System.Drawing.Point(180 + TextBox_bookISBN.Width + 10, 145);
            btn_clearISBN.AutoSize = true;
            btn_clearISBN.Text = "重新输入ISBN号码";
            btn_clearISBN.Font = new System.Drawing.Font("黑体", 12F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Controls.Add(btn_clearISBN);
            btn_clearISBN.Click += Btn_clearISBN_Click;

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
            TextBox_bookPublisher.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            TextBox_bookValue.Font = new System.Drawing.Font("黑体", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            System.DateTime dtBack = dt + new System.TimeSpan(30, 0, 0, 0);
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

            //
            timerGetFirst = new Timer();
            timerGetFirst.Interval = 1000;
            timerGetFirst.Tick += TimerGetFirst_Tick;
            //
            timerGetSecond = new Timer();
            timerGetSecond.Interval = 1000;
            timerGetSecond.Tick += TimerGetSecond_Tick;
            //
            timerGetThird = new Timer();
            timerGetThird.Interval = 1000;
            timerGetThird.Tick += TimerGetThird_Tick; ;
        }

        private void TimerGetThird_Tick(object sender, System.EventArgs e)
        {
            string sReq = string.Format("http://search.mapi.dangdang.com/index.php?result_set_all_count=0&access-token=&time_code=e3d18d2284002f6d05368d9588ba53cb&img_size=h&client_version=8.2.0&action=all_search&union_id=537-100475&timestamp=1519490207&permanent_id=20170531142204977636164247492279621&global_province_id=111&sort_type=default_0&keyword={0}&page_size=10&udid=95798828046877677e5d8e23f970beec&loadad=1&user_client=android&page=1&filter_from=keyword&has_used_recommend=0",
                TextBox_bookISBN.Text);
            System.Net.WebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sReq);
            req.Timeout = 10000;
            req.Method = "GET";

            //
            using (System.Net.WebResponse wr = req.GetResponse())
            {
                ddwNetItems.Clear();
                //在这里对接收到的页面内容进行处理
                StreamReader streamReader = new StreamReader(wr.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();
                //unicode转中文
                string sConvert = ToGB2312(responseContent);
                //解析json
                RootDdwNet bookInfo = JavaScriptConvert.DeserializeObject<RootDdwNet>(sConvert);
                foreach (ProductsItem pro in bookInfo.products)
                {
                    if (pro.cat_paths.StartsWith("01."))
                    {
                        ddwNetItems.Add(pro);
                    }
                }

                streamReader.Close();
            }

            //
            lb_intro.Text = "请从右边列表中选择一本图书，请核对价格及其他信息与图书是否吻合！！";
            listview_ddwNetData.Items.Clear();
            ImageList il = new ImageList();
            il.ImageSize = new Size(122, 100);
            int count = 0;
            foreach (ProductsItem pro in ddwNetItems)
            {
                //
                System.Net.WebRequest request = System.Net.WebRequest.Create(pro.image_url);
                System.Net.WebResponse resp = request.GetResponse();
                Stream respStream = resp.GetResponseStream();
                Bitmap bmp = new Bitmap(respStream);
                respStream.Dispose();
                il.Images.Add(bmp);
                listview_ddwNetData.LargeImageList = il;

                ListViewItem lst = new ListViewItem();
                lst.ForeColor = Color.DarkRed;
                lst.Font = new Font("黑体", 8F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lst.Text =  "作者：" + pro.authorname + "\r\n出版社：" + pro.publisher + "\r\n价格" + pro.original_price;
                lst.ImageIndex = count++;
                listview_ddwNetData.Items.Add(lst);
            }

            //关闭定时器
            timerGetThird.Stop();
        }

        private void TimerGetSecond_Tick(object sender, System.EventArgs e)
        {
            string sReq = string.Format("http://e.dangdang.com/media/api2.go?action=searchMedia&keyword={0}&start=0&end=20&stype=paper&enable_f=1", TextBox_bookISBN.Text);
            System.Net.WebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sReq);
            req.Timeout = 10000;
            req.Method = "GET";
            //
            using (System.Net.WebResponse wr = req.GetResponse())
            {
                //在这里对接收到的页面内容进行处理
                StreamReader streamReader = new StreamReader(wr.GetResponseStream());
                string responseContent = streamReader.ReadToEnd();
                Root bookInfo = JavaScriptConvert.DeserializeObject<Root>(responseContent);
                //插入控件中
                if (bookInfo.data.searchMediaPaperList.Count == 0)
                {
                    lb_intro.Text = "开始搜索豆瓣图书数据.......";
                    timerGetFirst.Start();
                }
                else
                {
                    TextBox_bookName.Text = bookInfo.data.searchMediaPaperList[0].title.Trim();
                    TextBox_bookPublisher.Text = bookInfo.data.searchMediaPaperList[0].publisher.Trim();
                    TextBox_bookValue.Text = bookInfo.data.searchMediaPaperList[0].originalPrice.ToString().Trim();
                    pic_cover.LoadAsync(bookInfo.data.searchMediaPaperList[0].mediaPic);
                    lb_intro.Text = "书籍简介：\r\n\r\n" + bookInfo.data.searchMediaPaperList[0].description;
                    lb_author.Text = "作者：" + bookInfo.data.searchMediaPaperList[0].author;
                }

                streamReader.Close();
            }
            timerGetSecond.Stop();
        }

        private void TimerGetFirst_Tick(object sender, System.EventArgs e)
        {
            string sReq = string.Format("https://api.douban.com/v2/book/isbn/:{0}", TextBox_bookISBN.Text);
            System.Net.WebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sReq);
            req.Method = "GET";
            try
            {
                using (System.Net.WebResponse wr = req.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                    StreamReader streamReader = new StreamReader(wr.GetResponseStream());
                    string responseContent = streamReader.ReadToEnd();
                    BookInfo bookInfo = JavaScriptConvert.DeserializeObject<BookInfo>(responseContent);
                    //网络数据插入到控件中
                    TextBox_bookName.Text = bookInfo.title;
                    TextBox_bookPublisher.Text = bookInfo.publisher;
                    TextBox_bookValue.Text = bookInfo.price.Replace("元", "").Replace("CNY", "").Replace("¥", "").Trim();
                    pic_cover.LoadAsync(bookInfo.images.large);
                    //
                    string sIntro = string.Format("书籍简介：\r\n\r\n{0}", bookInfo.summary);
                    lb_intro.Text = sIntro;
                    string sAuthors = "作者：";
                    foreach (string auth in bookInfo.author)
                    {
                        sAuthors += auth + " ";
                    }
                    lb_author.Text = sAuthors;

                    streamReader.Close();
                }
            }
            catch (System.SystemException e1)
            {
                lb_intro.Text = "开始搜索当当总网数据.......";
                //如果豆瓣图书和当当阅读都没有数据
                timerGetThird.Start();
            }
            timerGetFirst.Stop();
        }

        private void Btn_clearISBN_Click(object sender, System.EventArgs e)
        {
            TextBox_bookISBN.Clear();
            TextBox_bookISBN.Focus();
            TextBox_bookISBN.TabIndex = 0;
        }

        private void TextBox_bookISBN_TextChanged_ForNet(object sender, System.EventArgs e)
        {
            string sText = TextBox_bookISBN.Text;
            if (sText.Length == 13)
            {
                lb_intro.Text = "开始搜索当当阅读数据.......";
                //
                TextBox_bookName.Clear();
                TextBox_bookPublisher.Clear();
                TextBox_bookValue.Clear();
                lb_author.Text = "";
                pic_cover.Image = null;
                timerGetSecond.Start();
            }
        }

        private void Listview_ddwNetData_Click(object sender, EventArgs e)
        {
            int nindex = listview_ddwNetData.SelectedItems[0].Index;
            TextBox_bookName.Text = ddwNetItems[nindex].name;
            TextBox_bookPublisher.Text = ddwNetItems[nindex].publisher;
            TextBox_bookValue.Text = ddwNetItems[nindex].original_price;
        }

        private void Btn_checkPersonCanRent_Click(object sender, System.EventArgs e)
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
            conn.Open();
            //
            string sql = string.Format("select bookValue from RentBookInfo where personCardNum = '{0}'", tb_checkPersonCanRent.Text);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader();
            //
            int iCount = 0;
            double value = 0.0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    value += System.Double.Parse(reader.GetString(0));
                    ++iCount;
                }
            }
            //
            reader.Close();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            if (value >= 100 && value < 200 && iCount < 3)
            {
                string currentval = string.Format("读者当前已经借出总价大于100元的书,但还小于200元({0}元)，请注意", value);
                System.Windows.Forms.MessageBox.Show(currentval, "提示");
                return;
            }
            else if (value >= 200)
            {
                System.Windows.Forms.MessageBox.Show("读者当前已经借出总价大于200元的书，不可再借！", "提示");
                return;
            }
            else if (iCount >= 3)
            {
                System.Windows.Forms.MessageBox.Show("读者当前已经借出3本书，不可再借！", "提示");
                return;
            }
            else
            {
                string currentval = string.Format("读者当前可以借书！（{0}元）", value);
                System.Windows.Forms.MessageBox.Show(currentval, "提示");
                return;
            }


        }

        private void DataPic_bookOutDate_ValueChanged(object sender, System.EventArgs e)
        {
            System.DateTime dt = DataPic_bookOutDate.Value;
            System.DateTime dtBack = dt + new System.TimeSpan(30, 0, 0, 0);
            DataPic_bookBackDate.Value = dtBack;
        }

        private void Btn_startOutBook_Click(object sender, System.EventArgs e)
        {
            if (TextBox_bookName.Text.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("请正确填写书名", "错误提示");
                return;
            }
            if (TextBox_bookValue.Text.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("请正确填写书籍价格", "错误提示");
                return;
            }
            if (TextBox_personCardNum.Text.Length != 8)
            {
                System.Windows.Forms.MessageBox.Show("请正确填写借阅卡号", "错误提示");
                return;
            }

            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
            conn.Open();
            string sql_insert = string.Format("insert into RentBookInfo values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                        TextBox_bookISBN.Text, TextBox_personCardNum.Text, TextBox_bookPublisher.Text, TextBox_bookValue.Text, DataPic_bookOutDate.Text, DataPic_bookBackDate.Text, TextBox_bookName.Text);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand();
            cmd.CommandText = sql_insert;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            //
            //同时插入rentallbookofperson表中
            sql_insert = string.Format("insert into RentAllBookOfPerson values ('{0}','{1}','{2}')", TextBox_bookName.Text, TextBox_bookISBN.Text, TextBox_personCardNum.Text);
            System.Data.SQLite.SQLiteCommand cmdAll = new System.Data.SQLite.SQLiteCommand();
            cmdAll.CommandText = sql_insert;
            cmdAll.Connection = conn;
            cmdAll.ExecuteNonQuery();

            System.Windows.Forms.MessageBox.Show("新建借书成功", "提示");
            //借书成功后，自动清空ISBN，方便扫码
            btn_clearISBN.PerformClick();
            //
            cmd.Dispose();
            cmdAll.Dispose();
            conn.Close();
            conn.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        private void Btn_CheckBook_Click(object sender, System.EventArgs e)
        {
            System.Data.SQLite.SQLiteConnection conn = new System.Data.SQLite.SQLiteConnection(sDataBaseStr);
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
            //
            reader.Close();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }

        public string ToGB2312(string strSource)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                 strSource, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }
    }
}

