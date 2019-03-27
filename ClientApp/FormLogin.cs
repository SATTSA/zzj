using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace ClientApp
{
    public partial class FormLogin : Form
    {
        private FormMessage master = null;
        private bool CloseKey = true;

        public FormMessage Master
        {
            get { return master; }
            set { master = value; }
        }
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //创建一个注册窗口
            FormRegister fr = new FormRegister();

            //以对话框形式打开该窗口
            fr.ShowDialog(); //?????????????
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nickname = this.txtUsername.Text.Trim();
            string password = this.txtPassword.Text.Trim();

            //用户名不能为空
            if (nickname == null||password ==string.Empty)
            {
                MessageBox.Show("用户名或密码不能不能为空！");
                return;
            }
            WebServiceMessage.WSMessage wsm = new WebServiceMessage.WSMessage();
            
            //创建一个Cookie容器，用于保存用户会话状态
            CookieContainer cookies = new CookieContainer();

            //向主窗体传递web服务代理类，以重复使用           
            this.Master.WsMessage = wsm;
           
            wsm.CookieContainer = cookies;

            bool over = wsm.Login(nickname,password);
            if (over)
            {
                this.Master.CurrentUsername = nickname;
                
                this.CloseKey = false;
                //关闭登陆窗体
                this.Close();
            }
            else 
            {
                MessageBox.Show("登录失败，请重试！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.btnLogin.Enabled = true;
                this.btnRegister.Enabled = true;
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseKey)
            {
                Application.Exit();
            }
        }

      
    }
}
