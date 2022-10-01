
namespace AttendanceTracker
{
    partial class AttendanceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this._idTextBox = new System.Windows.Forms.TextBox();
            this._submitButton = new System.Windows.Forms.Button();
            this._studentDataGridView = new System.Windows.Forms.DataGridView();
            this._lockButton = new System.Windows.Forms.Button();
            this._forceCheckoutButton = new System.Windows.Forms.Button();
            this._removeStudentButton = new System.Windows.Forms.Button();
            this._settingsStrip = new System.Windows.Forms.MenuStrip();
            this._settingsStripSettings = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._studentDataGridView)).BeginInit();
            this._settingsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _idTextBox
            // 
            this._idTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._idTextBox.Location = new System.Drawing.Point(12, 12);
            this._idTextBox.Name = "_idTextBox";
            this._idTextBox.Size = new System.Drawing.Size(482, 20);
            this._idTextBox.TabIndex = 0;
            this._idTextBox.UseSystemPasswordChar = true;
            this._idTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IdTextBox_KeyUp);
            // 
            // _submitButton
            // 
            this._submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._submitButton.Location = new System.Drawing.Point(500, 10);
            this._submitButton.Name = "_submitButton";
            this._submitButton.Size = new System.Drawing.Size(113, 23);
            this._submitButton.TabIndex = 1;
            this._submitButton.Text = "Submit";
            this._submitButton.UseVisualStyleBackColor = true;
            this._submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // _studentDataGridView
            // 
            this._studentDataGridView.AllowUserToAddRows = false;
            this._studentDataGridView.AllowUserToDeleteRows = false;
            this._studentDataGridView.AllowUserToResizeColumns = false;
            this._studentDataGridView.AllowUserToResizeRows = false;
            this._studentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._studentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._studentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._studentDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this._studentDataGridView.Location = new System.Drawing.Point(12, 38);
            this._studentDataGridView.Name = "_studentDataGridView";
            this._studentDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._studentDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this._studentDataGridView.RowHeadersVisible = false;
            this._studentDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this._studentDataGridView.Size = new System.Drawing.Size(482, 813);
            this._studentDataGridView.TabIndex = 2;
            this._studentDataGridView.TabStop = false;
            this._studentDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.StudentDataGridView_CellFormatting);
            this._studentDataGridView.SelectionChanged += new System.EventHandler(this.StudentDataGridView_SelectionChanged);
            // 
            // _lockButton
            // 
            this._lockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lockButton.Enabled = false;
            this._lockButton.Location = new System.Drawing.Point(500, 39);
            this._lockButton.Name = "_lockButton";
            this._lockButton.Size = new System.Drawing.Size(113, 23);
            this._lockButton.TabIndex = 3;
            this._lockButton.TabStop = false;
            this._lockButton.Text = "Lock";
            this._lockButton.UseVisualStyleBackColor = true;
            this._lockButton.Visible = false;
            this._lockButton.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // _forceCheckoutButton
            // 
            this._forceCheckoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._forceCheckoutButton.Enabled = false;
            this._forceCheckoutButton.Location = new System.Drawing.Point(500, 68);
            this._forceCheckoutButton.Name = "_forceCheckoutButton";
            this._forceCheckoutButton.Size = new System.Drawing.Size(113, 23);
            this._forceCheckoutButton.TabIndex = 4;
            this._forceCheckoutButton.TabStop = false;
            this._forceCheckoutButton.Text = "Force Checkout";
            this._forceCheckoutButton.UseVisualStyleBackColor = true;
            this._forceCheckoutButton.Visible = false;
            this._forceCheckoutButton.Click += new System.EventHandler(this.ForceCheckoutButton_Click);
            // 
            // _removeStudentButton
            // 
            this._removeStudentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._removeStudentButton.Enabled = false;
            this._removeStudentButton.Location = new System.Drawing.Point(500, 97);
            this._removeStudentButton.Name = "_removeStudentButton";
            this._removeStudentButton.Size = new System.Drawing.Size(113, 23);
            this._removeStudentButton.TabIndex = 5;
            this._removeStudentButton.TabStop = false;
            this._removeStudentButton.Text = "Remove Student";
            this._removeStudentButton.UseVisualStyleBackColor = true;
            this._removeStudentButton.Visible = false;
            this._removeStudentButton.Click += new System.EventHandler(this.RemoveStudentButton_Click);
            // 
            // _settingsStrip
            // 
            this._settingsStrip.BackColor = System.Drawing.SystemColors.Control;
            this._settingsStrip.Enabled = false;
            this._settingsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._settingsStripSettings});
            this._settingsStrip.Location = new System.Drawing.Point(0, 0);
            this._settingsStrip.Name = "_settingsStrip";
            this._settingsStrip.Size = new System.Drawing.Size(625, 24);
            this._settingsStrip.TabIndex = 6;
            this._settingsStrip.Text = "menuStrip1";
            this._settingsStrip.Visible = false;
            // 
            // _settingsStripSettings
            // 
            this._settingsStripSettings.Name = "_settingsStripSettings";
            this._settingsStripSettings.Size = new System.Drawing.Size(61, 20);
            this._settingsStripSettings.Text = "Settings";
            this._settingsStripSettings.Click += new System.EventHandler(this.SettingsStripSettings_Click);
            // 
            // AttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 863);
            this.Controls.Add(this._removeStudentButton);
            this.Controls.Add(this._forceCheckoutButton);
            this.Controls.Add(this._lockButton);
            this.Controls.Add(this._studentDataGridView);
            this.Controls.Add(this._submitButton);
            this.Controls.Add(this._idTextBox);
            this.Controls.Add(this._settingsStrip);
            this.MainMenuStrip = this._settingsStrip;
            this.Name = "AttendanceForm";
            this.Text = "Swartdogs Attendance";
            ((System.ComponentModel.ISupportInitialize)(this._studentDataGridView)).EndInit();
            this._settingsStrip.ResumeLayout(false);
            this._settingsStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _idTextBox;
        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.DataGridView _studentDataGridView;
        private System.Windows.Forms.Button _lockButton;
        private System.Windows.Forms.Button _forceCheckoutButton;
        private System.Windows.Forms.Button _removeStudentButton;
        private System.Windows.Forms.MenuStrip _settingsStrip;
        private System.Windows.Forms.ToolStripMenuItem _settingsStripSettings;
    }
}

