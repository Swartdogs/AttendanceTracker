
namespace AttendanceTracker
{
    partial class NewStudentForm
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
            this._firstNameLabel = new System.Windows.Forms.Label();
            this._firstNameTextBox = new System.Windows.Forms.TextBox();
            this._lastNameLabel = new System.Windows.Forms.Label();
            this._lastNameTextBox = new System.Windows.Forms.TextBox();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._mentorCodeLabel = new System.Windows.Forms.Label();
            this._mentorCodeTextBox = new System.Windows.Forms.TextBox();
            this._emailLabel = new System.Windows.Forms.Label();
            this._emailTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _firstNameLabel
            // 
            this._firstNameLabel.AutoSize = true;
            this._firstNameLabel.Location = new System.Drawing.Point(12, 9);
            this._firstNameLabel.Name = "_firstNameLabel";
            this._firstNameLabel.Size = new System.Drawing.Size(60, 13);
            this._firstNameLabel.TabIndex = 6;
            this._firstNameLabel.Text = "First Name:";
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._firstNameTextBox.Location = new System.Drawing.Point(12, 25);
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(224, 20);
            this._firstNameTextBox.TabIndex = 1;
            // 
            // _lastNameLabel
            // 
            this._lastNameLabel.AutoSize = true;
            this._lastNameLabel.Location = new System.Drawing.Point(12, 48);
            this._lastNameLabel.Name = "_lastNameLabel";
            this._lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this._lastNameLabel.TabIndex = 7;
            this._lastNameLabel.Text = "Last Name:";
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lastNameTextBox.Location = new System.Drawing.Point(12, 64);
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(224, 20);
            this._lastNameTextBox.TabIndex = 2;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(54, 168);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 5;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(135, 168);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 6;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _mentorCodeLabel
            // 
            this._mentorCodeLabel.AutoSize = true;
            this._mentorCodeLabel.Location = new System.Drawing.Point(12, 126);
            this._mentorCodeLabel.Name = "_mentorCodeLabel";
            this._mentorCodeLabel.Size = new System.Drawing.Size(71, 13);
            this._mentorCodeLabel.TabIndex = 8;
            this._mentorCodeLabel.Text = "Mentor Code:";
            // 
            // _mentorCodeTextBox
            // 
            this._mentorCodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._mentorCodeTextBox.Location = new System.Drawing.Point(12, 142);
            this._mentorCodeTextBox.Name = "_mentorCodeTextBox";
            this._mentorCodeTextBox.Size = new System.Drawing.Size(224, 20);
            this._mentorCodeTextBox.TabIndex = 4;
            this._mentorCodeTextBox.UseSystemPasswordChar = true;
            this._mentorCodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MentorCodeTextBox_KeyUp);
            // 
            // _emailLabel
            // 
            this._emailLabel.AutoSize = true;
            this._emailLabel.Location = new System.Drawing.Point(9, 87);
            this._emailLabel.Name = "_emailLabel";
            this._emailLabel.Size = new System.Drawing.Size(35, 13);
            this._emailLabel.TabIndex = 9;
            this._emailLabel.Text = "Email:";
            // 
            // _emailTextBox
            // 
            this._emailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._emailTextBox.Location = new System.Drawing.Point(12, 103);
            this._emailTextBox.Name = "_emailTextBox";
            this._emailTextBox.Size = new System.Drawing.Size(224, 20);
            this._emailTextBox.TabIndex = 3;
            // 
            // NewStudentForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(248, 201);
            this.Controls.Add(this._emailTextBox);
            this.Controls.Add(this._emailLabel);
            this.Controls.Add(this._mentorCodeTextBox);
            this.Controls.Add(this._mentorCodeLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._lastNameTextBox);
            this.Controls.Add(this._lastNameLabel);
            this.Controls.Add(this._firstNameTextBox);
            this.Controls.Add(this._firstNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _firstNameLabel;
        private System.Windows.Forms.TextBox _firstNameTextBox;
        private System.Windows.Forms.Label _lastNameLabel;
        private System.Windows.Forms.TextBox _lastNameTextBox;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _mentorCodeLabel;
        private System.Windows.Forms.TextBox _mentorCodeTextBox;
        private System.Windows.Forms.Label _emailLabel;
        private System.Windows.Forms.TextBox _emailTextBox;
    }
}