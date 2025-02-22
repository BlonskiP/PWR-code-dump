﻿using System;
using System.Windows.Forms;

namespace Skaner225959
{
    partial class Form1
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
            this.scannersBtn = new System.Windows.Forms.Button();
            this.scannersList = new System.Windows.Forms.ListBox();
            this.scanBtn = new System.Windows.Forms.Button();
            this.folderBtn = new System.Windows.Forms.Button();
            this.imgShow = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dialogBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.colorCB = new System.Windows.Forms.ComboBox();
            this.verticalResolutionText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HorizontalResoultionText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scannersBtn
            // 
            this.scannersBtn.Location = new System.Drawing.Point(12, 12);
            this.scannersBtn.Name = "scannersBtn";
            this.scannersBtn.Size = new System.Drawing.Size(145, 23);
            this.scannersBtn.TabIndex = 0;
            this.scannersBtn.Text = "Get Scanners";
            this.scannersBtn.UseVisualStyleBackColor = true;
            this.scannersBtn.Click += new System.EventHandler(this.scannersBtn_Click);
            // 
            // scannersList
            // 
            this.scannersList.FormattingEnabled = true;
            this.scannersList.Location = new System.Drawing.Point(174, 12);
            this.scannersList.Name = "scannersList";
            this.scannersList.Size = new System.Drawing.Size(190, 69);
            this.scannersList.TabIndex = 1;
            this.scannersList.SelectedIndexChanged += new System.EventHandler(this.scannersList_SelectedIndexChanged);
            // 
            // scanBtn
            // 
            this.scanBtn.Location = new System.Drawing.Point(12, 41);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(145, 23);
            this.scanBtn.TabIndex = 2;
            this.scanBtn.Text = "Scan";
            this.scanBtn.UseVisualStyleBackColor = true;
            this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
            // 
            // folderBtn
            // 
            this.folderBtn.Location = new System.Drawing.Point(12, 70);
            this.folderBtn.Name = "folderBtn";
            this.folderBtn.Size = new System.Drawing.Size(145, 23);
            this.folderBtn.TabIndex = 3;
            this.folderBtn.Text = "Choose folder";
            this.folderBtn.UseVisualStyleBackColor = true;
            this.folderBtn.Click += new System.EventHandler(this.folderBtn_Click);
            // 
            // imgShow
            // 
            this.imgShow.Location = new System.Drawing.Point(12, 99);
            this.imgShow.Name = "imgShow";
            this.imgShow.Size = new System.Drawing.Size(145, 23);
            this.imgShow.TabIndex = 4;
            this.imgShow.Text = "showImg";
            this.imgShow.UseVisualStyleBackColor = true;
            this.imgShow.Click += new System.EventHandler(this.imgShow_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(174, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(354, 371);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // dialogBtn
            // 
            this.dialogBtn.Location = new System.Drawing.Point(12, 128);
            this.dialogBtn.Name = "dialogBtn";
            this.dialogBtn.Size = new System.Drawing.Size(145, 23);
            this.dialogBtn.TabIndex = 6;
            this.dialogBtn.Text = "Scanner Dialog";
            this.dialogBtn.UseVisualStyleBackColor = true;
            this.dialogBtn.Click += new System.EventHandler(this.dialogBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(12, 157);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(145, 23);
            this.settingsBtn.TabIndex = 7;
            this.settingsBtn.Text = "UpdateSettings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            // 
            // colorCB
            // 
            this.colorCB.FormattingEnabled = true;
            this.colorCB.Items.AddRange(new object[] {
            "Color",
            "GreyScale",
            "Black-White"});
            this.colorCB.Location = new System.Drawing.Point(18, 199);
            this.colorCB.Name = "colorCB";
            this.colorCB.Size = new System.Drawing.Size(121, 21);
            this.colorCB.TabIndex = 8;
            this.colorCB.Text = "Color";
            this.colorCB.SelectedIndexChanged += new System.EventHandler(this.colorCB_SelectedIndexChanged);
            // 
            // verticalResolutionText
            // 
            this.verticalResolutionText.Location = new System.Drawing.Point(18, 245);
            this.verticalResolutionText.Name = "verticalResolutionText";
            this.verticalResolutionText.Size = new System.Drawing.Size(100, 20);
            this.verticalResolutionText.TabIndex = 9;
            this.verticalResolutionText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.verticalResolutionText_KeyPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vertical Resolution";
            // 
            // HorizontalResoultionText
            // 
            this.HorizontalResoultionText.Location = new System.Drawing.Point(18, 284);
            this.HorizontalResoultionText.Name = "HorizontalResoultionText";
            this.HorizontalResoultionText.Size = new System.Drawing.Size(100, 20);
            this.HorizontalResoultionText.TabIndex = 11;
            this.HorizontalResoultionText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.horizontalResolutionText_KeyPressed);
            // 
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "HorizontalResolutino";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 562);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HorizontalResoultionText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verticalResolutionText);
            this.Controls.Add(this.colorCB);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.dialogBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imgShow);
            this.Controls.Add(this.folderBtn);
            this.Controls.Add(this.scanBtn);
            this.Controls.Add(this.scannersList);
            this.Controls.Add(this.scannersBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button scannersBtn;
        private System.Windows.Forms.ListBox scannersList;
        private System.Windows.Forms.Button scanBtn;
        private System.Windows.Forms.Button folderBtn;
        private System.Windows.Forms.Button imgShow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button dialogBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.ComboBox colorCB;
        private System.Windows.Forms.TextBox verticalResolutionText;
        private Label label1;
        private TextBox HorizontalResoultionText;
        private Label label2;
    }
}

