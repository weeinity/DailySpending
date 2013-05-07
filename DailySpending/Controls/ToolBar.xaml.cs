using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DailySpending
{
    public enum Commands
    {
        SpendRecord = 0x1,
        Report      = 0x2,
        Details     = 0x4,
        PersonalFin = 0x8,
        Message     = 0x10,
        Setting     = 0x20
    }

    public sealed partial class ToolBar : UserControl
    {
        private MainPage currentMainPage;
        
        public ToolBar()
        {
            this.InitializeComponent();
        }

        private void SpendRecord_Click(object sender, RoutedEventArgs e)
        {
            this.CommandHelper(Commands.SpendRecord);            
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            this.CommandHelper(Commands.Report);
        }
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            this.CommandHelper(Commands.Details);
        }
        private void PersonalFin_Click(object sender, RoutedEventArgs e)
        {
            this.CommandHelper(Commands.PersonalFin);
        }
        private void Message_Click(object sender, RoutedEventArgs e)
        {
            this.CommandHelper(Commands.Message);
        }
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            this.CommandHelper(Commands.Setting);
        }

        private void CommandHelper(Commands inputCmd)
        {
            if (this.currentMainPage == null)            
            {
                this.currentMainPage = (MainPage)ApplicationService.GetMainWindowsPage;
            }

            this.currentMainPage.PageDisplay(inputCmd);
        }
    }
}
