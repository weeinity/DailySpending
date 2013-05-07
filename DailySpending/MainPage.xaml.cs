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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DailySpending
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.PluginApplicationService();
        }

        private void PluginApplicationService()
        {
            ApplicationService.SetMainWindowsPage(this);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void PageDisplay(Commands inputCmd)
        {
            this.SetAllPageInvisible();

            switch (inputCmd)
            {
                case Commands.SpendRecord:
                    this.SpendingRecPage.Visibility = Visibility.Visible;
                    break;
                case Commands.Report:
                    this.ReportPage.Visibility = Visibility.Visible;
                    break;

                case Commands.Details:
                    this.DetailsPage.Visibility = Visibility.Visible;
                    break;

                case Commands.PersonalFin:
                    this.PerFinancePage.Visibility = Visibility.Visible;
                    break;
                case Commands.Message:
                    this.MessagePage.Visibility = Visibility.Visible;
                    break;
                case Commands.Setting:
                    this.SettingPage.Visibility = Visibility.Visible;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        #region Helper
        private void SetAllPageInvisible()
        {
            this.SpendingRecPage.Visibility = Visibility.Collapsed;
            this.ReportPage.Visibility = Visibility.Collapsed;
            this.DetailsPage.Visibility = Visibility.Collapsed;
            this.PerFinancePage.Visibility = Visibility.Collapsed;
            this.MessagePage.Visibility = Visibility.Collapsed;
            this.SettingPage.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
