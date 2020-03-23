﻿namespace DOOMSaveManager
{
    partial class TransferForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.transferOkBtn = new System.Windows.Forms.Button();
            this.transferCancelBtn = new System.Windows.Forms.Button();
            this.dstUidBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.srcUidComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // transferOkBtn
            // 
            this.transferOkBtn.Location = new System.Drawing.Point(296, 66);
            this.transferOkBtn.Name = "transferOkBtn";
            this.transferOkBtn.Size = new System.Drawing.Size(75, 23);
            this.transferOkBtn.TabIndex = 0;
            this.transferOkBtn.Text = "OK";
            this.transferOkBtn.UseVisualStyleBackColor = true;
            this.transferOkBtn.Click += new System.EventHandler(this.transferOkBtn_Click);
            // 
            // transferCancelBtn
            // 
            this.transferCancelBtn.Location = new System.Drawing.Point(12, 66);
            this.transferCancelBtn.Name = "transferCancelBtn";
            this.transferCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.transferCancelBtn.TabIndex = 1;
            this.transferCancelBtn.Text = "Cancel";
            this.transferCancelBtn.UseVisualStyleBackColor = true;
            this.transferCancelBtn.Click += new System.EventHandler(this.transferCancelBtn_Click);
            // 
            // dstUidBox
            // 
            this.dstUidBox.Location = new System.Drawing.Point(114, 40);
            this.dstUidBox.Name = "dstUidBox";
            this.dstUidBox.Size = new System.Drawing.Size(257, 20);
            this.dstUidBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source UUID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination UUID:";
            // 
            // srcUidComboBox
            // 
            this.srcUidComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.srcUidComboBox.FormattingEnabled = true;
            this.srcUidComboBox.Location = new System.Drawing.Point(114, 13);
            this.srcUidComboBox.Name = "srcUidComboBox";
            this.srcUidComboBox.Size = new System.Drawing.Size(257, 21);
            this.srcUidComboBox.TabIndex = 6;
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 97);
            this.ControlBox = false;
            this.Controls.Add(this.srcUidComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dstUidBox);
            this.Controls.Add(this.transferCancelBtn);
            this.Controls.Add(this.transferOkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TransferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer";
            this.Load += new System.EventHandler(this.TransferForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button transferOkBtn;
        private System.Windows.Forms.Button transferCancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox dstUidBox;
        public System.Windows.Forms.ComboBox srcUidComboBox;
    }
}