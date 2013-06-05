using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Webcam_Timelaps_prototype1
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void openLink(String URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            openLink("http://www.vb-helper.com/howto_net_video_capture.html");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            openLink("http://www.timvw.be/windows-multimedia-video-capture/");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            openLink("http://weblogs.asp.net/nleghari/articles/webcam.aspx");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            openLink("http://mazenl77.deviantart.com/");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            openLink("http://wcamtimelapse.codeplex.com/");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            openLink("http://www.codeplex.com");
        }

        private void About_Load(object sender, EventArgs e)
        {
            label9.Text = "WCamTimeLapse Version : " + Application.ProductVersion + " (Prototype 1)";
        }
    }
}
