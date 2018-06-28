namespace ColorPicker
{
    partial class FormMain
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.lbForeColor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCopyHEX = new System.Windows.Forms.Button();
            this.btnCopyRGB = new System.Windows.Forms.Button();
            this.tbHex = new System.Windows.Forms.TextBox();
            this.tbB = new System.Windows.Forms.TextBox();
            this.tbG = new System.Windows.Forms.TextBox();
            this.tbR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioForeColor = new System.Windows.Forms.RadioButton();
            this.radioBackColor = new System.Windows.Forms.RadioButton();
            this.picExpand = new System.Windows.Forms.PictureBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.pnlColorItems = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.customTitleBar = new ColorPicker.CustomTitleBar();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExpand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.customTitleBar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(526, 38);
            this.pnlTop.TabIndex = 3;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.label7);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.pnlColorItems);
            this.pnlContent.Controls.Add(this.label6);
            this.pnlContent.Controls.Add(this.label5);
            this.pnlContent.Controls.Add(this.label4);
            this.pnlContent.Controls.Add(this.pnlResult);
            this.pnlContent.Controls.Add(this.panel2);
            this.pnlContent.Controls.Add(this.panel1);
            this.pnlContent.Controls.Add(this.radioForeColor);
            this.pnlContent.Controls.Add(this.radioBackColor);
            this.pnlContent.Controls.Add(this.picExpand);
            this.pnlContent.Controls.Add(this.picImage);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 38);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(526, 298);
            this.pnlContent.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.label6.Location = new System.Drawing.Point(337, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "color";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.label5.Location = new System.Drawing.Point(230, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "x8";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.label4.Location = new System.Drawing.Point(108, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "x1";
            // 
            // pnlResult
            // 
            this.pnlResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResult.Controls.Add(this.lbForeColor);
            this.pnlResult.Location = new System.Drawing.Point(396, 79);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(98, 42);
            this.pnlResult.TabIndex = 18;
            // 
            // lbForeColor
            // 
            this.lbForeColor.BackColor = System.Drawing.Color.Transparent;
            this.lbForeColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lbForeColor.Location = new System.Drawing.Point(29, 11);
            this.lbForeColor.Name = "lbForeColor";
            this.lbForeColor.Size = new System.Drawing.Size(37, 24);
            this.lbForeColor.TabIndex = 11;
            this.lbForeColor.Text = "Text";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picColor);
            this.panel2.Location = new System.Drawing.Point(271, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 100);
            this.panel2.TabIndex = 17;
            // 
            // picColor
            // 
            this.picColor.BackColor = System.Drawing.Color.Transparent;
            this.picColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picColor.Location = new System.Drawing.Point(0, 0);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(100, 100);
            this.picColor.TabIndex = 9;
            this.picColor.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCopyHEX);
            this.panel1.Controls.Add(this.btnCopyRGB);
            this.panel1.Controls.Add(this.tbHex);
            this.panel1.Controls.Add(this.tbB);
            this.panel1.Controls.Add(this.tbG);
            this.panel1.Controls.Add(this.tbR);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(28, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 128);
            this.panel1.TabIndex = 16;
            // 
            // btnCopyHEX
            // 
            this.btnCopyHEX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyHEX.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.btnCopyHEX.Location = new System.Drawing.Point(259, 69);
            this.btnCopyHEX.Name = "btnCopyHEX";
            this.btnCopyHEX.Size = new System.Drawing.Size(55, 27);
            this.btnCopyHEX.TabIndex = 20;
            this.btnCopyHEX.Text = "copy";
            this.btnCopyHEX.UseVisualStyleBackColor = true;
            this.btnCopyHEX.Click += new System.EventHandler(this.btnCopyHEX_Click);
            // 
            // btnCopyRGB
            // 
            this.btnCopyRGB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyRGB.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.btnCopyRGB.Location = new System.Drawing.Point(259, 32);
            this.btnCopyRGB.Name = "btnCopyRGB";
            this.btnCopyRGB.Size = new System.Drawing.Size(55, 27);
            this.btnCopyRGB.TabIndex = 21;
            this.btnCopyRGB.Text = "copy";
            this.btnCopyRGB.UseVisualStyleBackColor = true;
            this.btnCopyRGB.Click += new System.EventHandler(this.btnCopyRGB_Click);
            // 
            // tbHex
            // 
            this.tbHex.Location = new System.Drawing.Point(76, 69);
            this.tbHex.Multiline = true;
            this.tbHex.Name = "tbHex";
            this.tbHex.Size = new System.Drawing.Size(166, 27);
            this.tbHex.TabIndex = 19;
            this.tbHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(192, 32);
            this.tbB.Multiline = true;
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(50, 27);
            this.tbB.TabIndex = 16;
            this.tbB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbG
            // 
            this.tbG.Location = new System.Drawing.Point(134, 32);
            this.tbG.Multiline = true;
            this.tbG.Name = "tbG";
            this.tbG.Size = new System.Drawing.Size(50, 27);
            this.tbG.TabIndex = 17;
            this.tbG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbR
            // 
            this.tbR.Location = new System.Drawing.Point(76, 32);
            this.tbR.Multiline = true;
            this.tbR.Name = "tbR";
            this.tbR.Size = new System.Drawing.Size(50, 27);
            this.tbR.TabIndex = 18;
            this.tbR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "HEX";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "RGB";
            // 
            // radioForeColor
            // 
            this.radioForeColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.radioForeColor.Location = new System.Drawing.Point(395, 49);
            this.radioForeColor.Name = "radioForeColor";
            this.radioForeColor.Size = new System.Drawing.Size(99, 24);
            this.radioForeColor.TabIndex = 14;
            this.radioForeColor.Text = "ForeColor";
            this.radioForeColor.UseVisualStyleBackColor = true;
            // 
            // radioBackColor
            // 
            this.radioBackColor.Checked = true;
            this.radioBackColor.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.radioBackColor.Location = new System.Drawing.Point(395, 22);
            this.radioBackColor.Name = "radioBackColor";
            this.radioBackColor.Size = new System.Drawing.Size(99, 24);
            this.radioBackColor.TabIndex = 14;
            this.radioBackColor.TabStop = true;
            this.radioBackColor.Text = "BackColor";
            this.radioBackColor.UseVisualStyleBackColor = true;
            // 
            // picExpand
            // 
            this.picExpand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picExpand.Location = new System.Drawing.Point(150, 21);
            this.picExpand.Name = "picExpand";
            this.picExpand.Size = new System.Drawing.Size(100, 100);
            this.picExpand.TabIndex = 5;
            this.picExpand.TabStop = false;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Location = new System.Drawing.Point(28, 21);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(100, 100);
            this.picImage.TabIndex = 3;
            this.picImage.TabStop = false;
            // 
            // pnlColorItems
            // 
            this.pnlColorItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColorItems.Location = new System.Drawing.Point(395, 143);
            this.pnlColorItems.Name = "pnlColorItems";
            this.pnlColorItems.Size = new System.Drawing.Size(98, 127);
            this.pnlColorItems.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.label1.Location = new System.Drawing.Point(25, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "captue: press \'c\' or \'ctrl+c\'";
            // 
            // customTitleBar
            // 
            this.customTitleBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTitleBar.Location = new System.Drawing.Point(0, 0);
            this.customTitleBar.Name = "customTitleBar";
            this.customTitleBar.Size = new System.Drawing.Size(526, 38);
            this.customTitleBar.TabIndex = 0;
            this.customTitleBar.Title = "TITLE";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 7F);
            this.label7.Location = new System.Drawing.Point(394, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "del: \'double click\'";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 336);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlResult.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExpand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox picExpand;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCopyHEX;
        private System.Windows.Forms.Button btnCopyRGB;
        private System.Windows.Forms.TextBox tbHex;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.TextBox tbG;
        private System.Windows.Forms.TextBox tbR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioForeColor;
        private System.Windows.Forms.RadioButton radioBackColor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picColor;
        private CustomTitleBar customTitleBar;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.Label lbForeColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlColorItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
    }
}

