using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClientApp
{
    public partial class FormMessage : Form
    {
        //在FormMessage.cs中创建Web服务代理对象和两个属性
        WebServiceMessage.WSMessage wsMessage = null;

        private string currentUsername = null;

        #region Public Attribute

        public WebServiceMessage.WSMessage WsMessage
        {
            get { return wsMessage; }
            set { wsMessage = value; }
        }
        public string CurrentUsername
        {
            get { return currentUsername; }
            set { currentUsername = value; }
        }
        #endregion

        public FormMessage()
        {
            InitializeComponent();
            //应用程序第一次运行，还没有接收到FormLogin传来的web服务对象
            //所以WsMessage为空，执行if语句
            if (WsMessage == null)
            {
                //创建FormLogin实例对象login，执行动作包含初始化FormLogin类的对象
                //执行IntializeComponent（）方法
                FormLogin login = new FormLogin();
                
                //将FormMessage窗体对象赋值给FormLogin窗体的Master属性；
                //作用之一；将currentUsername变量传递到FormLogin窗体
                //功能是用来接收登陆端的用户名
                login.Master = this;
                
                login.ShowDialog();//当执行完FormLogin窗体时才继续向下执行

                if (currentUsername == null || WsMessage == null)
                {
                    return;//终端函数停止
                }

                //在FormMessage窗体的标题栏显示：“当前用户：登录用户名”
                this.Text += "(当前用户：" + this.currentUsername + ")";

                //初始化好友列表
                this.RefreshFriendList();

                //客户端请求等待WEB服务的时间不限制
                WsMessage.Timeout = -1;

                //开始监听
                this.timerMonitor.Start();
            }
        }

        //刷新好友列表
        private void RefreshFriendList()
        {
            object target = this.lstOnline.SelectedItem;
            this.lstOnline.Items.Clear(); 
            this.lstUsers.Items.Clear();

            //请求获取好友列表
            WebServiceMessage.Friends[] friends = WsMessage.GetFriendList();

            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            //遍历添加用户
            foreach (var f in friends)
            {
                this.lstUsers.Items.Add(f.FriendName);//第一个ListBox显示全部好友
                if (wsm.IsOnline(f.FriendName))
                    this.lstOnline.Items.Add(f.FriendName);//第二个显示在线好友
            }
            if (target != null)
            {
                if (this.lstOnline.Items.Contains(target))
                {
                    this.lstOnline.SelectedItem = target;
                }
            }
           
        }
        //刷新群列表
        private void RefreshGroupList()
        {
            object target = this.list1.SelectedItem;
            this.list1.Items.Clear();
            this.listBox1.Items.Clear();

            //请求获取好友列表
            WebServiceMessage.GroupMembers[] groupMembers = WsMessage.IsInGroup(currentUsername);
            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            //遍历所处的所有群
            foreach (var g in groupMembers)
            {
                this.list1.Items.Add(g.GroupName);//第一个ListBox显示全部好友               
            }
            if (target != null)
            {               
                WebServiceMessage.GroupMembers[] users = wsm.GroupMembers(target.ToString());
                foreach (var u in users)
                {
                    this.listBox1.Items.Add(u.GroupMember);//第一个ListBox显示全部好友               
                }
                if (this.list1.Items.Contains(target))
                {
                    this.list1.SelectedItem = target;                }

            }

        }


        //刷新所有ListBox
        private void RefreshAllListBox()
        {
            this.RefreshFriendList();
            this.RefreshGroupList();
        }

        //刷新好友列表 
        private void btnRefresh_Click(object sender, EventArgs e)
        {                   
            this.RefreshFriendList();            
        }

        //添加好友按钮的Click事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FormFindFriend fff = new FormFindFriend(CurrentUsername);
            fff.WsMessage = this.wsMessage;
            fff.ShowDialog();
        }
        //点击发送按钮的Click事件
        private void btnSend_Click(object sender, EventArgs e)
        {
            string content = this.txtMessage.Text.Trim();
            object targetUsersOnline = this.lstOnline.SelectedItem;

            if (content == string.Empty)
            {
                return;
            }
          //与好友聊天
                      
                if (targetUsersOnline == null)
                {
                    MessageBox.Show("请选择好友！");
                    return;
                }

                WebServiceMessage.Messages msg = new WebServiceMessage.Messages();
                msg.Classify = 1;
                msg.Details = content;
                msg.Receiver = targetUsersOnline.ToString();

                WsMessage.SendMessage(msg);

                //将发送的消息加入列表
                string message = "我对" + msg.Receiver + "说：\r\n" + msg.Details;

                this.AddMessageToList(message);
 
            //清空文本框
            this.txtMessage.Text = string.Empty;
        }
        //将消息加入列表
        private void btnFayan_Click(object sender, EventArgs e)
        {
            string content = this.txtfayan.Text.Trim();


            object targetGroup = this.list1.SelectedItem;  //获取选正的群
            object targetGroupMembers = this.listBox1.Items;  //获取群中所有成员

           

            if (content == string.Empty)
            {
                return;
            }

            {
                string groupName = targetGroup.ToString();

                if (groupName == null)
                { MessageBox.Show("聊天请先请选择好友或群"); }
                WebServiceMessage.Messages msg = new WebServiceMessage.Messages();
                msg.Classify = 0;
                msg.Details = string.Format(content + "[{0}群消息]", groupName);

                foreach (string drv in this.listBox1.Items)
                {
                    msg.Receiver = drv.ToString();
                    WsMessage.SendMessageQun(msg);
                }

                ////将发送的消息加入列表
                //string message = "我说：\r\n" + msg.Details;
               

            }

            //清空文本框
            this.txtfayan.Text = string.Empty;
        }
        private void AddMessageToList(string msg)
        {
            this.txtMessages.Text += msg;
            this.txtMessages.Text += "\r\n\r\n";
        }
        //将消息加入群列表
        private void AddMessageToListQun(string msg)
        {
            this.txtqunliao.Text += msg;
            this.txtqunliao.Text += "\r\n\r\n";
        }
        //发送文件按钮的Click事件 
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            object target = this.lstOnline.SelectedItem;
            if (target == null)
            {
                MessageBox.Show("请选择好友！");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog(); ///?????????
            ofd.ShowDialog();
            string filename = ofd.FileName;

            //若用户没有选择文件，不执行操作
            if (filename == null || filename.Trim() == string.Empty)
            {
                return;
            }

            //限制文件大小
            FileInfo file = new FileInfo(filename);
            long fileLength = file.Length;
            //若果选择的文件大小大于300K，拒绝发送（文件大夏普将降低程序性能）
            if ((fileLength / 1024) > 10)
            {
                MessageBox.Show("系统暂时不支持发送大于10K的，请重新选择文件。");
                return;
            }

            //确认发送文件
            DialogResult result = MessageBox.Show("是否发送文件：\r\n"
                + filename + "\r\n大小：" + (fileLength / 1024) + "K",
                "确认发送", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.No)
            {
                return;
            }

            //发送文件
            this.SendFile(filename, target.ToString());

        }
        private void SendFile(string filename, string target)
        {
            //创建一个文件流对象
            FileStream fs = new FileStream(filename, FileMode.Open);

            //创建一个二进制组
            byte[] bs = new byte[fs.Length];

            //从文件流中读出内容
            fs.Read(bs, 0, bs.Length);

            //关闭流
            fs.Close();

            //初始化Messages对象
            WebServiceMessage.Messages msg = new WebServiceMessage.Messages();
            msg.Classify = 2;
            msg.Details = ConvertStringAndBytes.ConvertBytesToString(bs);
            msg.Receiver = target;
            msg.FileFullName = filename.Substring(filename.LastIndexOf("\\"));

            //执行发送操作
            WsMessage.SendFile(msg);
        }

        private void FormMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            string nickname = this.CurrentUsername;
            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            wsm.Offline(nickname);
            Application.Exit();
        }

        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            //获取消息列表
            WebServiceMessage.Messages[] msgs = WsMessage.Monitor();
           
            //刷新好友列表
            this.RefreshAllListBox(); 

            //遍历处理消息列表
            foreach (var m in msgs)
            {
                //根据消息类型分类处理信息
                switch (m.Classify)
                {
                    case 0:
                        this.GetMessagequn(m);
                        break;
                    case 1:
                        this.GetMessage(m);                        
                        break;
                    case 2:
                        this.GetFile(m);
                        break;
                    case 3:
                        this.GetFriendRequest(m);
                        break;
                    case 4:
                    case 5:
                        this.GetFriendResponse(m);
                        break;
                    case 6:
                        this.getGroupRequest(m);
                        break;
                    case 7:                      
                    case 8:
                        this.getGroupResponse(m);
                        break;
                    
                }
            }

        }
        //以下几个是timeMonitor服务类
        //获取文本信息
        private void GetMessage(WebServiceMessage.Messages msg)
        {
            string m = msg.Sender + "说:\r\n" + msg.Details;
            this.AddMessageToList(m);
        }
        private void GetMessagequn(WebServiceMessage.Messages msg)
        {
            string m = msg.Sender + "说:\r\n" + msg.Details;
            this.AddMessageToListQun(m);
        }

        //获取好友请求
        private void GetFriendRequest(WebServiceMessage.Messages msg)
        {
            DialogResult result = MessageBox.Show("用户" + msg.Sender +
                "请求添加你为好友，是否同意？", "好友请求",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            WsMessage.HandleFriendRequst(result == DialogResult.Yes, msg.Sender);
        }

        //获取好友请求响应
        private void GetFriendResponse(WebServiceMessage.Messages msg)
        {
            if (msg.Classify == 4)
            {
                MessageBox.Show("用户" + msg.Sender + " 同意了你的添加请求。");
            }
            else
            {
                MessageBox.Show("用户" + msg.Sender + " 拒绝了你的添加请求。");
            }

            //刷新好友列表
            this.RefreshFriendList();
        }

        //获取群请求回应
        private void getGroupResponse(WebServiceMessage.Messages msg)
        {
            if (msg.Classify == 7)
            {
                MessageBox.Show("用户" + msg.Sender + " 同意了你的添加群{0}请求。",msg.Details);
            }
            else
            {
                MessageBox.Show("用户" + msg.Sender + " 拒绝了你的添加群{0}请求。",msg.Details);
            }

            //刷新好友列表
            this.RefreshAllListBox();
        }
        

        //获取加群请求
        private void getGroupRequest(WebServiceMessage.Messages msg)
        {
            object obj = msg.Details;
            DialogResult result = MessageBox.Show(string.Format("用户{0}请求加入{1}群,是否同意?", msg.Sender, msg.Details), "请求", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            WsMessage.HandleGroupRequst(currentUsername,result == DialogResult.Yes, msg.Sender,msg.Details);                      ;
        }
        
        //获取文件
        private void GetFile(WebServiceMessage.Messages msg)
        {
            DialogResult dr = MessageBox.Show("好友" + msg.Sender + "给你发来一个文件（" + msg.FileFullName +
                ",Size:" + msg.Details.Length + "Byte.)。\r\n是否接受该文件？",
                "接收文件", MessageBoxButtons.YesNo);

            //如果用户不接受该文件，放弃本次文件传递
            if (dr != DialogResult.Yes)
            {
                return;
            }

            //设置文件名称
            string filename = this.GetNewFilename(msg.FileFullName);

            byte[] fileContent = ConvertStringAndBytes.ConvertStringToBytes(msg.Details);
            //创建一个文件流对象，并初始化
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);

            //向文件流中写入内容
            fs.Write(fileContent, 0, fileContent.Length);

            //关闭流
            fs.Close();
        }

        //设置接收文件的文件名
        private string GetNewFilename(string filename)
        {
            //设置一个本地文件名
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = false;//设置对话框不检查是否存在
            ofd.FileName = filename;//设置文件名对话框的初始值
            ofd.ShowDialog();
            string fn = ofd.FileName;
            if (fn.Substring(1, 2) != @":\")
            {
                MessageBox.Show("选择的文件名格式不正确，请重新选择!");
                fn = this.GetNewFilename(filename);
            }
            return fn;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            object target = this.lstUsers.SelectedItem;
           
            if (target == null)
            {
                MessageBox.Show("请选择好友！");
                return;
            }

            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            string friendName = target.ToString();
            wsm.RemoveFriend(currentUsername,friendName);

            
        }

        private void btnChuangjian_Click(object sender, EventArgs e)
        {
            //WebServiceMessage.WSMessage wsMessage = new WebServiceMessage.WSMessage();
            //wsMessage.CreateGroup();
            FormCreateGroup fcg = new FormCreateGroup(CurrentUsername);
            fcg.ShowDialog();
        }

        private void btnFriendToGroup_Click(object sender, EventArgs e)
        {
            object targetFriend = this.lstUsers.SelectedItem;
            object targetGroup = this.list1.SelectedItem;

            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            
            if (targetFriend == null)
                MessageBox.Show("请选择要添加的好友！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else if (targetGroup == null)
                MessageBox.Show("请选择目标群","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            
            else
                try
                {
                    wsm.AddFriendToGroup(targetFriend.ToString(), targetGroup.ToString());
                }
                catch (Exception)
                {

                    MessageBox.Show("群中已经存在该好友");
                }
              
        }

        private void btnDissolveGroup_Click(object sender, EventArgs e)
        {
            object targetGroup = this.list1.SelectedItem;
            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            
            string targetGroup_s=targetGroup.ToString();

            if (targetGroup_s == null)
            {
                MessageBox.Show("请选择要解散的群！");
            }
            else
            {
                DialogResult okCancel = MessageBox.Show("确定删除所有群成员并解散？","确定解散",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (okCancel==DialogResult.OK)
                {
                    wsm.DissolveGroup(currentUsername, targetGroup.ToString());  
                }
                else
                {
                    return; 
                }
               
            }
                 
        }

        private void btnCancelGroupMember_Click(object sender, EventArgs e)
        {
            object targetFriend = this.listBox1.SelectedItem;
            object targetGroup = this.list1.SelectedItem;
            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();

           
           
            if (targetFriend == null)
            {
                MessageBox.Show("请选择要删除的群成员！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else 
            {
                string targetFriend_s = targetFriend.ToString();
                string targetGroup_s = targetGroup.ToString();

               DialogResult okCancel= MessageBox.Show("确定删除群"+targetGroup_s+"中的成员"+targetFriend_s+"吗？","确认删除",
                    MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

               
               if (okCancel == DialogResult.OK)
               {

                   //当删除群主时，出线”不能删除群主异常“
                   try
                   {
                       wsm.RemoveFriendFromGroup(targetFriend_s, targetGroup_s);
                   }
                   catch
                   {
                       MessageBox.Show("不能删除群主");
                   }

               }
               else
                   return;
            }
        }

        //添加群Click事件
        private void btnJoinQun_Click(object sender, EventArgs e)
        {
            FormJoinGroup fjg = new FormJoinGroup(CurrentUsername);
            fjg.ShowDialog();
        }

        private void btnQingping_Click(object sender, EventArgs e)
        {
            this.txtqunliao.Text = "";
        }
    }
}
