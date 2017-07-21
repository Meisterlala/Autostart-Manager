namespace Autostart_Manager
{
    partial class Edit
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCommandline = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonChoose = new System.Windows.Forms.Button();
            this.checkBoxKeepRunning = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(12, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(352, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Text = Autostart_Manager.Properties.Resources.Main_InitilizeListView_Name;
            this.textBoxName.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxName.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // textBoxCommandline
            // 
            this.textBoxCommandline.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommandline.Location = new System.Drawing.Point(12, 75);
            this.textBoxCommandline.Name = "textBoxCommandline";
            this.textBoxCommandline.Size = new System.Drawing.Size(352, 20);
            this.textBoxCommandline.TabIndex = 1;
            this.textBoxCommandline.Text = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Commandline;
            this.textBoxCommandline.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxCommandline.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Location = new System.Drawing.Point(12, 46);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(271, 20);
            this.textBoxPath.TabIndex = 2;
            this.textBoxPath.Text = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Path;
            this.textBoxPath.Enter += new System.EventHandler(this.TextBox_Enter);
            this.textBoxPath.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // buttonChoose
            // 
            this.buttonChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChoose.Location = new System.Drawing.Point(289, 46);
            this.buttonChoose.Name = "buttonChoose";
            this.buttonChoose.Size = new System.Drawing.Size(75, 20);
            this.buttonChoose.TabIndex = 3;
            this.buttonChoose.Text = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Choose;
            this.buttonChoose.UseVisualStyleBackColor = true;
            this.buttonChoose.Click += new System.EventHandler(this.Button_choose);
            // 
            // checkBoxKeepRunning
            // 
            this.checkBoxKeepRunning.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxKeepRunning.AutoSize = true;
            this.checkBoxKeepRunning.Location = new System.Drawing.Point(144, 108);
            this.checkBoxKeepRunning.Name = "checkBoxKeepRunning";
            this.checkBoxKeepRunning.Size = new System.Drawing.Size(89, 17);
            this.checkBoxKeepRunning.TabIndex = 4;
            this.checkBoxKeepRunning.Text = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_KeepRunning;
            this.checkBoxKeepRunning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxKeepRunning.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 104);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Cancel;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.Button_cancel);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(289, 104);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Add;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.Button_Add);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_ChooseExecutable;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 139);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxKeepRunning);
            this.Controls.Add(this.buttonChoose);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBoxCommandline);
            this.Controls.Add(this.textBoxName);
            this.MaximumSize = new System.Drawing.Size(1500, 178);
            this.MinimumSize = new System.Drawing.Size(380, 178);
            this.Name = "Edit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = Autostart_Manager.Properties.Resources.Edit_InitializeComponent_Edit;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCommandline;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonChoose;
        private System.Windows.Forms.CheckBox checkBoxKeepRunning;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}