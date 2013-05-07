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
using DailySpendingLib;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DailySpending
{
    public sealed partial class SpendingRecordPage : UserControl
    {
        public SpendingRecordPage()
        {
            this.InitializeComponent();
        }

        private void SaveAccountRecord_Click(object sender, RoutedEventArgs e)
        {
            FileManager fm = new FileManager();
            //fm.ReadXMLFile();
            fm.ReadSampleData();
            //fm.ReadFile();
            
        }
    }
}
