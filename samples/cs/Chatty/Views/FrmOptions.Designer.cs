using CommunityToolkit.WinForms.FluentUI.Containers;

namespace Chatty.Views
{
    partial class FrmOptions
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
            _chkArchiveChats = new CheckBox();
            _grpChatSettings = new GroupBox();
            _chkCopyLastAnswerToClipboard = new CheckBox();
            _fdpChatFolder = new FluentDecoratorPanel();
            _txtAppDataPath = new TextBox();
            _btnPickPath = new Button();
            _btnOK = new Button();
            _btnCancel = new Button();
            groupBox1 = new GroupBox();
            fluentModelPicker3 = new Chatty.Controls.FluentModelPicker();
            fluentModelPicker2 = new Chatty.Controls.FluentModelPicker();
            fluentModelPicker1 = new Chatty.Controls.FluentModelPicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            _grpChatSettings.SuspendLayout();
            _fdpChatFolder.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // _chkArchiveChats
            // 
            _chkArchiveChats.AutoSize = true;
            _chkArchiveChats.Location = new Point(46, 38);
            _chkArchiveChats.Margin = new Padding(4);
            _chkArchiveChats.Name = "_chkArchiveChats";
            _chkArchiveChats.Size = new Size(261, 34);
            _chkArchiveChats.TabIndex = 0;
            _chkArchiveChats.Text = "Archive chats to folder:";
            _chkArchiveChats.UseVisualStyleBackColor = true;
            _chkArchiveChats.CheckedChanged += ChkArchiveChats_CheckedChanged;
            // 
            // _grpChatSettings
            // 
            _grpChatSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpChatSettings.Controls.Add(_chkCopyLastAnswerToClipboard);
            _grpChatSettings.Controls.Add(_fdpChatFolder);
            _grpChatSettings.Controls.Add(_chkArchiveChats);
            _grpChatSettings.Location = new Point(34, 13);
            _grpChatSettings.Margin = new Padding(4);
            _grpChatSettings.Name = "_grpChatSettings";
            _grpChatSettings.Padding = new Padding(4);
            _grpChatSettings.Size = new Size(852, 283);
            _grpChatSettings.TabIndex = 1;
            _grpChatSettings.TabStop = false;
            _grpChatSettings.Text = "Chat settings:";
            // 
            // _chkCopyLastAnswerToClipboard
            // 
            _chkCopyLastAnswerToClipboard.AutoSize = true;
            _chkCopyLastAnswerToClipboard.Location = new Point(46, 157);
            _chkCopyLastAnswerToClipboard.Margin = new Padding(4);
            _chkCopyLastAnswerToClipboard.Name = "_chkCopyLastAnswerToClipboard";
            _chkCopyLastAnswerToClipboard.Size = new Size(325, 34);
            _chkCopyLastAnswerToClipboard.TabIndex = 2;
            _chkCopyLastAnswerToClipboard.Text = "Copy last answer to clipboard";
            _chkCopyLastAnswerToClipboard.UseVisualStyleBackColor = true;
            // 
            // _fdpChatFolder
            // 
            _fdpChatFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _fdpChatFolder.BorderThickness = 1;
            _fdpChatFolder.Controls.Add(_txtAppDataPath);
            _fdpChatFolder.Controls.Add(_btnPickPath);
            _fdpChatFolder.Location = new Point(72, 76);
            _fdpChatFolder.Margin = new Padding(4);
            _fdpChatFolder.Name = "_fdpChatFolder";
            _fdpChatFolder.Padding = new Padding(6);
            _fdpChatFolder.Size = new Size(762, 45);
            _fdpChatFolder.TabIndex = 1;
            // 
            // _txtAppDataPath
            // 
            _txtAppDataPath.BorderStyle = BorderStyle.None;
            _txtAppDataPath.Location = new Point(7, 8);
            _txtAppDataPath.Margin = new Padding(4);
            _txtAppDataPath.Name = "_txtAppDataPath";
            _txtAppDataPath.Size = new Size(708, 29);
            _txtAppDataPath.TabIndex = 0;
            // 
            // _btnPickPath
            // 
            _btnPickPath.FlatStyle = FlatStyle.Flat;
            _btnPickPath.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnPickPath.Location = new Point(725, 8);
            _btnPickPath.Margin = new Padding(4);
            _btnPickPath.Name = "_btnPickPath";
            _btnPickPath.Size = new Size(30, 29);
            _btnPickPath.TabIndex = 2;
            _btnPickPath.Text = "...";
            _btnPickPath.UseVisualStyleBackColor = true;
            _btnPickPath.Click += BtnPickPath_Click;
            // 
            // _btnOK
            // 
            _btnOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnOK.DialogResult = DialogResult.OK;
            _btnOK.FlatStyle = FlatStyle.Flat;
            _btnOK.Location = new Point(909, 23);
            _btnOK.Name = "_btnOK";
            _btnOK.Size = new Size(140, 46);
            _btnOK.TabIndex = 2;
            _btnOK.Text = "OK";
            _btnOK.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnCancel.DialogResult = DialogResult.Cancel;
            _btnCancel.FlatStyle = FlatStyle.Flat;
            _btnCancel.Location = new Point(909, 83);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.Size = new Size(140, 46);
            _btnCancel.TabIndex = 3;
            _btnCancel.Text = "Cancel";
            _btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fluentModelPicker3);
            groupBox1.Controls.Add(fluentModelPicker2);
            groupBox1.Controls.Add(fluentModelPicker1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(34, 323);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(852, 315);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Models";
            // 
            // fluentModelPicker3
            // 
            fluentModelPicker3.BorderThickness = 1;
            fluentModelPicker3.Location = new Point(287, 213);
            fluentModelPicker3.Name = "fluentModelPicker3";
            fluentModelPicker3.Padding = new Padding(10);
            fluentModelPicker3.Size = new Size(540, 63);
            fluentModelPicker3.TabIndex = 5;
            // 
            // fluentModelPicker2
            // 
            fluentModelPicker2.BorderThickness = 1;
            fluentModelPicker2.Location = new Point(287, 130);
            fluentModelPicker2.Name = "fluentModelPicker2";
            fluentModelPicker2.Padding = new Padding(10);
            fluentModelPicker2.Size = new Size(540, 63);
            fluentModelPicker2.TabIndex = 4;
            // 
            // fluentModelPicker1
            // 
            fluentModelPicker1.BorderThickness = 1;
            fluentModelPicker1.Location = new Point(287, 47);
            fluentModelPicker1.Name = "fluentModelPicker1";
            fluentModelPicker1.Padding = new Padding(10);
            fluentModelPicker1.Size = new Size(540, 63);
            fluentModelPicker1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 227);
            label3.Name = "label3";
            label3.Size = new Size(263, 30);
            label3.TabIndex = 2;
            label3.Text = "For meta data processing:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 146);
            label2.Name = "label2";
            label2.Size = new Size(237, 30);
            label2.TabIndex = 1;
            label2.Text = "For context processing:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 65);
            label1.Name = "label1";
            label1.Size = new Size(188, 30);
            label1.TabIndex = 0;
            label1.Text = "For conversations:";
            // 
            // FrmOptions
            // 
            AcceptButton = _btnOK;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = _btnCancel;
            ClientSize = new Size(1061, 669);
            Controls.Add(groupBox1);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            Controls.Add(_grpChatSettings);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmOptions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Options";
            Load += FrmOptions_Load;
            _grpChatSettings.ResumeLayout(false);
            _grpChatSettings.PerformLayout();
            _fdpChatFolder.ResumeLayout(false);
            _fdpChatFolder.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox _chkArchiveChats;
        private GroupBox _grpChatSettings;
        private FluentDecoratorPanel _fdpChatFolder;
        private TextBox _txtAppDataPath;
        private Button _btnPickPath;
        private Button _btnOK;
        private Button _btnCancel;
        private CheckBox _chkCopyLastAnswerToClipboard;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Controls.FluentModelPicker fluentModelPicker3;
        private Controls.FluentModelPicker fluentModelPicker2;
        private Controls.FluentModelPicker fluentModelPicker1;
    }
}