﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA; 

namespace Skaner225959
{
    public partial class Form1 : Form
    {
        String path;
        ScannerController sc;
        public Form1()
        {
            InitializeComponent();
            sc= new ScannerController();
        }

        private void scannersBtn_Click(object sender, EventArgs e)
        {
            scannersList.Items.Clear();
            sc.getScanners();
            for (int i=0; i<sc.scanners.Count; i++)
            {
                scannersList.Items.Add(sc.scanners.ToArray()[i].Properties["Name"].get_Value());
            }
        }

        private void scannersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(scannersList.Items.Count<0)
            {
                sc.chosenDevice = sc.scanners[scannersList.SelectedIndex];
                sc.ConnectScannerItem();
            }
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            if (path == null) openFolderDialog();
            if (sc.scanners.Count == 0)
            {
                sc.getScanners();
                
            }
            if (sc.scanners.Count > 0)
            {
                if(scannersList.SelectedIndex!=-1)
                sc.chosenDevice = sc.scanners[scannersList.SelectedIndex];
                updateSettings();
                sc.scan(FormatID.wiaFormatJPEG);
                showImg();
            }
        }

        private void folderBtn_Click(object sender, EventArgs e)
        {
            openFolderDialog();
        }

        private void imgShow_Click(object sender, EventArgs e)
        {
            showImg();

        }

        

        private void dialogBtn_Click(object sender, EventArgs e)
        {

            sc.scanDialog();
        }

        private void openFolderDialog()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
                Console.WriteLine(path);
                sc.filePath = path;
            }
        }
        private void showImg()
        {

            pictureBox1.ImageLocation = sc.filePath;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void colorCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sc.chosenDevice!=null)
            switch (colorCB.SelectedIndex)
            {
                case 0: {
                        sc.setColor(1); //Set color full
                        break; }
                case 1: {
                        sc.setColor(2); //Set Grayscale
                        break; }
                case 2: {
                        sc.setColor(4);// Set Black-white
                            break; }

                default:
                    break;
            }
            sc.updateColor();
        }

        
        private void verticalResolutionText_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                
                e.Handled = true;
            }
           

          
        }
        private void updateSettings()
        {
            if(verticalResolutionText.Text.Length>0)
            sc.setResolutionVertical(Int32.Parse(verticalResolutionText.Text));
            if(HorizontalResoultionText.Text.Length>0)
            sc.setResolutionHorizontal(Int32.Parse(HorizontalResoultionText.Text));
        }

        private void horizontalResolutionText_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;
            }



        }
    }
}