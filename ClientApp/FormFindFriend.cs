using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class FormFindFriend : Form
    {
        string currentUsername = "";
        private WebServiceMessage.WSMessage wsMessage = null;

        public WebServiceMessage.WSMessage WsMessage
        {
            get { return wsMessage; }
            set { wsMessage = value; }
        }
       
        public FormFindFriend(string currentUsername)
        {
            this.currentUsername = currentUsername;//记录从FormMessage()创建FormFindFriend窗体传进来的currenUsername

            InitializeComponent();
        }

        private void btnSender_Click(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text.Trim();
            //验证输入的用户名是否为空
            if (username == null || username == string.Empty)
            {
                MessageBox.Show("请输入要请求的用户名称！");
                return;
            }

            //不能添加自己为好友
            if (username == currentUsername)
            {
                MessageBox.Show("不能添加自己为好友！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
            //判断用户是否存在
            bool isExist = wsMessage.HavaUser(username);
            if (!isExist)
            {
                MessageBox.Show("用户不存在");
                return;
            }
            
            //判断是否已经是你的好友
            WebServiceMessage.Friends[] friends = WsMessage.GetFriendList();
            foreach (var f in friends)
            {
                if (username == f.FriendName)
                {
                    MessageBox.Show("该用户已经是你的好友！");
                    return;
                }
            }
            //添加好友
            WsMessage.AddFriend(username);
            this.Close();

        }
    }
}
