namespace ClientApp
{
    partial class FormMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessage));
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lstOnline = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnChuangjian = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShanchu = new System.Windows.Forms.Button();
            this.btnJoinQun = new System.Windows.Forms.Button();
            this.list1 = new System.Windows.Forms.ListBox();
            this.btnQingping = new System.Windows.Forms.Button();
            this.btnFayan = new System.Windows.Forms.Button();
            this.txtfayan = new System.Windows.Forms.TextBox();
            this.txtqunliao = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerMonitor
            // 
            this.timerMonitor.Interval = 4000;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 401);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lstOnline);
            this.tabPage1.Controls.Add(this.btnSend);
            this.tabPage1.Controls.Add(this.btnSendFile);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.txtMessage);
            this.tabPage1.Controls.Add(this.txtMessages);
            this.tabPage1.Controls.Add(this.lstUsers);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(694, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "普聊";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "当前在线：";
            // 
            // lstOnline
            // 
            this.lstOnline.FormattingEnabled = true;
            this.lstOnline.ItemHeight = 15;
            this.lstOnline.Location = new System.Drawing.Point(19, 228);
            this.lstOnline.Name = "lstOnline";
            this.lstOnline.Size = new System.Drawing.Size(165, 79);
            this.lstOnline.TabIndex = 14;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(588, 326);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(80, 32);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(477, 326);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(80, 32);
            this.btnSendFile.TabIndex = 12;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(104, 326);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 32);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "添加好友";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(19, 326);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 32);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(207, 228);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(461, 78);
            this.txtMessage.TabIndex = 9;
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(207, 2);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(461, 220);
            this.txtMessages.TabIndex = 8;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(19, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(165, 184);
            this.lstUsers.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.btnChuangjian);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnShanchu);
            this.tabPage2.Controls.Add(this.btnJoinQun);
            this.tabPage2.Controls.Add(this.list1);
            this.tabPage2.Controls.Add(this.btnQingping);
            this.tabPage2.Controls.Add(this.btnFayan);
            this.tabPage2.Controls.Add(this.txtfayan);
            this.tabPage2.Controls.Add(this.txtqunliao);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(694, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "群聊";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(505, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(183, 169);
            this.listBox1.TabIndex = 9;
            // 
            // btnChuangjian
            // 
            this.btnChuangjian.Location = new System.Drawing.Point(504, 317);
            this.btnChuangjian.Name = "btnChuangjian";
            this.btnChuangjian.Size = new System.Drawing.Size(89, 23);
            this.btnChuangjian.TabIndex = 8;
            this.btnChuangjian.Text = "创建群";
            this.btnChuangjian.UseVisualStyleBackColor = true;
            this.btnChuangjian.Click += new System.EventHandler(this.btnChuangjian_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(505, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "当前群：";
            // 
            // btnShanchu
            // 
            this.btnShanchu.Location = new System.Drawing.Point(505, 342);
            this.btnShanchu.Name = "btnShanchu";
            this.btnShanchu.Size = new System.Drawing.Size(183, 23);
            this.btnShanchu.TabIndex = 6;
            this.btnShanchu.Text = "退出群";
            this.btnShanchu.UseVisualStyleBackColor = true;
            // 
            // btnJoinQun
            // 
            this.btnJoinQun.Location = new System.Drawing.Point(599, 317);
            this.btnJoinQun.Name = "btnJoinQun";
            this.btnJoinQun.Size = new System.Drawing.Size(89, 23);
            this.btnJoinQun.TabIndex = 5;
            this.btnJoinQun.Text = "加入群";
            this.btnJoinQun.UseVisualStyleBackColor = true;
            this.btnJoinQun.Click += new System.EventHandler(this.btnJoinQun_Click);
            // 
            // list1
            // 
            this.list1.FormattingEnabled = true;
            this.list1.ItemHeight = 15;
            this.list1.Location = new System.Drawing.Point(505, 37);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(183, 94);
            this.list1.TabIndex = 4;
            // 
            // btnQingping
            // 
            this.btnQingping.Location = new System.Drawing.Point(212, 341);
            this.btnQingping.Name = "btnQingping";
            this.btnQingping.Size = new System.Drawing.Size(201, 23);
            this.btnQingping.TabIndex = 3;
            this.btnQingping.Text = "清屏";
            this.btnQingping.UseVisualStyleBackColor = true;
            this.btnQingping.Click += new System.EventHandler(this.btnQingping_Click);
            // 
            // btnFayan
            // 
            this.btnFayan.Location = new System.Drawing.Point(5, 342);
            this.btnFayan.Name = "btnFayan";
            this.btnFayan.Size = new System.Drawing.Size(201, 23);
            this.btnFayan.TabIndex = 2;
            this.btnFayan.Text = "发言";
            this.btnFayan.UseVisualStyleBackColor = true;
            this.btnFayan.Click += new System.EventHandler(this.btnFayan_Click);
            // 
            // txtfayan
            // 
            this.txtfayan.Location = new System.Drawing.Point(7, 283);
            this.txtfayan.Multiline = true;
            this.txtfayan.Name = "txtfayan";
            this.txtfayan.Size = new System.Drawing.Size(491, 52);
            this.txtfayan.TabIndex = 1;
            // 
            // txtqunliao
            // 
            this.txtqunliao.Location = new System.Drawing.Point(5, 6);
            this.txtqunliao.Multiline = true;
            this.txtqunliao.Name = "txtqunliao";
            this.txtqunliao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtqunliao.Size = new System.Drawing.Size(493, 270);
            this.txtqunliao.TabIndex = 0;
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 423);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMessage";
            this.Text = "聊天窗口";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMessage_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstOnline;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnChuangjian;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShanchu;
        private System.Windows.Forms.Button btnJoinQun;
        private System.Windows.Forms.ListBox list1;
        private System.Windows.Forms.Button btnQingping;
        private System.Windows.Forms.Button btnFayan;
        private System.Windows.Forms.TextBox txtfayan;
        private System.Windows.Forms.TextBox txtqunliao;
    }
}