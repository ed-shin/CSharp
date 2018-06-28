namespace ColorPicker
{
    partial class CustomTitleBar
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.picBtnMinimize = new System.Windows.Forms.PictureBox();
            this.picBtnClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTitle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.lbTitle.Location = new System.Drawing.Point(18, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(161, 24);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "TITLE";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picBtnMinimize
            // 
            this.picBtnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBtnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.picBtnMinimize.Image = global::ColorPicker.Properties.Resources.minimize_gray;
            this.picBtnMinimize.Location = new System.Drawing.Point(379, 3);
            this.picBtnMinimize.Name = "picBtnMinimize";
            this.picBtnMinimize.Size = new System.Drawing.Size(32, 32);
            this.picBtnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBtnMinimize.TabIndex = 1;
            this.picBtnMinimize.TabStop = false;
            this.picBtnMinimize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBtnMinimize_MouseClick);
            this.picBtnMinimize.MouseLeave += new System.EventHandler(this.picBtnMinimize_MouseLeave);
            this.picBtnMinimize.MouseHover += new System.EventHandler(this.picBtnMinimize_MouseHover);
            // 
            // picBtnClose
            // 
            this.picBtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBtnClose.BackColor = System.Drawing.Color.Transparent;
            this.picBtnClose.Image = global::ColorPicker.Properties.Resources.close_gray;
            this.picBtnClose.Location = new System.Drawing.Point(420, 3);
            this.picBtnClose.Name = "picBtnClose";
            this.picBtnClose.Size = new System.Drawing.Size(32, 32);
            this.picBtnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBtnClose.TabIndex = 1;
            this.picBtnClose.TabStop = false;
            this.picBtnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBtnClose_MouseClick);
            this.picBtnClose.MouseLeave += new System.EventHandler(this.picBtnClose_MouseLeave);
            this.picBtnClose.MouseHover += new System.EventHandler(this.picBtnClose_MouseHover);
            // 
            // CustomTitleBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.picBtnMinimize);
            this.Controls.Add(this.picBtnClose);
            this.Controls.Add(this.lbTitle);
            this.Name = "CustomTitleBar";
            this.Size = new System.Drawing.Size(458, 38);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomTitleBar_MouseDown);
            this.MouseLeave += new System.EventHandler(this.CustomTitleBar_MouseLeave);
            this.MouseHover += new System.EventHandler(this.CustomTitleBar_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomTitleBar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomTitleBar_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBtnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox picBtnClose;
        private System.Windows.Forms.PictureBox picBtnMinimize;
    }
}
