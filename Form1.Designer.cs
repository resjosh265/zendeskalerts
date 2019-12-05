namespace zendeskalerts
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.email_L = new System.Windows.Forms.Label();
            this.password_L = new System.Windows.Forms.Label();
            this.email_val = new System.Windows.Forms.TextBox();
            this.password_val = new System.Windows.Forms.TextBox();
            this.remember = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pSound = new System.Windows.Forms.CheckBox();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCache = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.zendeskUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // email_L
            // 
            this.email_L.AutoSize = true;
            this.email_L.Location = new System.Drawing.Point(113, 80);
            this.email_L.Name = "email_L";
            this.email_L.Size = new System.Drawing.Size(35, 13);
            this.email_L.TabIndex = 2;
            this.email_L.Text = "Email:";
            // 
            // password_L
            // 
            this.password_L.AutoSize = true;
            this.password_L.Location = new System.Drawing.Point(99, 109);
            this.password_L.Name = "password_L";
            this.password_L.Size = new System.Drawing.Size(56, 13);
            this.password_L.TabIndex = 3;
            this.password_L.Text = "Password:";
            // 
            // email_val
            // 
            this.email_val.Location = new System.Drawing.Point(158, 80);
            this.email_val.Name = "email_val";
            this.email_val.Size = new System.Drawing.Size(161, 20);
            this.email_val.TabIndex = 4;
            // 
            // password_val
            // 
            this.password_val.Location = new System.Drawing.Point(158, 106);
            this.password_val.Name = "password_val";
            this.password_val.PasswordChar = '*';
            this.password_val.Size = new System.Drawing.Size(161, 20);
            this.password_val.TabIndex = 5;
            // 
            // remember
            // 
            this.remember.AutoSize = true;
            this.remember.Location = new System.Drawing.Point(102, 142);
            this.remember.Name = "remember";
            this.remember.Size = new System.Drawing.Size(101, 17);
            this.remember.TabIndex = 7;
            this.remember.Text = "Remember Me?";
            this.remember.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pSound
            // 
            this.pSound.AutoSize = true;
            this.pSound.Checked = true;
            this.pSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pSound.Location = new System.Drawing.Point(233, 142);
            this.pSound.Name = "pSound";
            this.pSound.Size = new System.Drawing.Size(86, 17);
            this.pSound.TabIndex = 8;
            this.pSound.Text = "Play Sound?";
            this.pSound.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(94, 26);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(93, 22);
            this.exit.Text = "exit";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // clearCache
            // 
            this.clearCache.Interval = 300000;
            this.clearCache.Tick += new System.EventHandler(this.clearCache_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // zendeskUrl
            // 
            this.zendeskUrl.Location = new System.Drawing.Point(158, 54);
            this.zendeskUrl.Name = "zendeskUrl";
            this.zendeskUrl.Size = new System.Drawing.Size(161, 20);
            this.zendeskUrl.TabIndex = 10;
            this.zendeskUrl.Text = "https://example.zendesk.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Zendesk URL:";
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 226);
            this.Controls.Add(this.zendeskUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pSound);
            this.Controls.Add(this.remember);
            this.Controls.Add(this.password_val);
            this.Controls.Add(this.email_val);
            this.Controls.Add(this.password_L);
            this.Controls.Add(this.email_L);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label email_L;
        private System.Windows.Forms.Label password_L;
        private System.Windows.Forms.TextBox email_val;
        private System.Windows.Forms.TextBox password_val;
        private System.Windows.Forms.CheckBox remember;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox pSound;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.Timer clearCache;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox zendeskUrl;
        private System.Windows.Forms.Label label1;
    }
}

