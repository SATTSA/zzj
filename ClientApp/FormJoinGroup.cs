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
    public partial class FormJoinGroup : Form
    {
        string currentUsername = null;
        public FormJoinGroup(string currentUsername)
        {
            this.currentUsername = currentUsername;
            InitializeComponent();
        }

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            string GroupName = this.txtGroupName.Text.Trim();

            if (GroupName == null || GroupName == string.Empty)
            {
                MessageBox.Show("请输入要请求的群名称！");
                return;
            }

            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            //判断用户是否存在
            bool isExist = wsm.IsExistTheGroup(GroupName);
            if (!isExist)
            {
                MessageBox.Show("该群不存在");
                return;
            }

            ///////要添加一个避免重复加入群的判断
            
            //添加群，如果已经在群中跑出异常
            try
            {
                 wsm.JoinGroup(currentUsername,GroupName);
            }
            catch 
            {
                MessageBox.Show("不能重复加群");
                
            }
            
            this.Close();

        }
    }
}
