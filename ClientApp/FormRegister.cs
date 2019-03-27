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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string nickname = this.txtNickname.Text.Trim();
            string password = this.txtPassword.Text.Trim();
            string rePassword = this.txtRePassword.Text.Trim();
            //用户名不能为空
            if (nickname == null)
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            //密码不能为空
            if (password == null)
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            //两次输入密码不一致
            if (password != rePassword)
            {
                MessageBox.Show("两次输入密码不一致！");
                return;
            }
            //禁用注册按钮
            this.Enabled = false;
            //创建一个代理类对象
            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            //验证用户是否存在
            bool isExist = wsm.HavaUser(nickname);
            if (isExist)
            {
                MessageBox.Show("该用户名已经存在，请换个用户名！");
                this.Enabled = true;
                return;
            }
            //获取执行结果
            bool over = wsm.Register(nickname,password);
            
            //如果执行成功,提示关闭注册对话框
            //如果执行失败，提示并让用户重试
            if (over)
            {
                MessageBox.Show("注册成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("注册失败，请重试！");
                this.btnSubmit.Enabled = true;
            }
        }
    }
}
