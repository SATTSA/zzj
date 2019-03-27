using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.DAL;

namespace Web.BLL
{
    public class MessageManager
    {
        //创建一个数据环境对象
        DataMessageDataContext dm = new DataMessageDataContext();

        //验证用户是否存在
        /*
         *添加判断用户是否存在函数，该函数判断登陆框里的
         *用户名是否是Users表中的注册用户；存在为True，否则false；
         */
        public bool Exist(string nickname)
        { 
            
            
            //统计Users表中符合条件的对象数目
            int num = dm.Users.Count(u => u.Nickname == nickname);

            //如果查询得到的数目大于0，说明该用户存在
            bool exsit = num > 0;
            return exsit;
        }
        //执行用户注册功能
        /*
         执行用户注册功能函数，该函数在Users表中插入一条记录，
         * 成功为true，否则为false；代码出现错误，
         * 还是缺少引用，继续添加如下页图
         */
        public bool Register(Users user)
        {
            try
            {
                dm.Users.InsertOnSubmit(user);
                dm.SubmitChanges();
            }
            catch 
            {
                return false;
            }
            return true;
        }

        //用户登陆函数，该函数返回合规的users表一条记录
        public Users Login(string nickname, string password)
        {
            try
            {
                //查询得到的用户
                Users user = dm.Users.Single(u => u.Nickname == nickname&&password==u.Password);
                user.IsOnline = true;
                dm.SubmitChanges();
                return user;
            }
            catch
            {
                return null;
            }
        }
        //查看用户是否在线
        public bool IsOnline(string nickname)
        {            
            int num = dm.Users.Count(u => u.Nickname == nickname && u.IsOnline == true);

            //如果查询到的数目大于0，说明该用户在线
            bool isOnline = num > 0;
            return isOnline ;
        } 
        //改变用户在线状态
        public void ChangeOffline(string nickname)
        {            
            Users user=dm.Users.Single(u => u.Nickname == nickname && u.IsOnline == true);
            user.IsOnline = false;
            dm.SubmitChanges();
        }
        //添加好友
        /*
         添加好友，该函数首先判断Friends表UserName
         * 是否有FriendName的记录，如果没有，
         * 则将Messages表一条记录的Sender和Receiver
         * 赋值给Friends表一条记录的UserName和FriendName，
         * 然后在这两个表分别插入这一条记录
         */
        public void AddFriend(Messages msg)
        {
            //查询用户是否是好友或好友请求已经发送成功
            var fs = (from f in dm.Friends
                      where f.UserName == msg.Sender && f.FriendName == msg.Receiver
                      select f).ToList();

            //如果查询到相关信息，就不再执行该操作
            if (fs != null && fs.Count > 0)
            {
                return;
            }

            Friends friend = new Friends()
            {
                UserName = msg.Sender,
                FriendName = msg.Receiver,
                IsPass = false
            };
            dm.Messages.InsertOnSubmit(msg);
            dm.Friends.InsertOnSubmit(friend);
            dm.SubmitChanges();
        }
        public void JoinGroup(Messages msg)
        {
           
            //查询用户是否是好友或好友请求已经发送成功
            var fs = (from f in dm.GroupMembers
                      where f.GroupMember == msg.Sender && f.GroupName == msg.Details
                      select f).ToList();

            //如果查询到相关信息，就不再执行该操作
            if (fs != null && fs.Count > 0)
            {
                return;
            }

            GroupMembers groupMember = new GroupMembers()
            {
                GroupName = msg.Details,
                GroupMember = msg.Sender,
                IsPass = false
            };

            dm.Messages.InsertOnSubmit(msg);
            dm.GroupMembers.InsertOnSubmit(groupMember);
            dm.SubmitChanges();
        }
        
        //删除好友
        public void RemoveFriend(string currentUsername,string friendName)
        {
            //查询当前是否是好友
            var fs = (from f in dm.Friends
                      where f.UserName == currentUsername && f.FriendName == friendName
                      select f).ToList();

            //如果查询到相关信息，就不再执行该操作
            if (fs ==null)
            {
                return;
            }

            Friends friend = dm.Friends.Single(u => u.UserName == currentUsername && u.FriendName == friendName);
            if (friend == null)
            {
                return;
            }
            dm.Friends.DeleteOnSubmit(friend);
            dm.SubmitChanges();
        }
        
        //同意好友请求
        /*同意好友，该函数判断是否存在Messages表的一条记录，
         * 使得Sender和Receiver分别等于Friend表的 FriendName和UserName ，
         * 如果存在将IsPass设置为true;
        */
        public void AgreeFriend(Messages msg)
        {
            Friends friend = dm.Friends.Single(f => f.IsPass == false
                && f.UserName == msg.Receiver
                && f.FriendName == msg.Sender);
           
            friend.IsPass = true;
            dm.Messages.InsertOnSubmit(msg);
            dm.SubmitChanges();
        }

        //同意群申请
        public void AgreeGroup(Messages msg)
        {
            GroupMembers goupMember = dm.GroupMembers.Single(f => f.IsPass == false
                && f.GroupName == msg.Details
                && f.GroupMember == msg.Receiver);

            goupMember.IsPass = true;
            dm.Messages.InsertOnSubmit(msg);
            dm.SubmitChanges();
        }

        //拒绝好友请求，该函数将Friends表符合条件的好友关系删除
        public void RejectFriend(Messages msg)
        {
            Friends friend = dm.Friends.Single(f =>
                f.IsPass == false &&
                f.UserName == msg.Receiver &&
                f.FriendName == msg.Sender);
            dm.Friends.DeleteOnSubmit(friend);
            dm.Messages.InsertOnSubmit(msg);
            dm.SubmitChanges();
        }

        //拒绝群请求
        public void RejectGroup(Messages msg)
        {
            GroupMembers goupMember = dm.GroupMembers.Single(f => f.IsPass == false
                && f.GroupName == msg.Details
                && f.GroupMember == msg.Receiver);


            dm.GroupMembers.DeleteOnSubmit(goupMember);
            dm.Messages.InsertOnSubmit(msg);
            dm.SubmitChanges();
        }
       
        //发送消息，该函数根据Classify的取值不同执行不同的动作。
        public void SendMessage(Messages msg)
        {
            if (msg.Classify == 3)
                AddFriend(msg);
            else if (msg.Classify == 4)
                AgreeFriend(msg);
            else if (msg.Classify == 5)
                RejectFriend(msg);

            //创建一个数据环境变量
            DataMessageDataContext dmdc = new DataMessageDataContext();
            dmdc.Messages.InsertOnSubmit(msg);
            dmdc.SubmitChanges();
        }

        //创建群
        public bool CreateGroup(Groups group,GroupMembers groupMember)
        {      
            try
            {               
                dm.Groups.InsertOnSubmit(group);
                dm.GroupMembers.InsertOnSubmit(groupMember);
                dm.SubmitChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //删除群
        public void DissolveGroup(string currentUsername, string groupName)
        {

            Groups group = dm.Groups.Single(u => u.GroupName == groupName && u.GroupMaster == currentUsername);

            if (group == null)
            {
                return;
            }

            var queryGroupMember = from gm in dm.GroupMembers where gm.GroupName == groupName select gm;
           
            foreach (GroupMembers gm in queryGroupMember)
            {
                dm.GroupMembers.DeleteOnSubmit(gm);
                dm.SubmitChanges();
            }       

            dm.Groups.DeleteOnSubmit(group);
            dm.SubmitChanges();
        }

        //判断是否存在该群
        public bool IsExistTheGroup(string groupName)
        {
            DataMessageDataContext dmdc = new DataMessageDataContext();
            int num = dm.Groups.Count(u => u.GroupName == groupName);
            bool result = num > 0;
            return result;
        }

        //判断群中是否包含该用户
        public bool IsExistTheMember(string userName, string groupName)
        {
            DataMessageDataContext dmdc = new DataMessageDataContext();
            
            int num = dm.GroupMembers.Count(u => u.GroupName == groupName&&u.GroupMember==userName&&u.IsPass==true);
           
            bool result = num > 0;
            return result;
        }


        //查询群主
        public string QueryGroupMaster(string groupName)
        {
            Groups group = dm.Groups.Single(u => u.GroupName == groupName);
           
            return group.GroupMaster;
        }

        //添加好友到群
        public bool AddFriendToGroup(GroupMembers gm)
        {
            int num = dm.GroupMembers.Count(gmc=>gmc.GroupName==gm.GroupName&&gmc.GroupMember==gm.GroupMember);

            if (num>0)
            {
                throw new Exception();
            }

           dm.GroupMembers.InsertOnSubmit(gm);

           dm.SubmitChanges();
           return true;
        }

        //删除群中的好友
       // public bool RemoveFriendFromGroup(GroupMembers gm)
        public bool RemoveFriendFromGroup(string friendName,string groupName)
        {
            //不能删除群主
            int num= dm.Groups.Count(g => g.GroupName == groupName && g.GroupMaster == friendName);
            
            //如果查询到相关信息，就不再执行该操作
            if (num>0)
            {
                throw new Exception("不能删除群主！");
            }

            var gm = dm.GroupMembers.Single(g => g.GroupMember == friendName && g.GroupName == groupName);

            dm.GroupMembers.DeleteOnSubmit(gm);
            dm.SubmitChanges();
            return true;
        }

        //查询用户在的所有群
        public List<GroupMembers> IsInGroup(string currentUsername)
        {
            
            var queryGroupMember = from gm in dm.GroupMembers where gm.GroupMember==currentUsername &&gm.IsPass==true select gm;
            List<GroupMembers> groupList = queryGroupMember.ToList();

            return groupList;
        }

        //查询群中的所有成员
        public List<GroupMembers> GroupMembers(string groupName)
        {
            var queryGroupMember = from gm in dm.GroupMembers where gm.GroupName == groupName&&gm.IsPass==true select gm;
            List<GroupMembers> groupList = queryGroupMember.ToList();            
            return groupList;            
        }
       
        //获取信息列表，该函数保存形参nickname的消息记录
        public List<Messages> GetMessages(string nickname)
        { 
            //创建一个数据环境变量
            DataMessageDataContext dmdc = new DataMessageDataContext();

            //查询得到符合条件的结果集
            var ms = from m in dm.Messages
                     where m.Receiver == nickname
                     select m;
            //将结果集转换成List
            List<Messages> message = ms.ToList();
            
            //为了不让下面的删除操作影响结果查询集，我们在这里把结果集复制一份
            message = CopyMessageList(message);

            //如果不删除，则系统每隔2秒就从Messages表中提取信息到txtMessages文本框
            //这样说来，数据表Messages就起什么作用呢？就是暂存发言信息
            //然后调用copyMessagesList方法，将发言信息拷贝到内存对象中，
            //txtMessages文本框的信息来自内存对象
            //最后删除Messages表的内容，防止发言重复出现。
            dm.Messages.DeleteAllOnSubmit(ms);
            dm.SubmitChanges();

            //返回结果
            return message;
        }
        
        //Copy信息列表，该函数返回一个消息列表，实际上是当前信息列表的副本
        private List<Messages> CopyMessageList(List<Messages> msgs)
        {
            List<Messages> messages=new List<Messages>();
            foreach (var m in msgs)
            { 
                Messages msg=new Messages();
                msg.ID=m.ID;
                msg.Classify=m.Classify;
                msg.Details=m.Details;
                msg.FileFullName=m.FileFullName;
                msg.Receiver=m.Receiver;
                msg.Sender=m.Sender;
                msg.SendTime=m.SendTime;

                messages.Add(msg);
            }
            return messages;
        }

        //获取指定用户的好友列表
        public List<Friends> GetFriendList(string nickname)
        {
            var fs = from f in dm.Friends
                     where f.UserName == nickname &&
                     f.IsPass == true
                     select f;
            return fs.ToList();
        }
    }
}
