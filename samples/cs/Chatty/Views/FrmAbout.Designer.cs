namespace Chatty
{
    partial class FrmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            _mainLayoutPanel = new TableLayoutPanel();
            _picLogo = new PictureBox();
            _lblProductname = new Label();
            _lblVersion = new Label();
            _lblCopyRight = new Label();
            _lblCompany = new Label();
            _lblAuthors = new Label();
            _btnOK = new Button();
            _rtbChattyStory = new RichTextBox();
            _mainLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_picLogo).BeginInit();
            SuspendLayout();
            // 
            // _mainLayoutPanel
            // 
            _mainLayoutPanel.ColumnCount = 2;
            _mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            _mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            _mainLayoutPanel.Controls.Add(_picLogo, 0, 0);
            _mainLayoutPanel.Controls.Add(_lblProductname, 1, 0);
            _mainLayoutPanel.Controls.Add(_lblVersion, 1, 1);
            _mainLayoutPanel.Controls.Add(_lblCopyRight, 1, 2);
            _mainLayoutPanel.Controls.Add(_lblCompany, 1, 3);
            _mainLayoutPanel.Controls.Add(_lblAuthors, 1, 4);
            _mainLayoutPanel.Controls.Add(_btnOK, 1, 6);
            _mainLayoutPanel.Controls.Add(_rtbChattyStory, 1, 5);
            _mainLayoutPanel.Dock = DockStyle.Fill;
            _mainLayoutPanel.Location = new Point(0, 0);
            _mainLayoutPanel.Name = "_mainLayoutPanel";
            _mainLayoutPanel.RowCount = 7;
            _mainLayoutPanel.RowStyles.Add(new RowStyle());
            _mainLayoutPanel.RowStyles.Add(new RowStyle());
            _mainLayoutPanel.RowStyles.Add(new RowStyle());
            _mainLayoutPanel.RowStyles.Add(new RowStyle());
            _mainLayoutPanel.RowStyles.Add(new RowStyle());
            _mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _mainLayoutPanel.RowStyles.Add(new RowStyle());
            _mainLayoutPanel.Size = new Size(1002, 712);
            _mainLayoutPanel.TabIndex = 0;
            // 
            // _picLogo
            // 
            _picLogo.Dock = DockStyle.Fill;
            _picLogo.Image = (Image)resources.GetObject("_picLogo.Image");
            _picLogo.Location = new Point(6, 7);
            _picLogo.Margin = new Padding(6, 7, 6, 7);
            _picLogo.Name = "_picLogo";
            _mainLayoutPanel.SetRowSpan(_picLogo, 7);
            _picLogo.Size = new Size(318, 698);
            _picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            _picLogo.TabIndex = 12;
            _picLogo.TabStop = false;
            // 
            // _lblProductname
            // 
            _lblProductname.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            _lblProductname.Location = new Point(342, 0);
            _lblProductname.Margin = new Padding(12, 0, 6, 0);
            _lblProductname.Name = "_lblProductname";
            _lblProductname.Size = new Size(541, 80);
            _lblProductname.TabIndex = 0;
            _lblProductname.Text = "Product \r\nName";
            _lblProductname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblVersion
            // 
            _lblVersion.Dock = DockStyle.Fill;
            _lblVersion.Location = new Point(342, 80);
            _lblVersion.Margin = new Padding(12, 0, 6, 0);
            _lblVersion.MaximumSize = new Size(0, 40);
            _lblVersion.Name = "_lblVersion";
            _lblVersion.Size = new Size(654, 40);
            _lblVersion.TabIndex = 1;
            _lblVersion.Text = "Version";
            _lblVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblCopyRight
            // 
            _lblCopyRight.Dock = DockStyle.Fill;
            _lblCopyRight.Location = new Point(342, 120);
            _lblCopyRight.Margin = new Padding(12, 0, 6, 0);
            _lblCopyRight.MaximumSize = new Size(0, 40);
            _lblCopyRight.Name = "_lblCopyRight";
            _lblCopyRight.Size = new Size(654, 40);
            _lblCopyRight.TabIndex = 2;
            _lblCopyRight.Text = "Copyright";
            _lblCopyRight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblCompany
            // 
            _lblCompany.Dock = DockStyle.Fill;
            _lblCompany.Location = new Point(342, 160);
            _lblCompany.Margin = new Padding(12, 0, 6, 0);
            _lblCompany.MaximumSize = new Size(0, 40);
            _lblCompany.Name = "_lblCompany";
            _lblCompany.Size = new Size(654, 40);
            _lblCompany.TabIndex = 3;
            _lblCompany.Text = "Company Name";
            _lblCompany.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblAuthors
            // 
            _lblAuthors.AutoSize = true;
            _lblAuthors.Location = new Point(342, 200);
            _lblAuthors.Margin = new Padding(12, 0, 6, 0);
            _lblAuthors.Name = "_lblAuthors";
            _lblAuthors.Size = new Size(88, 30);
            _lblAuthors.TabIndex = 4;
            _lblAuthors.Text = "Authors";
            _lblAuthors.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _btnOK
            // 
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.DialogResult = DialogResult.Cancel;
            _btnOK.Location = new Point(846, 660);
            _btnOK.Margin = new Padding(6, 7, 6, 7);
            _btnOK.Name = "_btnOK";
            _btnOK.Size = new Size(150, 45);
            _btnOK.TabIndex = 6;
            _btnOK.Text = "&OK";
            // 
            // _rtbChattyStory
            // 
            _rtbChattyStory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _rtbChattyStory.Location = new Point(333, 233);
            _rtbChattyStory.Name = "_rtbChattyStory";
            _rtbChattyStory.ReadOnly = true;
            _rtbChattyStory.Size = new Size(666, 417);
            _rtbChattyStory.TabIndex = 13;
            _rtbChattyStory.Text = "";
            // 
            // FrmAbout
            // 
            AcceptButton = _btnOK;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(_mainLayoutPanel);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6, 7, 6, 7);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAbout";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About C.h.a.t.t.y.";
            _mainLayoutPanel.ResumeLayout(false);
            _mainLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_picLogo).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _mainLayoutPanel;
        private System.Windows.Forms.PictureBox _picLogo;
        private System.Windows.Forms.Label _lblProductname;
        private System.Windows.Forms.Label _lblVersion;
        private System.Windows.Forms.Label _lblCopyRight;
        private System.Windows.Forms.Label _lblCompany;
        private System.Windows.Forms.Button _btnOK;
        private Label _lblAuthors;
        private RichTextBox _rtbChattyStory;
    }
}
