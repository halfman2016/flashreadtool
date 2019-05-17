using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace frt
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

      

        private void Btndisplay_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(display));
        }


        private async Task<string> Read(StorageFile file)
        {
            string str = "";
            try
            {
                str = await Windows.Storage.FileIO.ReadTextAsync(file);
            }
            catch (ArgumentOutOfRangeException)
            {
                //using(var stream =new StreamReader((await file.OpenReadAsync()).GetInputStreamAt(0).AsStreamForRead()))
                //{
                //    string text = stream.ReadToEnd();
                //    return text;
                //}


                IBuffer buffer = await FileIO.ReadBufferAsync(file);
                DataReader reader = DataReader.FromBuffer(buffer);
                byte[] fileContent = new byte[reader.UnconsumedBufferLength];
                reader.ReadBytes(fileContent);
                string text = "";

                // Encoding.ASCII.GetString(fileContent, 0, fileContent.Length);

                //text= Encoding.GetEncoding(0).GetString(fileContent, 0, fileContent.Length);

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding gbk = Encoding.GetEncoding("GBK");

                text = gbk.GetString(fileContent);
                //string text = AutoEncoding(new byte[4] { fileContent[0], fileContent[1], fileContent[2], fileContent[3] }).GetString(fileContent);

                return text;
            }
            return str;
        }

        private static Encoding AutoEncoding(byte[] bom)
        {
            if (bom.Length != 4)
            {
                throw new ArgumentException();
            }
            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }

        private async void Btnselfile_Click(object sender, RoutedEventArgs e)
        {

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            picker.FileTypeFilter.Add(".txt");

            Windows.Storage.StorageFile storageFile = await picker.PickSingleFileAsync();
            Windows.Storage.StorageFile file = storageFile;
            if (file != null)
            {
                // Application now has read/write access to the picked file
                txtfilename.Text = "Picked File: " + file.Name;
                (Application.Current as App).maintxt = await Read(file);

            }
            else
            {
                txtfilename.Text = "Operation cancelled.";
            }

            return;
        }
    }


}
