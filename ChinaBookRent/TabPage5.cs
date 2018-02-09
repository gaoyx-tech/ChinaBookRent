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

        private void initTabPage5()
        {
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
            cb_personCondition.Items.Add("按手机号查询人");
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
            listview_personInfos.Columns.Add("身份证号", 180, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("借书卡号", 180, HorizontalAlignment.Center);
            listview_personInfos.Columns.Add("手机号", 160, HorizontalAlignment.Center);
            this.tabPage5.Controls.Add(listview_personInfos);
        }

        private void Btn_startPersonInfo_Click(object sender, System.EventArgs e)
        {

        }
    }
}
