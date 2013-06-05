using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WebCamLib;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Webcam_Timelaps_prototype1
{
    public partial class Form1 : Form
    {
        private const int WM_CAP_EDIT_COPY = 0x41e;

        [DllImport("user32", EntryPoint = "SendMessageA")]
        protected static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);


        public Form1()
        {
            InitializeComponent();
        }

        Rectangle rect;

        TimeSpan myTimeSpan;    //used in fpsTotime
        double count = 0;       //used in the SaveImage method to count the number of images taken.
        double droped = 0;      //also used in the SaveImage method to count droped images.

        Device d;               //Used to hold the webcam device.

        int ImageHeight = 640;  //image size, though does really work
        int Imagewidth = 480;   //image size, though does really work

        IDataObject data;       //Used to hold data for the clipboard.
        Bitmap myImage;         //Used to save an image, to the hdd.

        bool TimedRun = false;

        String dateTimeCustomFormating = "hh:mm:ss dddd MMMM dd, yyyy";

        //Methods:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        #region Old Screengrab method
        //// helper method
        //public Bitmap CaptureImage(Rectangle rect)
        //{
        //    int width = rect.Right - rect.Left;
        //    int height = rect.Bottom - rect.Top;
        //    Bitmap bmp = new Bitmap(width, height);
        //    Graphics g = Graphics.FromImage(bmp);
        //    Size s = new Size(width, height);
        //    g.CopyFromScreen(rect.Left, rect.Top, 0, 0, s);
        //    g.Dispose();
        //    return bmp;
        //}
        #endregion

        private void timelapseMode(bool On_Off)
        {
            if (On_Off == true)
            {
                if (MyTimer.Enabled != true)
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        MyTimer.Interval = int.Parse(timeLaps_numericUpDown.Value.ToString());
                        MyTimer.Enabled = true;
                    }
                }
            }
            else
            {
                MyTimer.Enabled = false;
                count = 0;
            }
        }

        private double Clipfps(String fpsInput)
        {
            double resultat = 25.0;
            string temp = Regex.Replace(fpsInput, "[^0-9\\,]", "");

            try
            {
                resultat = double.Parse(temp);
            }
            catch (Exception)
            {
                resultat = 0;
            }

            return resultat;
        }

        private String fpsTotime(double numberOfImageTaken, double ClipFps)
        {
            String resultat = "";

            double temp = (numberOfImageTaken / ClipFps);

            myTimeSpan = TimeSpan.FromSeconds(temp);
            resultat = (myTimeSpan.Hours.ToString() + ":" + myTimeSpan.Minutes.ToString() + ":" + myTimeSpan.Seconds.ToString());            

            return resultat;
        }

        public void CopyImageToClipboard(int deviceHandle)
        {
            SendMessage(deviceHandle, WM_CAP_EDIT_COPY, ImageHeight, Imagewidth);
        }

        /// <summary>
        /// Use in time lapse mode, to save images to hdd as jpg images.
        /// </summary>
        /// <param name="folderPath">What folder you want the images in</param>
        /// <param name="fileName">What name you want the images to have, an incrementing number will auto added.</param>
        private void SaveImage(String folderPath, String fileName)
        {
            Clipboard.Clear();
            try
                {
                    CopyImageToClipboard(d.deviceHandle);
                    data = Clipboard.GetDataObject();

                    myImage = (Bitmap)data.GetData(DataFormats.Bitmap);
                    myImage.Save(folderPath + "\\" + fileName + count + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    count++;
                }
                catch (NullReferenceException)
                {
                    droped++;
                }

            toolStripStatusLabel1.Text = "Total images taken : " + (count).ToString() + " | " + "Droped : " + droped.ToString() + " | Clip Time : " + fpsTotime(count, Clipfps(textBox1.Text));
        }

        /// <summary>
        /// Saves a screen grab.
        /// !!May cause problems, if use while time lapse mode is on!!
        /// </summary>
        private void Screengrab()
        {
            //rect = this.RectangleToScreen(panel1.ClientRectangle);
            //rect.Offset(panel1.Left, panel1.Top);
            //Bitmap myImage = CaptureImage(rect);

            SaveFileDialog mySave = new SaveFileDialog();
            mySave.Filter = "jpg file|*.jpg";
            mySave.FilterIndex = 0;
            mySave.Title = "Save screen grab";

            if (mySave.ShowDialog() == DialogResult.OK)
            {
                Clipboard.Clear();
                CopyImageToClipboard(d.deviceHandle);
                data = Clipboard.GetDataObject();

                myImage = (Bitmap)data.GetData(DataFormats.Bitmap);
                myImage.Save(mySave.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            mySave = null;
            myImage = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Device[] devices = DeviceManager.GetAllDevices();
            
            foreach (Device d in devices)
            {
                comboBox1.Items.Add(d);
            }

            if (devices.Length > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No Webcam devices found !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timelaps_on_off_btn.Enabled = false;        //Disable Start button when no webcam is found.
                screenGrab_btn.Enabled = false;             //Disable screen grab button when no webcam is found.
            }

            From_dateTimePicker.MinDate = DateTime.Now;
            From_dateTimePicker.CustomFormat = dateTimeCustomFormating;
            From_dateTimePicker.Update();

            To_dateTimePicker.MinDate = DateTime.Now;
            To_dateTimePicker.CustomFormat = dateTimeCustomFormating;
            To_dateTimePicker.Update();

            From_dateTimePicker.Enabled = false;
            To_dateTimePicker.Enabled = false;
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            #region Old capture code
            //rect = this.RectangleToScreen(panel1.ClientRectangle);
            //rect.Offset(panel1.Left,panel1.Top);

            //Bitmap bmp = CaptureImage(rect);
            //bmp.Save(folderBrowserDialog.SelectedPath + "\\Image" + count + ".bmp");
            //bmp = null;
            #endregion


            if (TimedRun)
            {
                if (DateTime.Now <= From_dateTimePicker.Value) //Hasn't started yet...
                {
                    TimeSpan temp = (From_dateTimePicker.Value - DateTime.Now);
                    toolStripStatusLabel1.Text = "Starting in : " + temp.Hours.ToString() + ":" + temp.Minutes.ToString() + ":" + temp.Seconds.ToString();
                }
                else
                {
                    if (DateTime.Now >= To_dateTimePicker.Value) //Has ended....
                    {
                        //Stop ? / Do nothing
                        timelaps_on_off_btn.PerformClick();
                    }
                    else
                    {
                        TimeSpan temp = (To_dateTimePicker.Value - DateTime.Now);
                        SaveImage(folderBrowserDialog.SelectedPath, "Image");
                        toolStripStatusLabel1.Text += " | " + "Time left : " + temp.Hours.ToString() + ":" + temp.Minutes.ToString() + ":" + temp.Seconds.ToString();
                    }
                }
            }
            else
            {
                SaveImage(folderBrowserDialog.SelectedPath, "Image");
            }

        }

        private bool validatingFPSInput(String input)
        {
            bool resultat = false;

            if (Regex.IsMatch(input,@"^\d*(,\d*)?$"))
            {
                resultat = true;
            }

            return resultat;
            
        }

        private void TimeLapse_ON_OFF()
        {
            if (checkBox1.Checked == true)
            {
                if (To_dateTimePicker.Value > From_dateTimePicker.Value)
                {
                    if (timelaps_on_off_btn.Text == "Stop")
                    {
                        timelaps_on_off_btn.Text = "Start";
                        timelapseMode(false);
                    }
                    else
                    {
                        timelaps_on_off_btn.Text = "Stop";
                        timelapseMode(true);
                    }
                }
                else
                {
                    MessageBox.Show("The to time, can be before the from time....", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (timelaps_on_off_btn.Text == "Stop")
                {
                    timelaps_on_off_btn.Text = "Start";
                    timelapseMode(false);
                    checkBox1.Enabled = true; //enable timed run again.
                }
                else
                {
                    timelaps_on_off_btn.Text = "Stop";
                    timelapseMode(true);
                    checkBox1.Enabled = false; //disable timed run.
                }
            }

        }



        //GUI Events::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count != 0)
            {
                d = DeviceManager.GetDevice(comboBox1.SelectedIndex);
                
                try
                {
                    d.Stop();   //Stop old feed, if any.
                }
                catch (Exception)
                {
                    //do nothing...
                }

                d.ShowWindow(this.panel1);  //Start new feed.
            }

        }

        private void timelaps_on_off_btn_Click(object sender, EventArgs e)
        {
            TimeLapse_ON_OFF();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Screengrab();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                d.Stop();  //Will close the connection to the webcam, when the program closes.
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                From_dateTimePicker.Enabled = true;
                To_dateTimePicker.Enabled = true;
                TimedRun = true;
            }
            else
            {
                From_dateTimePicker.Enabled = false;
                To_dateTimePicker.Enabled = false;
                TimedRun = false;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (validatingFPSInput(textBox1.Text) == true)
            {
                //MessageBox.Show("OK");
            }
            else
            {
                textBox1.Text = "25,000";
                MessageBox.Show("The entered value is not allowed");
            }
        }

        private void About_btn_Click(object sender, EventArgs e)
        {
            About myAbout = new About();
            myAbout.ShowDialog();
        }

        private void screenGrab_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
