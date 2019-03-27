using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Web.BLL;
using Web.DAL;
using Web.DAL.Properties;

namespace WebServiceApp
{
    /// <summary>
    /// WSMessag 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
   
    public class WSMessage : System.Web.Services.WebService
    {
        //验证用户是否存在
        [WebMethod]
        public bool HavaUser(string nickname)
        {
            MessageManager mm = new MessageManager();
            bool exist = mm.Exist(nickname);
            return exist;
        }
        //注册
        [WebMethod]
        public bool Register(string nickname, string password)
        {
            MessageManager mm = new MessageManager();
            Users user = new Users()
            {
                Nickname = nickname,
                Password = password
            };
            return mm.Register(user);
        }

        //验证登陆
        [WebMethod(EnableSession = true)]
        public bool Login(string nickname, string password)
        {
            MessageManager mm = new MessageManager();
            Users user = mm.Login(nickname,password);

            //状态保持
            Session["CurrentUser"] = user;
            return user != null;
        }
        //验证用户是否在线
        [WebMethod(EnableSession = true)]
        public bool IsOnline(string nickname)
        {
           MessageManager mm = new MessageManager();
           return mm.IsOnline(nickname);
        } 

        //设置用户为离线状态
        [WebMethod(EnableSession = true)]
        public void Offline(string nickname)
        {
            MessageManager mm = new MessageManager();
            mm.ChangeOffline(nickname);
        } 
        
        //添加好友
        [WebMethod(EnableSession = true)]
        public void AddFriend(string nickname)
        {
            Users user = Session["CurrentUser"] as Users;
            if (user == null)
                throw new Exception("用户尚未登陆！");            
            Messages msg = new Messages();
            msg.Classify = 3;
            msg.Receiver = nickname;
            msg.SendTime = DateTime.Now;
            msg.Sender = user.Nickname;

            MessageManager mm = new MessageManager();
            mm.AddFriend(msg);
        }

        //加入群
        [WebMethod(EnableSession = true)]
        public void JoinGroup(string currentUsername,string groupName)
        {
            MessageManager mm = new MessageManager();
            if (currentUsername == null)
                throw new Exception("用户尚未登陆！");
            Messages msg = new Messages();
            msg.Classify = 6;
            msg.Receiver = mm.QueryGroupMaster(groupName);  //群主接收加群请求
            msg.Details = groupName;
            msg.SendTime = DateTime.Now;
            msg.Sender = currentUsername;

            bool result = mm.IsExistTheMember(currentUsername, groupName);
            if (result)
                throw new Exception("不能重复加群！");
            mm.JoinGroup(msg);
        }
        
        //删除好友请求
        [WebMethod(EnableSession = true)]
        public void RemoveFriend(string currentUsername,string friendName)
        {
            //Users user = Session["CurrentUser"] as Users;  //前者Session["CurrentUser"]=user;
            //if (user == null)
            //    throw new Exception("用户尚未登陆！");

            MessageManager mm = new MessageManager();
            //mm.RemoveFriend(user.Nickname, friendName);
            mm.RemoveFriend(currentUsername, friendName);

        }
        
        //处理好友请求
        [WebMethod(EnableSession = true)]
        public void HandleFriendRequst(bool accept, string friend)
        {
            Users user = Session["CurrentUser"] as Users;
            if (user == null)
                throw new Exception("用户尚未登陆！");
            Messages msg = new Messages();
            msg.Classify = accept ? 4 : 5;
            msg.Receiver = friend;
            msg.SendTime = DateTime.Now;
            msg.Sender = user.Nickname;

            MessageManager mm = new MessageManager();
            if (accept)
                mm.AgreeFriend(msg);
            else
                mm.RejectFriend(msg);
        }

        //处理群请求
        [WebMethod(EnableSession = true)]
        public void HandleGroupRequst(string currentUsername,bool accept, string friend,string groupName)
        {           
            Messages msg = new Messages();
            msg.Classify = accept ? 7 : 8;
            msg.Receiver = friend;
            msg.SendTime = DateTime.Now;
            msg.Sender = currentUsername;
            msg.Details = groupName;

            MessageManager mm = new MessageManager();
            if (accept)
                mm.AgreeGroup(msg);
            else
                mm.RejectGroup(msg);
        }

        //创建群
        [WebMethod(EnableSession = true)]
        public bool CreateGroup(string currentUsername,string groupName)
        {
            MessageManager mm = new MessageManager();
            
            //Users user = Session["CurrentUser"] as Users;
            //string currentUsername = user.ToString();
           
            Groups group = new Groups()
            {
                GroupMaster = currentUsername,
                GroupName =groupName
            };
            GroupMembers groupMember = new GroupMembers
            {
                GroupName = groupName,
                GroupMember = currentUsername,
                IsPass = true
            };
                      
            return mm.CreateGroup(group, groupMember);           
            
        }

        //删除群
        [WebMethod]
        public void DissolveGroup(string currentUsername, string groupName)
        {
            
            MessageManager mm = new MessageManager();
            mm.DissolveGroup(currentUsername, groupName);
        }

        //判断是否存在要添加的群
        [WebMethod]
        public bool IsExistTheGroup(string groupName)
        { 
            MessageManager mm=new MessageManager();
            return mm.IsExistTheGroup(groupName);
        }
        //添加群成员
        [WebMethod]
        public bool AddFriendToGroup(string friendName, string groupName)
        {
            MessageManager mm = new MessageManager();
           
            bool isExistTheGroupName = mm.IsExistTheGroup(groupName);
            if (!isExistTheGroupName)
            {
                return false;
            }
            bool isExistTheFriendName = mm.Exist(friendName);
            if (!isExistTheFriendName)
            {
                return false;
            }

            GroupMembers gm = new GroupMembers();
            
            gm.GroupName = groupName;
            gm.GroupMember = friendName;
            gm.IsPass = true;
            try
            {
                mm.AddFriendToGroup(gm);
            }
            catch (Exception)
            {
                
                throw;
            }
          
            return true;
        }

        //删除群成员
        [WebMethod]
        public bool RemoveFriendFromGroup(string friendName, string groupName)
        {
            MessageManager mm = new MessageManager();
                         
            try
            {
                mm.RemoveFriendFromGroup(friendName, groupName);
            }
            catch (Exception)
            {
                throw;
            }        

            return true;
        }

        //查询用户在的所有群
        [WebMethod]
        public List<GroupMembers> IsInGroup(string currentUsername)
        {
            MessageManager mm = new MessageManager();
            return mm.IsInGroup(currentUsername);
        }

        //查询群中的所有成员
        [WebMethod]
        public List<GroupMembers> GroupMembers(string groupName)
        {
            MessageManager mm = new MessageManager();
            return mm.GroupMembers(groupName);
        }

        //发送消息
        //[WebMethod(EnableSession = true, MessageName = "SendMessage1")]        
        [WebMethod(EnableSession = true)]
        public void SendMessage(Messages msg)
        {
            Users user=Session["CurrentUser"] as Users;
            if(user==null)
                throw new Exception("用户尚未登陆！");
            msg.Classify = 1;
            msg.SendTime = DateTime.Now;
            msg.Sender = user.Nickname;

            MessageManager mm = new MessageManager();
            mm.SendMessage(msg);
        }
        [WebMethod(EnableSession = true)]
        public void SendMessageQun(Messages msg)
        {
            Users user = Session["CurrentUser"] as Users;
            if (user == null)
                throw new Exception("用户尚未登陆！");
            msg.Classify = 0;
            msg.SendTime = DateTime.Now;
            msg.Sender = user.Nickname;

            MessageManager mm = new MessageManager();
            mm.SendMessage(msg);
        }
        //改动太大。接收消息时无法辨别是群消息还是好友消息
        //发送消息重载函数
        //[WebMethod(EnableSession = true)]
        ////[WebMethod(EnableSession = true, MessageName = "SendMessage2")]
        //public void SendGroupMessage(string groupName,Messages msg)
        //{
        //    Users user = Session["CurrentUser"] as Users;
        //    if (user == null)
        //        throw new Exception("用户尚未登陆！");
        //    msg.Classify = 1;
        //    msg.SendTime = DateTime.Now;
        //    msg.Sender = user.Nickname;
        //    // msg.Sender = string.Format(user.Nickname+"在"+groupName);

        //    MessageManager mm = new MessageManager();
        //    mm.SendMessage(msg);
        //}

        //发送文件
        [WebMethod(EnableSession = true)]
        public void SendFile(Messages msg)
        {
            Users user = Session["CurrentUser"] as Users;
            if (user == null)
                throw new Exception("用户尚未登陆！");
            msg.Classify = 2;
            msg.SendTime = DateTime.Now;
            msg.Sender = user.Nickname;

            MessageManager mm = new MessageManager();
            mm.SendMessage(msg);
        }
        
        //监听消息，该函数获取当前在线用户的消息列表；至此，Web服务设计完成
        [WebMethod(EnableSession = true)]
        public List<Messages> Monitor() {
            Users user = Session["CurrentUser"] as Users;
            if (user == null)
                throw new Exception("用户尚未登陆！");
            MessageManager mm = new MessageManager();
            var ms = mm.GetMessages(user.Nickname);
            return ms;
        }
        
        //监听信息
        [WebMethod(EnableSession = true)]
        public List<Friends> GetFriendList()
        {
            Users user = Session["CurrentUser"] as Users;
            if (user == null)
            {
                throw new Exception("用户尚未登录！");
            }
            MessageManager mm = new MessageManager();
            return mm.GetFriendList(user.Nickname);
        }
    }
}
