namespace ClientApp
{
    partial class FormCreateGroup
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
            this.BtnCreateGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnCreateGroup
            // 
            this.BtnCreateGroup.Location = new System.Drawing.Point(351, 61);
            this.BtnCreateGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnCreateGroup.Name = "BtnCreateGroup";
            this.BtnCreateGroup.Size = new System.Drawing.Size(89, 29);
            this.BtnCreateGroup.TabIndex = 0;
            this.BtnCreateGroup.Text = "创  建";
            this.BtnCreateGroup.UseVisualStyleBackColor = true;
            this.BtnCreateGroup.Click += new System.EventHandler(this.BtnCreateGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "群名称：";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(128, 64);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(208, 25);
            this.txtGroupName.TabIndex = 2;
            // 
            // FormCreateGroup
            // 
            this.AcceptButton = this.BtnCreateGroup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(538, 158);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCreateGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormCreateGroup";
            this.Text = "创建群";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCreateGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupName;


    }
}