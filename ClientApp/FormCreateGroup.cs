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
    public partial class FormCreateGroup : Form
    {
        string currentUsername = null;

        public string CurrentUsername
        {
            get { return currentUsername; }
            set { currentUsername = value; }
        }
        public FormCreateGroup(string currentUsername)
        {
            this.CurrentUsername = currentUsername;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void BtnCreateGroup_Click(object sender, EventArgs e)
        {

            string groupName = this.txtGroupName.Text.Trim();
            //验证输入的用户名是否为空
            if (groupName == null || groupName == string.Empty)
            {
                MessageBox.Show("请输入要创建群的名称！");
                return;
            }

            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();

            //判断要创建的群是否存在
            if (wsm.IsExistTheGroup(groupName) == true)
            {
                MessageBox.Show("该群已经存在");
            }
            else
            {
                //创建群          
                wsm.CreateGroup(currentUsername, groupName);
                this.Close();
            }
           
        }
    }
}
