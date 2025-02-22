﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WIA; 

namespace Skaner225959
{
    class ScannerController
    {
        int color = 1;
        int resolution,
            dpi,
            leftPixel,
            width,
            height, bright, contrast;
        public DeviceInfo chosenDevice;
        private Device device;
        public List<DeviceInfo> scanners;
        private WIA.Item scannerItem;
        private ImageFile imageFile;
        public string filePath;
        public void setColor(int colorNumber)
        {
            color = colorNumber;
        }
        public ScannerController()
        {
            scanners = new List<DeviceInfo>();
            
        }
        
        public void getScanners()
        {
            scanners = new List<DeviceInfo>();
            DeviceManager deviceManager = new DeviceManager();
            for (int i=1; i<= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType || deviceManager.DeviceInfos[i]==null)
                    continue;
               
                scanners.Add(deviceManager.DeviceInfos[i]);
                Console.WriteLine(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
            }
            if(scanners.Count>0)
            {
                chosenDevice = scanners[0];
                ConnectScannerItem();
            }
           
        }
        public void scan(string format)
        {
            if (chosenDevice == null)
            {
                getScanners(); //change chosenDevice to default number 0 device
            }
            if (chosenDevice == null)
            {
                return;
            }
            if (chosenDevice != null || filePath == "")
            {
                filePath = filePath + "\\scan1.jpeg";
               
               
                imageFile = (ImageFile)scannerItem.Transfer(format);
                saveFile(filePath, imageFile);
                filePath = null;
            }
            
        }
        public void ConnectScannerItem()
        {
            if (chosenDevice != null) {
            device = chosenDevice.Connect();
            scannerItem = device.Items[1];
            }
        }
        private void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel, int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
        {
            
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
           
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";

            

            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
            
        }

        internal void setResolutionVertical(int v)
        {
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            SetWIAProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, v);
        }
        internal void setResolutionHorizontal(int h)
        {
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            SetWIAProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, h);
        }

        /// <summary>
        /// Modify a WIA property
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        private void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            try { 
            Property prop = properties.get_Item(ref propName);
            Console.WriteLine(prop.get_Value());
            prop.set_Value(ref propValue);
            }
            catch (Exception e) { Console.WriteLine("BŁĘDNE WARTOŚCI USTAWIEŃ!"); }
            
        }
        public void updateColor()
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            SetWIAProperty(scannerItem.Properties, WIA_SCAN_COLOR_MODE, color);

        }
       
         public void scanDialog()
        {
            WIA.CommonDialog dialog = new WIA.CommonDialog();
            ImageFile scanResults = dialog.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.ColorIntent, WiaImageBias.MaximizeQuality, WIA.FormatID.wiaFormatJPEG, false, false, false);
            filePath = filePath + "\\scan1.jpeg";
            saveFile(filePath, scanResults);
            filePath = null;
        }
        
        private void saveFile(string filePath, ImageFile scan)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (scan != null) //check if scan was done
                scan.SaveFile(filePath);
            
        }

    }
}
