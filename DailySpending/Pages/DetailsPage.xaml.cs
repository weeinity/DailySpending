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
    public sealed partial class DetailsPage : UserControl
    {
        FileManager.ItemData itemData = null;

        public DetailsPage()
        {
            this.InitializeComponent();
            this.DataLoad();
        }
        private void DataLoad()
        {
            FileManager fm = new FileManager();
            this.itemData = new FileManager.ItemData();
            fm.ReadSampleData(this.itemData);
            DetailList.ItemsSource = this.itemData.Collection;
        }

    }
}
