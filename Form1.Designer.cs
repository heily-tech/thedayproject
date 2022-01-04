namespace theday
{
    partial class theday
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Panel SideBarWrapper;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(theday));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Calendar = new System.Windows.Forms.Button();
            this.Alert = new System.Windows.Forms.Button();
            this.DB = new System.Windows.Forms.Button();
            this.MenuTop = new System.Windows.Forms.Panel();
            this.maxd = new System.Windows.Forms.PictureBox();
            this.mini = new System.Windows.Forms.PictureBox();
            this.maxi = new System.Windows.Forms.PictureBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuSidebar = new System.Windows.Forms.PictureBox();
            this.Wrapper = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            SideBarWrapper = new System.Windows.Forms.Panel();
            SideBarWrapper.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MenuTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuSidebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // SideBarWrapper
            // 
            SideBarWrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            SideBarWrapper.Controls.Add(this.panel1);
            SideBarWrapper.Dock = System.Windows.Forms.DockStyle.Left;
            SideBarWrapper.Location = new System.Drawing.Point(0, 80);
            SideBarWrapper.Name = "SideBarWrapper";
            SideBarWrapper.Size = new System.Drawing.Size(255, 720);
            SideBarWrapper.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.Calendar);
            this.panel1.Controls.Add(this.Alert);
            this.panel1.Controls.Add(this.DB);
            this.panel1.Location = new System.Drawing.Point(13, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 693);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Calendar
            // 
            this.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.Calendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Calendar.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calendar.ForeColor = System.Drawing.Color.White;
            this.Calendar.Image = ((System.Drawing.Image)(resources.GetObject("Calendar.Image")));
            this.Calendar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Calendar.Location = new System.Drawing.Point(9, 13);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(210, 60);
            this.Calendar.TabIndex = 2;
            this.Calendar.Text = "달력";
            this.Calendar.UseVisualStyleBackColor = false;
            this.Calendar.Click += new System.EventHandler(this.button3_Click);
            // 
            // Alert
            // 
            this.Alert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.Alert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Alert.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alert.ForeColor = System.Drawing.Color.White;
            this.Alert.Image = ((System.Drawing.Image)(resources.GetObject("Alert.Image")));
            this.Alert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Alert.Location = new System.Drawing.Point(9, 96);
            this.Alert.Name = "Alert";
            this.Alert.Size = new System.Drawing.Size(210, 60);
            this.Alert.TabIndex = 2;
            this.Alert.Text = "알림";
            this.Alert.UseVisualStyleBackColor = false;
            this.Alert.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // DB
            // 
            this.DB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.DB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DB.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DB.ForeColor = System.Drawing.Color.White;
            this.DB.Image = ((System.Drawing.Image)(resources.GetObject("DB.Image")));
            this.DB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DB.Location = new System.Drawing.Point(9, 180);
            this.DB.Name = "DB";
            this.DB.Size = new System.Drawing.Size(210, 60);
            this.DB.TabIndex = 1;
            this.DB.Text = "DB";
            this.DB.UseVisualStyleBackColor = false;
            // 
            // MenuTop
            // 
            this.MenuTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.MenuTop.Controls.Add(this.maxd);
            this.MenuTop.Controls.Add(this.mini);
            this.MenuTop.Controls.Add(this.maxi);
            this.MenuTop.Controls.Add(this.Close);
            this.MenuTop.Controls.Add(this.label1);
            this.MenuTop.Controls.Add(this.MenuSidebar);
            this.MenuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuTop.Location = new System.Drawing.Point(0, 0);
            this.MenuTop.Name = "MenuTop";
            this.MenuTop.Size = new System.Drawing.Size(1200, 80);
            this.MenuTop.TabIndex = 0;
            this.MenuTop.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuTop_Paint);
            // 
            // maxd
            // 
            this.maxd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxd.Image = ((System.Drawing.Image)(resources.GetObject("maxd.Image")));
            this.maxd.Location = new System.Drawing.Point(1107, 22);
            this.maxd.Name = "maxd";
            this.maxd.Size = new System.Drawing.Size(33, 33);
            this.maxd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maxd.TabIndex = 3;
            this.maxd.TabStop = false;
            this.maxd.Click += new System.EventHandler(this.maxd_Click);
            // 
            // mini
            // 
            this.mini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mini.Image = ((System.Drawing.Image)(resources.GetObject("mini.Image")));
            this.mini.Location = new System.Drawing.Point(1068, 22);
            this.mini.Name = "mini";
            this.mini.Size = new System.Drawing.Size(33, 33);
            this.mini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mini.TabIndex = 1;
            this.mini.TabStop = false;
            this.mini.Click += new System.EventHandler(this.mini_Click);
            // 
            // maxi
            // 
            this.maxi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxi.Image = ((System.Drawing.Image)(resources.GetObject("maxi.Image")));
            this.maxi.Location = new System.Drawing.Point(1107, 22);
            this.maxi.Name = "maxi";
            this.maxi.Size = new System.Drawing.Size(33, 33);
            this.maxi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maxi.TabIndex = 1;
            this.maxi.TabStop = false;
            this.maxi.Visible = false;
            this.maxi.Click += new System.EventHandler(this.maxi_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.Location = new System.Drawing.Point(1146, 22);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(33, 33);
            this.Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Close.TabIndex = 2;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(78, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 58);
            this.label1.TabIndex = 1;
            this.label1.Text = "The Day";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MenuSidebar
            // 
            this.MenuSidebar.Image = ((System.Drawing.Image)(resources.GetObject("MenuSidebar.Image")));
            this.MenuSidebar.Location = new System.Drawing.Point(22, 19);
            this.MenuSidebar.Name = "MenuSidebar";
            this.MenuSidebar.Size = new System.Drawing.Size(50, 50);
            this.MenuSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MenuSidebar.TabIndex = 0;
            this.MenuSidebar.TabStop = false;
            // 
            // Wrapper
            // 
            this.Wrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wrapper.Location = new System.Drawing.Point(0, 80);
            this.Wrapper.Name = "Wrapper";
            this.Wrapper.Size = new System.Drawing.Size(1200, 720);
            this.Wrapper.TabIndex = 1;
            this.Wrapper.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // theday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(SideBarWrapper);
            this.Controls.Add(this.Wrapper);
            this.Controls.Add(this.MenuTop);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "theday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "theday";
            this.Load += new System.EventHandler(this.theday_Load);
            SideBarWrapper.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.MenuTop.ResumeLayout(false);
            this.MenuTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuSidebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuTop;
        private System.Windows.Forms.Panel Wrapper;
        private System.Windows.Forms.PictureBox MenuSidebar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Close;
        private System.Windows.Forms.PictureBox mini;
        private System.Windows.Forms.PictureBox maxi;
        private System.Windows.Forms.PictureBox maxd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button DB;
        private System.Windows.Forms.Button Calendar;
        private System.Windows.Forms.Button Alert;
    }
}

