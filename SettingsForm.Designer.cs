
namespace AttendanceTracker
{
    partial class SettingsForm
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
            this._mentorCodeLabel = new System.Windows.Forms.Label();
            this._mentorCodeTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _mentorCodeLabel
            // 
            this._mentorCodeLabel.AutoSize = true;
            this._mentorCodeLabel.Location = new System.Drawing.Point(12, 9);
            this._mentorCodeLabel.Name = "_mentorCodeLabel";
            this._mentorCodeLabel.Size = new System.Drawing.Size(71, 13);
            this._mentorCodeLabel.TabIndex = 6;
            this._mentorCodeLabel.Text = "Mentor Code:";
            // 
            // _mentorCodeTextBox
            // 
            this._mentorCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mentorCodeTextBox.Location = new System.Drawing.Point(12, 25);
            this._mentorCodeTextBox.Name = "_mentorCodeTextBox";
            this._mentorCodeTextBox.Size = new System.Drawing.Size(224, 20);
            this._mentorCodeTextBox.TabIndex = 1;
            this._mentorCodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MentorCodeTextBox_KeyUp);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(54, 51);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(135, 51);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 5;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 83);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._mentorCodeTextBox);
            this.Controls.Add(this._mentorCodeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mentor Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _mentorCodeLabel;
        private System.Windows.Forms.TextBox _mentorCodeTextBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
    }
}