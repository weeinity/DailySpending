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
using Windows.ApplicationModel.Activation;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DailySpending
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExtendedSplash
    {
        private SplashScreen splash;
        internal Frame rootFrame;

        public ExtendedSplash(SplashScreen splashscreen, bool loadState)
        {
            this.InitializeComponent();
            this.rootFrame = new Frame();

            this.GoToMainPage();
        }

        public async void GoToMainPage()
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5));

            // Navigate to mainpage    
            rootFrame.Navigate(typeof(MainPage));

            // Place the frame in the current Window 
            Window.Current.Content = rootFrame;
        }

    }
}
