using CommunityToolkit.WinForms.Controls.Tooling.Console;
using CommunityToolkit.WinForms.FluentUI.Controls;

namespace AutoCompleteEditorTest
{
    partial class FrmTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            autoCompleteEditor1 = new CommunityToolkit.WinForms.FluentUI.Controls.AutoCompleteEditor();
            _debugConsole = new ConsoleControl();
            SuspendLayout();
            // 
            // autoCompleteEditor1
            // 
            autoCompleteEditor1.Location = new Point(27, 31);
            autoCompleteEditor1.Margin = new Padding(4);
            autoCompleteEditor1.MinTimeSuggestionRequestSensitivity = 1F;
            autoCompleteEditor1.Name = "autoCompleteEditor1";
            autoCompleteEditor1.Size = new Size(1165, 221);
            autoCompleteEditor1.TabIndex = 0;
            autoCompleteEditor1.Text = "";
            autoCompleteEditor1.AsyncRequestAutoCompleteSuggestion += AutoCompleteEditor_AsyncRequestAutoCompleteSuggestion;
            autoCompleteEditor1.AsyncSendCommand += AutoCompleteEditor_AsyncSendCommand;
            // 
            // _debugConsole
            // 
            _debugConsole.Location = new Point(33, 318);
            _debugConsole.Margin = new Padding(4);
            _debugConsole.Name = "_debugConsole";
            _debugConsole.Size = new Size(1139, 396);
            _debugConsole.TabIndex = 1;
            _debugConsole.Text = "";
            // 
            // FrmTest
            // 
            AutoScaleDimensions = new SizeF(14F, 36F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 729);
            Controls.Add(_debugConsole);
            Controls.Add(autoCompleteEditor1);
            Font = new Font("Segoe UI", 11.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FrmTest";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private AutoCompleteEditor autoCompleteEditor1;
        private ConsoleControl _debugConsole;
    }
}
