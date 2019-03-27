namespace ClientApp
{
    partial class FormJoinGroup
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
            this.btnJoinGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnJoinGroup
            // 
            this.btnJoinGroup.Location = new System.Drawing.Point(123, 117);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(75, 23);
            this.btnJoinGroup.TabIndex = 0;
            this.btnJoinGroup.Text = "加  群";
            this.btnJoinGroup.UseVisualStyleBackColor = true;
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "群名称：";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(123, 59);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(149, 21);
            this.txtGroupName.TabIndex = 2;
            // 
            // FormJoinGroup
            // 
            this.AcceptButton = this.btnJoinGroup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(361, 187);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJoinGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormJoinGroup";
            this.Text = "加群";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJoinGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupName;
    }
}